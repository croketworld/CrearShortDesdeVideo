Public Class ConfiguracionApp

    Public Property Actualizaciones As ConfiguracionApp_Actualizaciones
    Public Property Comportamiento As ConfiguracionApp_Comportamiento
    Public Property Visual As ConfiguracionApp_Visual

    Public Sub New()
        Me.Actualizaciones = New ConfiguracionApp_Actualizaciones
        Me.Comportamiento = New ConfiguracionApp_Comportamiento
        Me.Visual = New ConfiguracionApp_Visual

    End Sub

End Class
