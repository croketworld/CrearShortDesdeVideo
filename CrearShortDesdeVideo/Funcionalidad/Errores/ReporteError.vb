Public Class ReporteError

    Public Property Mensaje As String
    Public Property Fallico As Exception
    Public Property Adjuntos As String()
    Public Property Email As String
    Public Property EsperaRespuesta As Boolean
    Public Property UserName As String
    Public Property PcInfo As String


    Public Sub New(mensaje As String, errorAcontecido As Exception, adjuntos As String(), email As String, esperaRespuesta As Boolean)
        Me.Mensaje = mensaje
        Me.Fallico = errorAcontecido
        Me.Adjuntos = adjuntos
        Me.Email = email
        Me.EsperaRespuesta = esperaRespuesta
    End Sub

    Public Sub New()

    End Sub

    Private Sub ObtenerInfoEquipo()
        Me.UserName = My.User.Name
        Me.PcInfo = String.Format("OS:{0}{1}{2}memoria usada/total:{3}/{4}{5}usada por la app:{6}",
                                  My.Computer.Info.OSFullName,
                                  My.Computer.Info.OSVersion,
                                  Environment.NewLine,
                                  My.Computer.Info.AvailablePhysicalMemory,
                                  My.Computer.Info.TotalPhysicalMemory,
                                  Environment.NewLine,
                                  My.Application.Info.WorkingSet)

    End Sub

End Class