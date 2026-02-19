Imports System.Text.Encodings.Web

Public Structure CroketWorldConstants

    Public Const UrlManifiestoBase As String = "https://apps.croketworld.online/updates/"

    Public Shared Function GetUrlForAppUpdateManifest(aplicacion As String) As String
        Dim res As String = UrlManifiestoBase
        Dim appName As String = UrlEncoder.Create(New TextEncoderSettings()).Encode(aplicacion)
        res += $"{aplicacion}/"
        Return res
    End Function
    Public Shared Function GetUrlForAppUpdateManifest(aplicacion As String, version As String) As String
        Dim res As String = UrlManifiestoBase
        Dim appName As String = UrlEncoder.Create(New TextEncoderSettings()).Encode(aplicacion)
        res += $"{aplicacion}/{version}/"
        Return res
    End Function


End Structure
