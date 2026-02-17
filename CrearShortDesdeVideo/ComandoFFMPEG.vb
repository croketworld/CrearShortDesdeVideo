Public Class ComandoFFMPEG

    Public Const DefaultShortMaxDuration As Integer = 179

    Public Overrides Function ToString() As String
        Return _
            String.Format("{0} {1} {2} {3} {4} ""{5}"" {6} ""{7}""",
                Me.TiempoInicio_Prefijo, Me.TiempoInicio,
                Me.TiempoFin_Prefijo, Me.TiempoFin,
                Me.ArchivoOrigen_Prefijo,
                Me.ArchivoOrigen,
                Me.ArchivoSalida_Prefijo,
                Me.ArchivoSalida
            )

        'ffmpeg
        '-ss 00:00:00
        '-to 00:02:59
        '-i "C:\Users\<>\Videos\nombre del video.mp4"
        '-c copy "C:\Users\<>\Videos\nombre del resultado.mp4"
    End Function
    Public Property RutaEjecutableFFMPEG As String
    Public Property TiempoInicio As TimeSpan
    Public Property TiempoFin As TimeSpan
    Public Property ArchivoOrigen As String
    Public Property ArchivoSalida As String

    Private ReadOnly Property TiempoInicio_Prefijo As String = "-ss"
    Private ReadOnly Property TiempoFin_Prefijo As String = "-to"
    Private ReadOnly Property ArchivoOrigen_Prefijo As String = "-i"
    Private ReadOnly Property ArchivoSalida_Prefijo As String = "-c copy"


    Public Sub New(rutaFfmpeg As String,
                   rutaArchivoOrigen As String,
                   rutaArchivoSalida As String,
                   tiempoInicio As TimeSpan,
                  Optional tiempoFin As TimeSpan = Nothing)

        Me.RutaEjecutableFFMPEG = rutaFfmpeg
        Me.ArchivoOrigen = rutaArchivoOrigen
        Me.ArchivoSalida = rutaArchivoSalida
        Me.TiempoInicio = tiempoInicio
        Me.TiempoFin = IIf(tiempoFin <> Nothing, tiempoFin, TimeSpan.FromSeconds(DefaultShortMaxDuration))

    End Sub

    Public Sub New()

    End Sub


End Class