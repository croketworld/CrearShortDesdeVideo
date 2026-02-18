
Public Class ConfiguracionApp_Comportamiento

    Public Property IniciarMinimizado As Boolean
        Get
            Return My.Settings.IniciarMinimizado
        End Get
        Set(value As Boolean)
            My.Settings.IniciarMinimizado = value
        End Set
    End Property
    Public Property Idioma As String
        Get
            Return My.Settings.Idioma
        End Get
        Set(value As Boolean)
            My.Settings.Idioma = value
        End Set
    End Property
    Public Property PosicionFormulario As Point
        Get
            Return My.Settings.PosicionFormulario
        End Get
        Set(value As Point)
            My.Settings.PosicionFormulario = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class


