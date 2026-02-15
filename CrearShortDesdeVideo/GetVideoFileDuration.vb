Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.Pkcs
Imports System.Text.RegularExpressions

Public Class GetVideoFileDuration


    Public Shared Function GetVideoDuration_1(filepath As String) As TimeSpan
        Return VideoDurationHelper.GetVideoDuration(filepath)
    End Function

    Public Shared Function GetVideoDuration_2(filepath As String) As TimeSpan
        Return VideoDurationHelper2.GetVideoDuration(filepath)
    End Function


    Public Shared Function GetVideoDuration(filePath As String) As TimeSpan
        Dim ps As New ProcessStartInfo(My.Settings.FfmpegPath, $"-i {Chr(34)}{filePath}{Chr(34)}")
        ps.UseShellExecute = False
        ps.WorkingDirectory = My.Application.Info.DirectoryPath
        ps.RedirectStandardOutput = True
        ps.RedirectStandardError = True
        Dim duracion As String = ""
        Dim resultado As TimeSpan = TimeSpan.Zero
        Try

            Dim p As Process = Process.Start(ps)
            Dim sr As StreamReader = p.StandardOutput
            Dim sss As Stream = sr.BaseStream
            Dim sr2 As New StreamReader(sss)
            Dim ccc As String = sr2.ReadToEnd()
            If sr.EndOfStream Then


            End If
            Dim contenido = sr.ReadToEnd().Trim()
            p.WaitForExit()
            Dim posi As Integer = contenido.IndexOf("Duration:") + 10
            duracion = contenido.Substring(posi, 8).Trim()
            'Duration: 00:02:59.02
            If duracion.Contains(":"c) Then
                Dim partes() As String = duracion.Split(":")
                If partes.Length = 3 Then
                    Dim horas As Integer = partes(0)
                    Dim minutos As Integer = partes(1)
                    Dim segundos As Integer = partes(2)
                    resultado = New TimeSpan(horas, minutos, segundos)
                End If
            End If
        Catch ex As Exception

        End Try
        Return resultado
    End Function
End Class
