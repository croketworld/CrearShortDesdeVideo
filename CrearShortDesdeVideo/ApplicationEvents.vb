Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My


    Partial Friend Class MyApplication


        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            Salir()

        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Me.Configapp = New ConfiguracionApp
            CargarConfig()
            If Me.Configapp.Actualizaciones.BuscarActualizacionesAlInicio Then BuscarActualizacion()
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            ManejoErrores.ReportarError("Excepción no controlada", e.Exception)

        End Sub

        Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
            'TODO aplicar desde config
            e.Font = New Font(New FontFamily("Segoe UI"), 14, FontStyle.Regular)
            e.HighDpiMode = HighDpiMode.PerMonitorV2
            e.ColorMode = SystemColorMode.System
        End Sub
    End Class
End Namespace
