Public Class ResultadoTarea
    Public Property OK As Boolean
    Public Property Mensaje As String


    Public Sub New(ok As Boolean, mensaje As String)
        Me.OK = ok
        Me.Mensaje = mensaje
    End Sub

    Public Sub New(ok As Boolean)
        Me.OK = ok

    End Sub
    Public Sub New()
        Me.OK = False
        Me.Mensaje = String.Empty
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Mensaje
    End Function

End Class
