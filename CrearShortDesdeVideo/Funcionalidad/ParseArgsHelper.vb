Imports System.Collections.ObjectModel

Public Class ParseArgsHelper

    Public Shared Function ArgumentsToChorizon(args As ReadOnlyCollection(Of String)) As String
        Return ArgumentsToChorizon(args.ToArray)
    End Function
    Public Shared Function ArgumentsToChorizon(args As String()) As String
        Return String.Join(" ", args).Trim

    End Function


End Class
