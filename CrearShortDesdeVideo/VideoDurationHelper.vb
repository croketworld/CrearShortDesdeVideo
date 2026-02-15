Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class VideoDurationHelper

    <ComImport(), Guid("56a868b1-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IGraphBuilder
        Function AddFilter(<[In]> pFilter As IBaseFilter, <[In], MarshalAs(UnmanagedType.LPWStr)> pName As String) As Integer
        Function RemoveFilter(<[In]> pFilter As IBaseFilter) As Integer
        Function EnumFilters(<[In], [Out]> ByRef ppEnum As IEnumFilters) As Integer
        Function FindFilterByName(<[In], MarshalAs(UnmanagedType.LPWStr)> pName As String, <[In], [Out]> ByRef ppFilter As IBaseFilter) As Integer
        Function ConnectDirect(<[In]> pinOut As IPin, <[In]> pinIn As IPin, <[In]> pmt As IntPtr) As Integer
        Function Reconnect(<[In]> ppin As IPin) As Integer
        Function Disconnect(<[In]> ppin As IPin) As Integer
        Function SetDefaultSyncSource() As Integer
        Function RenderFile(<[In], MarshalAs(UnmanagedType.LPWStr)> lpcwstrFile As String, <[In], MarshalAs(UnmanagedType.LPWStr)> lpcwstrPlayList As String) As Integer
        Function AddSourceFilter(<[In], MarshalAs(UnmanagedType.LPWStr)> lpcwstrFileName As String, <[In], MarshalAs(UnmanagedType.LPWStr)> lpcwstrFilterName As String, <[In], [Out]> ByRef ppFilter As IBaseFilter) As Integer
        Function SetLogFile(hFile As IntPtr) As Integer
        Function Abort() As Integer
        Function ShouldOperationContinue() As Integer
    End Interface

    <ComImport(), Guid("56a86895-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IMediaSeeking
        Function GetCapabilities(<[In], [Out]> ByRef pCapabilities As Integer) As Integer
        Function CheckCapabilities(<[In], [Out]> ByRef pCapabilities As Integer) As Integer
        Function IsFormatSupported(pFormat As IntPtr) As Integer
        Function QueryPreferredFormat(<[In], [Out]> ByRef pFormat As IntPtr) As Integer
        Function GetTimeFormat(<[In], [Out]> ByRef pFormat As IntPtr) As Integer
        Function IsUsingTimeFormat(pFormat As IntPtr) As Integer
        Function SetTimeFormat(constFormat As IntPtr) As Integer
        Function GetDuration(<[In], [Out]> ByRef pDuration As Long) As Integer
        Function GetStopPosition(<[In], [Out]> ByRef pStop As Long) As Integer
        Function GetCurrentPosition(<[In], [Out]> ByRef pCurrent As Long) As Integer
        Function ConvertTimeFormat(<[In], [Out]> ByRef pTarget As Long, pTargetFormat As IntPtr, SourceTime As Long, pSourceFormat As IntPtr) As Integer
        Function SetPositions(<[In], [Out]> ByRef piStart As Long, dwSeekFlags As Integer, <[In], [Out]> ByRef piStop As Long, dwStopSeekFlags As Integer) As Integer
        Function GetPositions(<[In], [Out]> ByRef pCurrent As Long, <[In], [Out]> ByRef pStop As Long) As Integer
        Function GetAvailable(<[In], [Out]> ByRef pEarliest As Long, <[In], [Out]> ByRef pLatest As Long) As Integer
        Function SetRate(dRate As Double) As Integer
        Function GetRate(<[In], [Out]> ByRef pdRate As Double) As Integer
        Function GetPreroll(<[In], [Out]> ByRef pllPreroll As Long) As Integer
    End Interface

    <ComImport(), Guid("56a8689f-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IBaseFilter
        ' Métodos omitidos para brevedad
    End Interface

    <ComImport(), Guid("56a86892-0ad4-11ce-b03a-0020af0ba770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IEnumFilters
        Function [Next](cFilters As Integer, <[In], [Out], MarshalAs(UnmanagedType.LPArray)> filter As IBaseFilter(), <[In], [Out]> ByRef cFetched As Integer) As Integer
        Function Skip(cFilters As Integer) As Integer
        Function Reset() As Integer
        Function Clone(<[In], [Out]> ByRef ppEnum As IEnumFilters) As Integer
    End Interface

    <ComImport(), Guid("e436ebb3-524f-11ce-9f53-0020af0ba770"), CoClass(GetType(FilterGraph))>
    Private Interface FilterGraphCoClass
        Inherits IGraphBuilder
    End Interface

    <ComImport(), Guid("e436ebb3-524f-11ce-9f53-0020af0ba770")>
    Private Class FilterGraph
    End Class

    Public Shared Function GetVideoDuration(filePath As String) As TimeSpan
        Dim graphBuilder As IGraphBuilder = Nothing
        Dim mediaSeeking As IMediaSeeking = Nothing
        Try
            graphBuilder = New FilterGraph()
            mediaSeeking = CType(graphBuilder, IMediaSeeking)

            Dim hr As Integer = graphBuilder.RenderFile(filePath, Nothing)
            If hr <> 0 Then Throw New Exception($"Error al cargar el archivo: {hr:X}")

            Dim duration As Long = 0
            hr = mediaSeeking.GetDuration(duration)
            If hr <> 0 Then Throw New Exception($"Error al obtener duración: {hr:X}")

            Return TimeSpan.FromTicks(duration * 10) ' Convierte unidades de 100ns a ticks
        Finally
            If mediaSeeking IsNot Nothing Then Marshal.ReleaseComObject(mediaSeeking)
            If graphBuilder IsNot Nothing Then Marshal.ReleaseComObject(graphBuilder)
        End Try
    End Function
End Class

Public Interface IPin
End Interface

Public Class VideoDurationHelper2

    Public Shared Function GetVideoDuration(filePath As String) As TimeSpan
        Dim CLSID_FilterGraph As New Guid("e436ebb3-524f-11ce-9f53-0020af0ba770")
        Dim IID_IGraphBuilder As New Guid("56a868b1-0ad4-11ce-b03a-0020af0ba770")

        Dim graphPtr As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(IntPtr)))
        Dim hr As Integer = CoCreateInstance(CLSID_FilterGraph, IntPtr.Zero, 1, IID_IGraphBuilder, graphPtr)

        Dim graph As Object = Marshal.GetObjectForIUnknown(graphPtr)
        Dim renderResult As Integer = DirectCast(graph, Object).GetType().InvokeMember("RenderFile", Reflection.BindingFlags.InvokeMethod, Nothing, graph, {filePath, Nothing})

        Dim seekingPtr As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(GetType(IntPtr)))
        Dim IID_IMediaSeeking As New Guid("56a86895-0ad4-11ce-b03a-0020af0ba770")
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