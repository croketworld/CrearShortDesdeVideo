Imports System.Collections.ObjectModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My


    Partial Friend Class MyApplication

        Public Function SeleccionarArchivoOrigen() As String
            Dim ofd As New OpenFileDialog
            Dim filtrovideo As String = My.Settings.FiltroVideo '"Vídeos|*.mp4;*.avi;*.mkv;*.mov;*.wmv;*.flv;*.webm;*.mpeg;*.mpg;*.m4v;*.3gp;*.ts;*.m2ts;*.vob;*.divx;*.ogv;*.asf;*.rm;*.rmvb;*.dat;*.nsv;*.f4v;*.mxf;*.mts;*.m2v;*.svi;*.tp;*.m2t;*.iso;*.m2p;*.mpv2;*.vob;*.vro;*.nsv;*.nuv;*.gxf;*.ps;*.rec;*.tts;*.m2ts;*.m2t;*.m2p;*.m2v;*.m2p;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t;*.m2ts;*.m2v;*.m2t"
            Dim directorioVideos As String = My.Settings.DirectorioVideos
            If IO.Directory.Exists(directorioVideos) = False Then directorioVideos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
            With ofd
                .RestoreDirectory = True
                .CheckFileExists = True
                .Filter = filtrovideo
                .InitialDirectory = directorioVideos
                .Title = My.Settings.Texto_dialogoSeleccionarVideoOrigenTitulo
            End With
            Dim dlgres As DialogResult = ofd.ShowDialog
            If dlgres = DialogResult.OK Then
                Return ofd.FileName
                My.Settings.DirectorioVideos = New IO.FileInfo(ofd.FileName).DirectoryName
            End If
            Return Nothing
        End Function

        Public Sub GetVideoFileDuration(Optional filepath As String = "")
            If IO.File.Exists(filepath) = False Then filepath = SeleccionarArchivoOrigen()
            If IO.File.Exists(filepath) Then
                VideoDurationHelper.GetVideoDuration(filepath)
            End If
        End Sub

        Public Sub Maximizar()
            If MainForm IsNot Nothing Then
                Me.MainForm.WindowState = FormWindowState.Normal
                Me.MainForm.Visible = True
                Me.MainForm.ShowInTaskbar = True
                If Me.MainForm Is Form1 Then
                    Dim frm1 As Form1 = Me.MainForm
                    frm1.NotifyIcon1.Visible = False
                End If

            End If


        End Sub
        Public Sub Minimizar()
            If MainForm IsNot Nothing Then
                Me.MainForm.WindowState = FormWindowState.Minimized
                Me.MainForm.Visible = False
                Me.MainForm.ShowInTaskbar = False
                If Me.MainForm Is Form1 Then
                    Dim frm1 As Form1 = Me.MainForm
                    frm1.NotifyIcon1.Visible = True
                End If
            End If

        End Sub
        Public Sub Configuracion()

        End Sub

        Public Sub Documentacion()
            Process.Start(My.Settings.UrlGitHub)
        End Sub
        Public Sub ReportarError()
            ManejoErrores.ReportarError()
        End Sub

        Public Sub BuscarActualizacion()

        End Sub
        Public Sub Actualizar()

        End Sub
        Private Function ProcesarArgumentos(args As ReadOnlyCollection(Of String)) As Boolean
            If args IsNot Nothing = False Or args.Count <= 0 Then args = New ReadOnlyCollection(Of String)(Environment.GetCommandLineArgs())
            Dim argu As String = ParseArgsHelper.ArgumentsToChorizon(args)

            'TODO argumentos de la línea de comandos
            Return False
        End Function
        Public Sub Iniciar(Optional args As ReadOnlyCollection(Of String) = Nothing)
            Dim debeSalir As Boolean = ProcesarArgumentos(args)
            If debeSalir Then Salir()
            Me.Configapp = New ConfiguracionApp
            CargarConfig()
            If Me.Configapp.Actualizaciones.BuscarActualizacionesAlInicio Then BuscarActualizacion()
        End Sub
        Public Sub Salir()
            My.Settings.Save()
            If IO.File.Exists(ActualizacionDisponible) And Me.Configapp.Actualizaciones.AutoActualizarAlSalir Then Actualizar()
            Environment.Exit(0)
        End Sub

    End Class
End Namespace
