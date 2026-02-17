Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Shell.PropertySystem

Public Class VideoDurationHelper

    Public Shared Function GetVideoDuration(filePath As String) As TimeSpan
        Dim res As TimeSpan = TimeSpan.MinValue
        Using shell As ShellObject = ShellObject.FromParsingName(filePath)
            Dim prop As IShellProperty = shell.Properties.System.Media.Duration
            Dim duration As String = prop.FormatForDisplay(PropertyDescriptionFormatOptions.None)
            res = TimeSpan.Parse(duration)
        End Using
        Return res
    End Function

End Class