Public Class ConfiguracionApp_Actualizaciones

    Public Property BuscarActualizacionesAlInicio As Boolean
        Get
            Return My.Settings.BuscarActualizacionesAlInicio
        End Get
        Set(value As Boolean)
            My.Settings.BuscarActualizacionesAlInicio = value
        End Set
    End Property
    Public Property AutoActualizarAlSalir As Boolean
        Get
            Return My.Settings.ActualizarAlSalir
        End Get
        Set(value As Boolean)
            My.Settings.ActualizarAlSalir = value
        End Set
    End Property
    Public Sub New()

    End Sub

End Class
