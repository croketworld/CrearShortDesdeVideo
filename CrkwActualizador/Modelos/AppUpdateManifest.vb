

Imports System.Collections.ObjectModel

Public Class AppUpdateManifest

#Region "propiedades"

    ''' <summary>
    ''' La aplicación
    ''' </summary>
    ''' <returns></returns>
    Public Property Aplicacion As String
    ''' <summary>
    ''' Versión de la aplicación
    ''' </summary>
    ''' <returns></returns>
    Public Property Version As String
    ''' <summary>
    ''' La fecha de publiación/creación de la actualización
    ''' </summary>
    ''' <returns></returns>
    Public Property Fecha As String

    ''' <summary>
    ''' Lista separado por nmueva línea con las notas versión
    ''' </summary>
    ''' <returns></returns>
    Public Property Notas As String

    ''' <summary>
    ''' La url donde está el archivo comprimido con la actualización
    ''' </summary>
    ''' <returns></returns>
    Public Property UrlDescarga As String

#End Region

#Region "funciones de datos"

    Public Function GetNotas() As ReadOnlyCollection(Of String)
        Dim res As New List(Of String)
        res.AddRange(Me.Notas.Trim().Split(Environment.NewLine))
        Return New ReadOnlyCollection(Of String)(res)
    End Function

    Public Function GetFecha() As DateTime
        Dim res As DateTime = Nothing
        DateTime.TryParse(Me.Fecha, res)
        Return res
    End Function

    Public Function GetVersion() As Version
        Dim res As Version = Nothing
        Try
            res = New Version(Me.Version)
        Catch
        End Try
        Return res
    End Function

    Public Function GetUriDescargas() As Uri
        Dim res As Uri = Nothing
        If Uri.IsWellFormedUriString(Me.UrlDescarga, UriKind.RelativeOrAbsolute) Then res = New Uri(Me.UrlDescarga)
        Return res
    End Function

#End Region

#Region "constructores"

    Public Sub New(aplicacion As String, version As String, urldescarga As String, notas() As String)
        Me.Aplicacion = aplicacion
        Me.Version = version
        Me.UrlDescarga = urldescarga
        Me.Notas = String.Join(Environment.NewLine, notas)
        Me.Fecha = DateTime.Now.ToString()
    End Sub

    Public Sub New(aplicacion As String, version As String, urldescarga As String)
        Me.Aplicacion = aplicacion
        Me.Version = version
        Me.UrlDescarga = urldescarga
        Me.Fecha = DateTime.Now.ToString()
    End Sub

    Public Sub New()
        Me.Notas = Nothing
    End Sub

#End Region

#Region "operadores"

    Public Overrides Function ToString() As String
        Return $"{Me.Aplicacion} {Me.Version} {Me.Fecha}"
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If TypeOf obj Is AppUpdateManifest Then
            Dim v2 As AppUpdateManifest = CType(obj, AppUpdateManifest)
            Return Me = v2
        End If
        Return False
    End Function
    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    Public Shared Operator Like(v1 As AppUpdateManifest, aplicacion As String) As Boolean
        Return v1?.Aplicacion = aplicacion
    End Operator
    Public Shared Operator >(v1 As AppUpdateManifest, version As String) As Boolean
        Dim v As New Version(version)
        Return v1?.GetVersion() > v
    End Operator
    Public Shared Operator <(v1 As AppUpdateManifest, version As String) As Boolean
        Dim v As New Version(version)
        Return v1?.GetVersion() < v
    End Operator

    Public Shared Operator >(v1 As AppUpdateManifest, v2 As AppUpdateManifest) As Boolean
        Return v1?.GetVersion() > v2?.GetVersion()
    End Operator
    Public Shared Operator <(v1 As AppUpdateManifest, v2 As AppUpdateManifest) As Boolean
        Return v1?.GetVersion() < v2?.GetVersion()
    End Operator

    Public Shared Operator <>(v1 As AppUpdateManifest, v2 As String) As Boolean
        Return (v1 = v2) = False
    End Operator
    Public Shared Operator =(v1 As AppUpdateManifest, v2 As String) As Boolean
        Return v1?.ToString() = v2
    End Operator

    Public Shared Operator <>(v1 As AppUpdateManifest, v2 As AppUpdateManifest) As Boolean
        Return (v1 = v2) = False
    End Operator
    Public Shared Operator =(v1 As AppUpdateManifest, v2 As AppUpdateManifest) As Boolean
        Return v1?.ToString() = v2?.ToString()
    End Operator


#End Region

End Class
