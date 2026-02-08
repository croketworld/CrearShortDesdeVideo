Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Security

Public Class Form1

    Private duracionVideoOriginal As TimeSpan

#Region "la chicha"

    Public Sub Hacer()
        Dim cmf As New ComandoFFMPEG(
            TextBox2.Text,
            TextBox3.Text,
            TextBox5.Text,
            TimeSpan.FromSeconds(NumericUpDown1.Value),
            TimeSpan.FromSeconds(NumericUpDown2.Value))
        Dim comandoTxt As String = cmf.ToString()
        Dim ps As New ProcessStartInfo("cmd", comandoTxt) With {
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = False,
            .CreateNoWindow = False,
            .WorkingDirectory = My.Application.Info.DirectoryPath,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True
        }
        Dim fallido As Boolean = True
        Dim exe As Exception = Nothing
        Try
            Dim p = Process.Start(ps)
            Dim output = p.StandardOutput.ReadToEnd()
            Dim fallico = p.StandardError.ReadToEnd()
            If fallico IsNot Nothing Then
                Throw New ApplicationException("Error ejecutando tarea", New ApplicationException(fallico))
            End If
            fallido = False
        Catch ex As Exception
            exe = ex
        End Try
        If fallido Or exe IsNot Nothing Then
            Dim mensaje As String = "Error al ejecutar el comando ffpmeg."
            If exe IsNot Nothing Then
                mensaje += "Detalles del error:" & Environment.NewLine
                mensaje += exe.Message
                If exe.InnerException IsNot Nothing Then
                    mensaje += Environment.NewLine
                    mensaje += exe.InnerException.Message
                End If
                mensaje += $"El comando ejecutado es: {Environment.NewLine}{comandoTxt}"
            End If
            TextBox1.Text = mensaje ' Clipboard.SetText(mensaje) me parece más intrusivo
            TextBox1.Visible = True

        Else
            Finalizado()
        End If


    End Sub


    Private Sub Descargarffmpeg()
        Dim wc As New WebClient
        AddHandler wc.DownloadFileCompleted, AddressOf Descargadoffmpeg
        wc.DownloadFileAsync(New Uri(My.Settings.Urlffmpeg), My.Settings.FfmpegPath)

    End Sub
    Private Sub Descargadoffmpeg()
        TextBox1.Text = "ffmpeg descargado correctamente"
    End Sub
    Private Sub ComprobarTodoOkPaDarle()
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
        If NumericUpDown1.Value < NumericUpDown2.Value Then
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
        Exit Sub 'temporalmente deshabilitado, ésta función secundaria requiere más tiempo del que deseo dárle ahora mismo
        Dim dt As TimeSpan = TimeSpan.MinValue
        Try
            dt = GetVideoFileDuration.GetVideoDuration(TextBox3.Text)
        Catch ex As Exception
            TextBox1.AppendText(ex.Message)
        End Try
        If dt <> TimeSpan.MinValue Then
            duracionVideoOriginal = dt
            Label6.Text = String.Format("Duraación:{0}{1}", Environment.NewLine, dt.ToString("HH:mm:ss"))
            ToolTip1.SetToolTip(Label6, String.Format("{0} segundos", dt.TotalSeconds))
            Label6.Visible = True
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

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If duracionVideoOriginal.TotalSeconds <= 0 Then Exit Sub
        If duracionVideoOriginal > TimeSpan.MinValue And NumericUpDown2.Value >= duracionVideoOriginal.TotalSeconds Then
            NumericUpDown2.BackColor = Color.MediumVioletRed
            ToolTip1.SetToolTip(NumericUpDown2, $"No puedes establecer un tiempo superior a la duración del vídeo.{Environment.NewLine} El vídeo seleccionado tiene una duración de {duracionVideoOriginal:HH:mm:ss}")
        Else
            ToolTip1.SetToolTip(NumericUpDown2, "El momento donde finalizará el nuevo vídeo.")
        End If
    End Sub


    Private Sub Falta_FinalSuperiorADuracion()
        TextBox1.Text = "Corrige datos: La duración establecida es superior a la duración del vídeo original."
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_inicioFinIncoherente()
        TextBox1.Text = "Corrige datos: La duración establecida tiene un valor inferior al inicio."
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_archivosalidacoherente()
        TextBox1.Text = "Corrige datos: El archivo de salida no tiene un formato válido."
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_videoOrigen()
        TextBox1.Text = "Corrige datos: El vídeo de origen no es correcto"
        TextBox1.Visible = True
    End Sub

    Private Sub Falta_ffmpeg()
        TextBox1.Text = "Corrige datos: No se encuerntra ffmpeg."
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

    ''' <summary>
    ''' Descarga ffmpeg y lo coloca junto a la app
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        My.Settings.FfmpegPath = Path.Combine(My.Application.Info.DirectoryPath, "ffmpeg.exe")
        TextBox2.Text = My.Settings.FfmpegPath
        TextBox1.Text = "Descargando ffmpeg.."
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
        Dim rutaJuntoAmi As String = Path.Combine(My.Application.Info.DirectoryPath, "ffmpeg.exe")
        If IO.File.Exists(rutaJuntoAmi) Then
            TextBox2.Text = rutaJuntoAmi
            Exit Sub
        End If

        'resultados
        Dim ffmpegEncontrado As Boolean = False
        Dim rutaFfmpeg As String = String.Empty 'como el corazon de mi ex
        'iniciales
        Dim directoriosBaseSistema = [Enum].GetValues(Of Environment.SpecialFolder)()
        Dim variantes As String() = New String() {
            "\ffmpeg.exe",
            "\ffmpeg\ffmpeg.exe",
            "\ffmpeg\bin\ffmpeg.exe"
        }
        'proceso
        For Each directoriobase In directoriosBaseSistema
            Dim path As String = Environment.GetFolderPath(directoriobase)
            For Each variante As String In variantes
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
            .Filter = "ffmpeg|ffmpeg.exe"
            .Title = "En busca de ffmpeg.exe"
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

    ''' <summary>
    ''' Abre un diálogo para seleccionar el archivo que se va a cortar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ofd As New OpenFileDialog
        Dim filtrovideo As String = My.Settings.FiltroVideo '"Vídeos|*.mp4;*.avi;*.mkv;*.mov;*.wmv;*.flv;*.webm;*.mpeg;*.mpg;*.m4v;*.3gp;*.ts;*.m2ts;*.vob;*.divx;*.ogv;*.asf;*.rm;*.rmvb;*.dat;*.nsv;*.f4v;*.mxf;*.mts;*.m2v;*.svi;*.tp;*.m2t;*.iso;*.m2p;*.mpv2;*.vob;*.vro;*.nsv;*.nuv;*.gxf;*.ps;*.rec;*.tts;*.m2ts;*.m2t;*.m2p;*.m2v;*.m2p;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t"
        Dim directorioVideos As String = My.Settings.DirectorioVideos
        If IO.Directory.Exists(directorioVideos) = False Then directorioVideos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
        With ofd
            .RestoreDirectory = True
            .CheckFileExists = True
            .Filter = filtrovideo
            .InitialDirectory = directorioVideos
            .Title = "Selecciona el vídeo del que quieres obtener un fragmento"
        End With
        Dim dlgres As DialogResult = ofd.ShowDialog
        If dlgres = DialogResult.OK Then
            TextBox3.Text = ofd.FileName
            My.Settings.DirectorioVideos = New IO.FileInfo(ofd.FileName).DirectoryName
            ObtenerDuracionTotal()
        End If


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

#Region "datps paquí y pallá"

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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = My.Settings.FfmpegPath
        DateTimePicker2.Value = Date.Today.Add(My.Settings.DuracionPredeterminada)

    End Sub


    Public Sub New()
        InitializeComponent()

        AddHandler Button1.Click, AddressOf Hacer
        DateTimePicker1.MinDate = MinDate()
        DateTimePicker2.MinDate = MinDate()

        DateTimePicker1.Value = MinDate()
        DateTimePicker2.Value = MinDate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComprobarTodoOkPaDarle()

    End Sub
#End Region


    'ffmpeg
    '-ss 00:00:00
    '-to 00:02:59
    '-i "C:\Users\<>\Videos\nombre del video.mp4"
    '-c copy "C:\Users\<>\Videos\nombre del resultado.mp4"




End Class
