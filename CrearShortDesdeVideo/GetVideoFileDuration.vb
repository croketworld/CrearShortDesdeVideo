Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.Pkcs
Imports System.Text.RegularExpressions

Public Class GetVideoFileDuration

    Public Shared Function GetVideoDuration(filePath As String) As TimeSpan
        Return VideoDurationHelper.GetVideoDuration(filePath)
    End Function
End Class
