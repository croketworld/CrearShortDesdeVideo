Imports System.IO
Imports System.Net.Http
Imports System.Text.Json
Public Class DescargarDesdeMega

    Public Async Function DownloadFromMegaAsync(megaUrl As String, outputPath As String) As Task(Of Boolean)
        ' Extrae ID del archivo desde la URL
        Dim fileId As String = ExtractMegaFileId(megaUrl)
        If String.IsNullOrEmpty(fileId) Then Return False

        Using client As New HttpClient()
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36")

            ' Paso 1: Obtener info del archivo
            Dim apiUrl As String = $"https://g.api.mega.co.nz/cs?id={fileId}"
            Dim response As String = Await client.GetStringAsync(apiUrl)

            ' Parseo básico (sin Newtonsoft.Json)
            Dim fileInfo As JsonElement = JsonDocument.Parse(response).RootElement(0)
            Dim nodeKey As String = fileInfo.GetProperty("a").GetString()
            Dim size As Long = fileInfo.GetProperty("s").GetInt64()
            Dim ts As String = fileInfo.GetProperty("ts").GetString()

            ' Paso 2: Construir URL de descarga
            Dim downloadUrl As String = $"https://g.api.mega.co.nz/cs"
            Dim postData As String = $"[{{""a"":""g"", ""g"":1, ""p"":""{fileId}""}}]"

            Dim content As New StringContent(postData, Text.Encoding.UTF8, "application/json")
            Dim postResponse As String = Await client.PostAsync(downloadUrl, content).Result.Content.ReadAsStringAsync()

            Dim dlInfo As JsonElement = JsonDocument.Parse(postResponse).RootElement(0)
            Dim dlUrl As String = dlInfo.GetProperty("g").GetString()

            ' Paso 3: Descargar archivo
            Using responseStream As Stream = Await client.GetStreamAsync(dlUrl)
                Using fileStream As New FileStream(outputPath, FileMode.Create)
                    Await responseStream.CopyToAsync(fileStream)
                End Using
            End Using
        End Using

        Return True
    End Function

    Private Shared Function ExtractMegaFileId(url As String) As String
        Dim regex As New Text.RegularExpressions.Regex("/file/([^/#]+)")
        Dim match As Text.RegularExpressions.Match = regex.Match(url)
        Return If(match.Success, match.Groups(1).Value, Nothing)
    End Function

End Class
