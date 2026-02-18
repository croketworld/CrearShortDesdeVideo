Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed. This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

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
        Public Sub Minimizar()

        End Sub
        Public Sub Configuracion()

        End Sub

        Public Sub Documentacion()
            Process.Start(My.Settings.UrlGitHub)
        End Sub
        Public Sub ReportarError()
            ManejoErrores.ReportarError()
        End Sub

        Public Sub Actualizar()

        End Sub

        Public Sub Salir()
            My.Settings.Save()
            Environment.Exit(0)
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            Salir()

        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            ManejoErrores.ReportarError("Excepción no controlada", e.Exception)

        End Sub



    End Class
End Namespace
