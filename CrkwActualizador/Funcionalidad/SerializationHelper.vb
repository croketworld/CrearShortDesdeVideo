Imports System.Runtime.Serialization.Json

Public Class SerializationHelper


    Public Shared Function Serialize(Of T)(objeto As T) As IO.Stream
        Dim res As IO.Stream = Nothing
        Dim ser As New DataContractJsonSerializer(objeto.GetType())
        Try
            res = New IO.MemoryStream()
            ser.WriteObject(res, objeto)
        Catch

        End Try
        Return res
    End Function

    Public Shared Function Deserialize(Of T)(strim As IO.Stream) As T
        Dim res As T
        Dim ser As New DataContractJsonSerializer(res.GetType())
        Try
            res = ser.ReadObject(strim)
        Catch

        End Try
        Return res
    End Function


End Class
