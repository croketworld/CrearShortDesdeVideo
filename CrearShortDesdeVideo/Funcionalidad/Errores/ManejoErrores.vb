
Public Class ManejoErrores

    Public Shared Function ReportarError(Optional mensaje As String = "",
                                         Optional errorAcontecido As Exception = Nothing,
                                         Optional adjuntos As String() = Nothing,
                                         Optional email As String = "", Optional esperaRespuesta As Boolean = False)

        Dim frmrepo As New ReportarErrorForm(mensaje, errorAcontecido, adjuntos, email, esperaRespuesta)
        Dim res As DialogResult = frmrepo.ShowDialog()
        If res = DialogResult.OK Then
            Dim reporte As New ReporteError(frmrepo.Mensaje, frmrepo.Fallico, frmrepo.ImagenesAdjuntas, frmrepo.Email, frmrepo.EsperaRespuesta)

        End If

    End Function


End Class
