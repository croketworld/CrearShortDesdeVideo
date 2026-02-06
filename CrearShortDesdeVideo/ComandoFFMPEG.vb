Public Class ComandoFFMPEG

    Public Const DefaultShortMaxDuration As Integer = 179

    Public Overrides Function ToString() As String
        Return _
            String.Format("{0}{1}{2} {3} {4} {5} {6} {7} {8}{9}{10} {11} {12}{13}{14}",
                Chr(34), Me.RutaEjecutableFFMPEG, Chr(34),
                Me.TiempoInicio_Prefijo, Me.TiempoInicio,
                Me.TiempoFin_Prefijo, Me.TiempoFin,
                Me.ArchivoOrigen_Prefijo,
                Chr(34), Me.ArchivoOrigen, Chr(34),
                Me.ArchivoSalida_Prefijo,
                Chr(34), Me.ArchivoSalida_Prefijo, Chr(34)
            )
    End Function
    Public Property RutaEjecutableFFMPEG As String
    Public Property TiempoInicio As TimeSpan
    Public Property TiempoFin As TimeSpan
    Public Property ArchivoOrigen As String
    Public Property ArchivoSalida As String

    Private ReadOnly Property TiempoInicio_Prefijo As String = "-ss"
    Private ReadOnly Property TiempoFin_Prefijo As String = "-to"
    Private ReadOnly Property ArchivoOrigen_Prefijo As String = "-i"
    Private ReadOnly Property ArchivoSalida_Prefijo As String = "-c copy "


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