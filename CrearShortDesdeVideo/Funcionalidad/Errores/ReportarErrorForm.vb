Imports System.IO
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports CrearShortDesdeVideo.My
Imports System.ComponentModel

Public Class ReportarErrorForm

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ImagenesAdjuntas As String()

    Public ReadOnly Property Fallico As Exception = Nothing
    Public ReadOnly Property Mensaje As String
        Get
            Return tx_mensaje.Text
        End Get
    End Property
    Public ReadOnly Property Email As String
        Get
            Return tx_mail.Text
        End Get
    End Property
    Public ReadOnly Property EsperaRespuesta As Boolean
        Get
            Return CheckBox1.Checked
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK



    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        tx_mail.Visible = CheckBox1.Checked
    End Sub


    Public Sub New(Optional mensaje As String = "",
                   Optional fallo As Exception = Nothing,
                   Optional adjuntos As String() = Nothing,
                   Optional email As String = "",
                   Optional esperaRespuesta As Boolean = False)
        InitializeComponent()
        Fallico = fallo
        tx_mensaje.Text = mensaje
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        tx_mail.Text = email
        CheckBox1.Checked = esperaRespuesta
        tx_mail.Visible = CheckBox1.Checked
        If adjuntos IsNot Nothing Then
            IncluirAdjuntos(adjuntos)
        End If
        Iniciar()
    End Sub
    Public Sub New()

        InitializeComponent()
        Iniciar()
    End Sub
    Private Sub Iniciar()
        ListView1.Items.Clear()

    End Sub

    Private Sub Bt_imagenes_Click(sender As Object, e As EventArgs) Handles bt_imagenes.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .Multiselect = True
            .Filter = "Imágenes y documentos|*.*"
            .Title = "Adjuntar archivos"
        End With
        Dim res As DialogResult = ofd.ShowDialog()
        If res = DialogResult.OK Then
            IncluirAdjuntos(ofd.FileNames)
        End If

        ll_imagenes.Visible = ImagenesAdjuntas.Count > 0
    End Sub

    Private Sub IncluirAdjuntos(Adjuntos As String())
        Me.ImagenesAdjuntas = Adjuntos
        ListView1.Items.Clear()
        For Each adjunto In Adjuntos
            ListView1.Items.Add(adjunto)
        Next

    End Sub

    Private Sub ll_imagenes_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ll_imagenes.LinkClicked
        If ListView1.Visible = False And ImagenesAdjuntas.Count > 0 Then
            Me.Size = New Size(523, 514)
            ListView1.Visible = True
        Else
            Me.Size = New Size(523, 402)
            ListView1.Visible = False
        End If

    End Sub
    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete And ListView1.CheckedItems.Count > 0 Then
            Dim elementosAQuitarKeys As New List(Of String)
            For Each chekeado As Integer In ListView1.CheckedIndices
                elementosAQuitarKeys.Add(ListView1.Items.Item(chekeado).Text)
            Next
            elementosAQuitarKeys.ForEach(Sub(o)
                                             ListView1.Items.RemoveByKey(o)
                                         End Sub)
        End If
    End Sub
End Class
