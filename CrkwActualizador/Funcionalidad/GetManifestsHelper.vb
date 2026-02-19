Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http.Headers
Imports System.Runtime.Serialization.Json

Public Class GetManifestsHelper

    Private Shared tempfilePath As String

    Public Shared LastAppUpdateManifestDownloaded As AppUpdateManifest

    Public Shared Sub GetAppUpdateManifest(aplicacion As String, version As String)
        Dim url As String = CroketWorldConstants.GetUrlForAppUpdateManifest(aplicacion, version)
        GetAppUpdateManifest(New Uri(url))
    End Sub

    Public Shared Sub GetAppUpdateManifest(aplicacion As String)
        Dim url As String = CroketWorldConstants.GetUrlForAppUpdateManifest(aplicacion)
        GetAppUpdateManifest(New Uri(url))
    End Sub

    Private Shared Sub GetAppUpdateManifest(url As Uri)
#Disable Warning SYSLIB0014 ' El tipo o el miembro están obsoletos
        Using wc As New WebClient
#Enable Warning SYSLIB0014 ' El tipo o el miembro están obsoletos
            tempfilePath = Path.GetTempFileName()
            LastAppUpdateManifestDownloaded = Nothing
            AddHandler wc.DownloadFileCompleted, AddressOf AppupdatemanifestDownloaded
            wc.DownloadFileAsync(url, tempfilePath)
        End Using
    End Sub

    Private Shared Function DeserializeAppUpdateManfiest() As AppUpdateManifest
        If IO.File.Exists(tempfilePath) = False Then Exit Function
        Dim res As New AppUpdateManifest

        Dim ser As New DataContractJsonSerializer(res.GetType())
        Dim fs As IO.FileStream = Nothing
        Try
            fs = New FileStream(tempfilePath, FileMode.Open)
            res = ser.ReadObject(fs)
        Catch

        End Try
        If fs IsNot Nothing Then
            fs.Close()
            fs.Dispose()
        End If
        Return res
    End Function

    Private Shared Sub AppupdatemanifestDownloaded(sender As Object, e As AsyncCompletedEventArgs)
        Dim res = DeserializeAppUpdateManfiest()
        LastAppUpdateManifestDownloaded = res
    End Sub



End Class
