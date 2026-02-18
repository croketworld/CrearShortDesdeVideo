Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Mime.MediaTypeNames
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Xml

Public Class Form1

    Private duracionVideoOriginal As TimeSpan
    Private bg As BackgroundWorker
    Private realizando As Boolean = False

#Region "la chicha"

    Private Async Sub HacerBackground(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim comandoTxt As String = CType(e.Argument, String)
        Dim fallido As Boolean = True
        Dim exe As Exception = Nothing
        Dim ps As New ProcessStartInfo(My.Settings.FfmpegPath, comandoTxt) With {
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .CreateNoWindow = False,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True
        }
        Dim bgw As BackgroundWorker = CType(sender, BackgroundWorker)
        bgw.ReportProgress(10, $"{My.Settings.Texto_iniciandoComando} {Environment.NewLine}{comandoTxt}{Environment.NewLine}")
        Dim p As Process = Nothing
        Try
            p = Process.Start(ps)
            Dim output As String = String.Empty
            Dim fallico As String = String.Empty
            While (bg.CancellationPending = False And p.HasExited = False)
                p.WaitForExit()
                If bg.CancellationPending = True Or e.Cancel Then
                    bg.CancelAsync()
                    e.Result = New ResultadoTarea()
                    Exit Sub
                End If
                output = Await p.StandardOutput.ReadToEndAsync()
                fallico = p.StandardError.ReadToEnd()
                If String.IsNullOrEmpty(fallico) = False Then
                    Throw New ApplicationException(My.Settings.Texto_ErrorEjecutandoTarea, New ApplicationException(fallico))
                End If
                If String.IsNullOrEmpty(output) = False Then Exit While
            End While
            If String.IsNullOrEmpty(output) = False Then
                bgw.ReportProgress(90, $"{My.Settings.Texto_outputFfmpeg}:{Environment.NewLine}{output}{Environment.NewLine}")
            End If
            fallido = False

        Catch ex As Exception
            exe = ex
        End Try
        If p IsNot Nothing Then
            If p.HasExited = False Then p.WaitForExit()
            p.Kill(True)
            p.Dispose()
        End If
        If fallido Or exe IsNot Nothing Then
            Dim mensaje As String = My.Settings.Texto_ErrorEjecutandoComandoFfmpeg
            If exe IsNot Nothing Then
                mensaje += $"{Environment.NewLine}{My.Settings.Texto_DetalleDelError}:{Environment.NewLine}"
                mensaje += exe.Message
                If exe.InnerException IsNot Nothing Then
                    mensaje += $"{Environment.NewLine}{exe.InnerException.Message}"
                End If
                mensaje += $"{Environment.NewLine}{My.Settings.Texto_ComandoEjecutadoEs}: {Environment.NewLine}{comandoTxt}"
            End If
            e.Result = New ResultadoTarea(False, mensaje)
        Else
            e.Result = New ResultadoTarea(True)
        End If
        e.Result = New ResultadoTarea
    End Sub

    Private Sub HacerBackground_progreso(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        Dim mensaje As String = CType(e.UserState, String)
        TextBox1.Text += Environment.NewLine & mensaje & Environment.NewLine

    End Sub
    Private Sub HacerBackground_finalizado(sender As Object, e As RunWorkerCompletedEventArgs)
        Button1.Text = My.Settings.Btn_CrearVideoCorto
        Button1.BackColor = SystemColors.ActiveCaption
        realizando = False
        If e.Result IsNot Nothing Then
            Dim partes As ResultadoTarea = CType(e.Result, ResultadoTarea)
            If partes Is Nothing Then partes = New ResultadoTarea
            If e.Cancelled Then
                partes.Mensaje = $"{Environment.NewLine}{My.Settings.Texto_canceladoPorUsuario}{Environment.NewLine}"
            End If
            TextBox1.Text += partes.Mensaje ' Clipboard.SetText(mensaje) me parece más intrusivo
            TextBox1.Text += My.Settings.Texto_resultadoCorrectoONo & partes.OK
            If partes.OK Then
                Finalizado()
            End If
        End If


    End Sub


    Public Sub Hacer()

        If realizando = False Then
            Button1.Text = My.Settings.Btn_cancelar
            Button1.BackColor = SystemColors.Highlight
            realizando = True
        Else
            bg?.CancelAsync()
        End If


        Dim cmf As New ComandoFFMPEG(
            TextBox2.Text,
            TextBox3.Text,
            TextBox5.Text,
            TimeSpan.FromSeconds(NumericUpDown1.Value),
            TimeSpan.FromSeconds(NumericUpDown2.Value))
        Dim comandoTxt As String = cmf.ToString()
        TextBox1.Visible = True
        bg = New BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }

        AddHandler bg.DoWork, AddressOf HacerBackground
        AddHandler bg.ProgressChanged, AddressOf HacerBackground_progreso
        AddHandler bg.RunWorkerCompleted, AddressOf HacerBackground_finalizado

        bg.RunWorkerAsync(comandoTxt)
    End Sub


    Private Sub Descargarffmpeg()
#Disable Warning SYSLIB0014 ' El tipo o el miembro están obsoletos
        Dim wc As New WebClient
#Enable Warning SYSLIB0014 ' El tipo o el miembro están obsoletos
        AddHandler wc.DownloadFileCompleted, AddressOf Descargadoffmpeg
        wc.DownloadFileAsync(New Uri(My.Settings.Urlffmpeg), My.Settings.FfmpegPath)

    End Sub
    Private Sub Descargadoffmpeg()
        TextBox1.Text = My.Settings.Texto_ffmpegDescargado
    End Sub
    Private Sub ComprobarTodoOkPaDarle()
        TextBox1.Text = My.Settings.Texto_iniciandoComando
        Dim ffmpegEsta As Boolean = IO.File.Exists(TextBox2.Text)
        If ffmpegEsta = False Then
            Falta_ffmpeg()
            Exit Sub
        End If

        Dim videoorigenesta As Boolean = IO.File.Exists(TextBox3.Text)
        If videoorigenesta = False Then
            Falta_videoOrigen()
            Exit Sub
        End If

        Dim archivosalidacoherente As Boolean = IO.Path.IsPathFullyQualified(TextBox5.Text)
        If archivosalidacoherente = False Then
            Falta_archivosalidacoherente()
            Exit Sub
        End If
        If NumericUpDown1.Value > NumericUpDown2.Value Then
            Falta_inicioFinIncoherente()
            Exit Sub
        End If
        'comprobar que no se ha puesto un tiempo oseaaaa eXaJeraO
        Dim duracionNoObtenida As Boolean = (duracionVideoOriginal <= TimeSpan.Zero)

        If duracionNoObtenida = False And
            (NumericUpDown2.Value > duracionVideoOriginal.TotalSeconds) Then
            Falta_FinalSuperiorADuracion()
            Exit Sub
        End If
        TextBox1.Text = My.Settings.Texto_validacionesOK
        Hacer()

    End Sub

    Public Sub Finalizado()
        RestaurarColorValidadores()
        TextBox5.Focus()
    End Sub
#End Region


#Region "funciones auxiliares"

    ''' <summary>
    ''' Te regalo un nombre nuevo único añadíendole la marca de tiempo
    ''' </summary>
    ''' <returns></returns>

    Private Function ObtenerNombreSugerido() As String
        Dim basename As String = TextBox3.Text
        Dim result As String = ""
        If (IO.File.Exists(basename)) Then
            Dim fi As New IO.FileInfo(basename)
            Dim nn As String = fi.Name.Replace(fi.Extension, String.Format("-{0}{1}", DateTime.Now.ToString("ddMMyy-HHmmss"), fi.Extension))
            result = fi.FullName.Replace(fi.Name, nn)
        End If
        Return result
    End Function

    ''' <summary>
    ''' le voy ar güindous y le digo: "olamiamor,tengokablarcontigo.. que yo no quiéro ser tu amánte, que yo quiero ser argo más.."
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ObtenerDuracionTotal()

        Dim dt As TimeSpan = TimeSpan.MinValue
        Try
            dt = GetVideoFileDuration.GetVideoDuration(TextBox3.Text)
        Catch ex As Exception
            TextBox1.AppendText(ex.Message)
        End Try
        If dt <> TimeSpan.MinValue Then
            duracionVideoOriginal = dt
            Label6.Text = String.Format("{0}:{1}{2}", My.Settings.Texto_Duracion, Environment.NewLine, dt.ToString("c"))
            ToolTip1.SetToolTip(Label6, String.Format("{0} {1}", dt.TotalSeconds, My.Settings.Texto_Segundos))
            Label6.Visible = True
            Dim segundos As Integer = dt.TotalSeconds
            If NumericUpDown2.Value > segundos Then
                DateTimePicker2.Value = MinDate().AddSeconds(segundos)
                NumericUpDown2.Value = segundos
            End If

        Else
            Label6.Visible = False
        End If

    End Sub

    Private Function MinDate() As Date
        Return Date.Today
    End Function

#End Region


#Region "validadores"

    Private Sub RestaurarColorValidadores()
        Label5.ForeColor = SystemColors.Info
        Label5.Visible = False
        Label4.ForeColor = SystemColors.Info
        Label4.Visible = False
        Label8.ForeColor = SystemColors.Info
        Label8.Visible = False
        TextBox1.Visible = False
        TextBox1.Text = ""
    End Sub
    ''' <summary>
    ''' Comprueba que el archivo de vídeo seleccionado existe
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If IO.File.Exists(TextBox3.Text) Then
            Label4.ForeColor = Color.DarkSeaGreen
            Label4.Visible = True
            ObtenerDuracionTotal()
        Else
            Label4.ForeColor = Color.MediumVioletRed
            Label4.Visible = True
        End If
    End Sub
    ''' <summary>
    ''' Comprueba si la ruta introducida es a un archivo que existe
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If IO.File.Exists(TextBox2.Text) Then
            Label5.ForeColor = Color.DarkSeaGreen
            Label5.Visible = True
        Else
            Label5.ForeColor = Color.MediumVioletRed
            Label5.Visible = True
        End If
    End Sub
    ''' <summary>
    ''' Comprueba si la ruta destino es una ruta válida
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If IO.Path.IsPathFullyQualified(TextBox5.Text) Then
            Label8.ForeColor = Color.DarkSeaGreen
            Label8.Visible = True
        Else
            Label8.ForeColor = Color.MediumVioletRed
            Label8.Visible = True
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value >= NumericUpDown2.Value Then
            NumericUpDown1.BackColor = Color.MediumVioletRed
            ToolTip1.SetToolTip(NumericUpDown2, $"{My.Settings.Texto_tooltipDuracionFInalIncorrecto}{Environment.NewLine}{My.Settings.Texto_VideoSeleccionadoDuracion} {duracionVideoOriginal:c}")
        Else
            NumericUpDown1.BackColor = Color.DarkSeaGreen
            ToolTip1.SetToolTip(NumericUpDown1, My.Settings.Texto_tooltipDuracionIniciioTexto_tooltipDuracionInicioTexto_tooltipDuracionInicio)
        End If
    End Sub
    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If duracionVideoOriginal.TotalSeconds <= 0 Then Exit Sub
        If duracionVideoOriginal > TimeSpan.MinValue And NumericUpDown2.Value > duracionVideoOriginal.TotalSeconds Then
            NumericUpDown2.BackColor = Color.MediumVioletRed
            ToolTip1.SetToolTip(NumericUpDown2, $"{My.Settings.Texto_DuracionSuperiorVideo}{Environment.NewLine}{My.Settings.Texto_VideoSeleccionadoDuracion}{duracionVideoOriginal:c}")
        Else
            NumericUpDown2.BackColor = Color.DarkSeaGreen

            ToolTip1.SetToolTip(NumericUpDown2, My.Settings.Texto_tooltipDuracionFinal)
        End If
    End Sub


    Private Sub Falta_FinalSuperiorADuracion()
        TextBox1.Text = $"{My.Settings.Texto_corrigeDatos}: {My.Settings.Texto_DuracionFinalSUperiorVideo} "
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_inicioFinIncoherente()
        TextBox1.Text = $"{My.Settings.Texto_corrigeDatos}: {My.Settings.Texto_DuracionInicioInferior}"
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_archivosalidacoherente()
        TextBox1.Text = $"{My.Settings.Texto_corrigeDatos}: {My.Settings.Texto_InvalidoArchivoSalida}"
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_videoOrigen()
        TextBox1.Text = $"{My.Settings.Texto_corrigeDatos}: {My.Settings.Texto_IncorrectoVideoOrigen}"
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_ffmpeg()
        TextBox1.Text = $"{My.Settings.Texto_corrigeDatos}: {My.Settings.Texto_NoSeEncuentraFfmpeg}"
        TextBox1.Visible = True
    End Sub


#End Region

#Region "config"


    Private Sub CargarSettings()
        NumericUpDown2.Value = My.Settings.DuracionPredeterminada.TotalSeconds
        TextBox2.Text = My.Settings.FfmpegPath
    End Sub
    Private Sub GuardarSettings()
        My.Settings.FfmpegPath = TextBox2.Text
        My.Settings.DuracionPredeterminada = TimeSpan.FromSeconds(NumericUpDown2.Value)
    End Sub

#End Region

#Region "acciones de usuario en formulario"

    Private Function FfmpegRutaJuntoApp() As String
        Return Path.Combine(My.Application.Info.DirectoryPath, My.Settings.Texto_ffmpeg_exe)
    End Function




    ''' <summary>
    ''' Descarga ffmpeg y lo coloca junto a la app
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        My.Settings.FfmpegPath = FfmpegRutaJuntoApp()
        TextBox2.Text = My.Settings.FfmpegPath
        TextBox1.Text = My.Settings.Texto_DescargandoFffmpeg
        TextBox1.Visible = True
        Descargarffmpeg()
        Await EsperaTresSegundosYEscondeConsola()
    End Sub

    Private Async Function EsperaTresSegundosYEscondeConsola() As Task
        Await Task.Run(Function()
                           System.Threading.Thread.Sleep(3000)
                           Return Task.CompletedTask
                       End Function)
        TextBox1.Visible = False
    End Function


    ''' <summary>
    ''' Búsqueda automática en las rutas típicas y las carpetas del sistema cómo Program Files y esas cosas, un barrido ligero por el entorno buscándo algo concreto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Es cómo preguntárle a Windows "illo, mhíraten-loh borsilloh a-véh ji ëthá er ffmpeg de los cohöneh puáï"</remarks>
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim rutaJuntoAmi As String = FfmpegRutaJuntoApp()
        If IO.File.Exists(rutaJuntoAmi) Then
            TextBox2.Text = rutaJuntoAmi
            Exit Sub
        End If

        'resultados
        Dim ffmpegEncontrado As Boolean = False
        Dim rutaFfmpeg As String = String.Empty 'como el corazon de mi ex
        'iniciales
        Dim directoriosBaseSistema = [Enum].GetValues(Of Environment.SpecialFolder)()
        'proceso
        For Each directoriobase In directoriosBaseSistema
            Dim path As String = Environment.GetFolderPath(directoriobase)
            For Each variante As String In My.Settings.Rutas_ffmpeg
                'este código es una chapuza que nada tiene que ver con mi trabajao real ¿un bucle for dentro de otro? ¿¡es que nadie va a pensar en la complejidad ciclomática!? y en el código del evento del botón directamente, mi yo profesional me abofetearía, pero ésto es una herramienta tonta y apenas tiene repercusión para las cpus de hoy día. Pero vamos que si eres programador y crees que éste código es chapuzero, estoy al 100% contigo, es una chapuza
                Dim ruta As String = IO.Path.Join(path, variante)
                If IO.File.Exists(ruta) Then
                    'DING DING DING!! SUENA LA FLAUTA!
                    ffmpegEncontrado = True
                    rutaFfmpeg = ruta
                    Exit For
                End If
            Next
            If ffmpegEncontrado Then Exit For
        Next
        'si llegamos aquí, es que tu madre es gorda
        TextBox2.Text = rutaFfmpeg
    End Sub

    ''' <summary>
    ''' Abre un diálogo para que el usuario búsque ffmpeg.exe
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .InitialDirectory = My.Application.Info.DirectoryPath
            .Filter = $"{My.Settings.Texto_ffmpeg_exe.Split(".")(0)}|{My.Settings.Texto_ffmpeg_exe}"
            .Title = $"{My.Settings.Texto_EnbuscaDe}{My.Settings.Texto_ffmpeg_exe}"
            .CheckFileExists = True
            Dim dlgsres As DialogResult = .ShowDialog()
            If dlgsres = DialogResult.OK Then
                TextBox2.Text = .FileName

            End If
        End With


    End Sub

    ''' <summary>
    ''' Abre un diálogo para seleccionar donde guardar el archivo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .InitialDirectory = My.Settings.DirectorioVideos
            .FileName = ObtenerNombreSugerido()
            .Filter = My.Settings.FiltroVideo
            Dim dlgres As DialogResult = .ShowDialog()
            If dlgres = DialogResult.OK Then
                TextBox5.Text = .FileName
            End If
        End With
    End Sub

    Private Function SeleccionarArchivoOrigen() As String
        Return My.Application.SeleccionarArchivoOrigen()
    End Function

    ''' <summary>
    ''' Abre un diálogo para seleccionar el archivo que se va a cortar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim fileorigen As String = SeleccionarArchivoOrigen()
        TextBox3.Text = fileorigen
        ObtenerDuracionTotal()

    End Sub

    ''' <summary>
    ''' Alternar entre usar un formato de tiempo horas:minutos:segundos o usar segundos cómo número entero
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim tiempo As Boolean = CheckBox1.Checked
        DateTimePicker1.Visible = tiempo
        DateTimePicker2.Visible = tiempo
        Dim md = MinDate()
        If DateTimePicker1.Visible = True Then
            DateTimePicker1.Value = md.Add(TimeSpan.FromSeconds(NumericUpDown1.Value))
        End If
        If DateTimePicker2.Visible = True Then
            DateTimePicker2.Value = md.Add(TimeSpan.FromSeconds(NumericUpDown2.Value))
        End If

    End Sub

#End Region

#Region "datos paquí y pallá"

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Dim ts As Integer = 0
        With DateTimePicker2
            ts += .Value.Second
            ts += .Value.Minute * 60
            ts += (.Value.Hour * 60) * 60
        End With
        NumericUpDown2.Value = ts
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim ts As Integer = 0
        With DateTimePicker1
            ts += .Value.Second
            ts += .Value.Minute * 60
            ts += (.Value.Hour * 60) * 60
        End With
        NumericUpDown1.Value = ts
    End Sub

    Private Sub ResizeByMonitorScale()
        'Exit Sub
        Dim escalado As Integer = GetEscalado()
        Dim tamañoDeseado As Size
        Dim tamañoNormal As New Size(1038, 755)
        If escalado = 200 Then
            tamañoDeseado = tamañoNormal
        Else
            tamañoDeseado = New Size((tamañoNormal.Width / 100) * escalado, (tamañoNormal.Height / 100) * escalado)
        End If
        If tamañoDeseado <> Me.Size Then
            Me.Size = tamañoDeseado
        End If

    End Sub

    Private Function GetEscalado() As Integer
        Return (Me.DeviceDpi / 96) * 100
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComprobarTodoOkPaDarle()

    End Sub

    Private Sub Form1_Move(sender As Object, e As EventArgs) Handles Me.Move
        ResizeByMonitorScale()
    End Sub

#End Region

#Region "inicio app y form"

    Public Sub New()
        InitializeComponent()

        DateTimePicker1.MinDate = MinDate()
        DateTimePicker2.MinDate = MinDate()

        DateTimePicker1.Value = MinDate()
        DateTimePicker2.Value = MinDate()

        NotifyIcon1.Text = Me.Text
        NotifyIcon1.Visible = False
        NotifyIcon1.Icon = Me.Icon
        AddHandler NotifyIcon1.Click, AddressOf My.Application.Maximizar

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = My.Settings.FfmpegPath
        DateTimePicker2.Value = Date.Today.Add(My.Settings.DuracionPredeterminada)
        ResizeByMonitorScale()
    End Sub


#End Region

#Region "menu app"

    Private Sub AddMenuHandlemoor()
        AddHandler MinimizarToolStripMenuItem.Click, AddressOf Minimizar
        AddHandler ConfiguraciónToolStripMenuItem.Click, AddressOf Configuracion
        AddHandler DocumentaciónToolStripMenuItem.Click, AddressOf Documentacion
        AddHandler ReportarErrorToolStripMenuItem.Click, AddressOf ReportarError
        AddHandler ActualizarToolStripMenuItem.Click, AddressOf Actualizar
        AddHandler SalirToolStripMenuItem.Click, AddressOf Salir

    End Sub

    Public Sub Minimizar()
        My.Application.Minimizar()
    End Sub
    Public Sub Configuracion()
        My.Application.Configuracion()
    End Sub

    Public Sub Documentacion()
        My.Application.Documentacion()
    End Sub
    Public Sub ReportarError()
        My.Application.ReportarError()
    End Sub

    Public Sub Actualizar()
        My.Application.Actualizar()
    End Sub

    Public Sub Salir()
        My.Application.Salir()
    End Sub

#End Region
    'ffmpeg
    '-ss 00:00:00
    '-to 00:02:59
    '-i "C:\Users\<>\Videos\nombre del video.mp4"
    '-c copy "C:\Users\<>\Videos\nombre del resultado.mp4"




End Class
