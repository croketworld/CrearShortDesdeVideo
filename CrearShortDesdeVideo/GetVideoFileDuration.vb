Imports System.Runtime.InteropServices

Public Class GetVideoFileDuration
    Public Shared Function GetVideoDuration(filePath As String) As TimeSpan
        Dim CLSID_FilterGraph As New Guid("e436ebb3-524f-11ce-9f53-0020af0ba770")
        Dim IID_IGraphBuilder As New Guid("56a868b1-0ad4-11ce-b03a-0020af0ba770")

        Dim graphPtr As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(IntPtr)))
        Dim hr As Integer = CoCreateInstance(CLSID_FilterGraph, IntPtr.Zero, 1, IID_IGraphBuilder, graphPtr)

        Dim graph As Object = Marshal.GetObjectForIUnknown(graphPtr)
        Dim renderResult As Integer = DirectCast(graph, Object).GetType().InvokeMember("RenderFile", Reflection.BindingFlags.InvokeMethod, Nothing, graph, {filePath, Nothing})

        Dim seekingPtr As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(IntPtr)))
        Dim IID_IMediaSeeking As Guid = New Guid("56a86895-0ad4-11ce-b03a-0020af0ba770")
        hr = QueryInterface(graphPtr, IID_IMediaSeeking, seekingPtr)

        Dim duration As Long = 0
        Dim seekObj As Object = Marshal.GetObjectForIUnknown(seekingPtr)
        Dim durationResult As Integer = seekObj.GetType().InvokeMember("GetDuration", Reflection.BindingFlags.InvokeMethod, Nothing, seekObj, {duration})

        Marshal.ReleaseComObject(seekObj)
        Marshal.ReleaseComObject(graph)

        Return TimeSpan.FromTicks(duration * 10)
    End Function

    <DllImport("ole32.dll")>
    Private Shared Function CoCreateInstance(ByRef rclsid As Guid, pUnkOuter As IntPtr, dwClsContext As Integer, ByRef riid As Guid, <MarshalAs(UnmanagedType.IUnknown)> ByRef ppv As IntPtr) As Integer
    End Function

    <DllImport("ole32.dll")>
    Private Shared Function QueryInterface(pUnk As IntPtr, ByRef riid As Guid, <MarshalAs(UnmanagedType.IUnknown)> ByRef ppv As IntPtr) As Integer
    End Function

End Class
