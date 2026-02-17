<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportarErrorForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim ListViewGroup3 As ListViewGroup = New ListViewGroup("Imágenes", HorizontalAlignment.Left)
        Dim ListViewGroup4 As ListViewGroup = New ListViewGroup("Documentos", HorizontalAlignment.Left)
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        Cancel_Button = New Button()
        tx_mensaje = New TextBox()
        Label1 = New Label()
        CheckBox1 = New CheckBox()
        tx_mail = New TextBox()
        bt_imagenes = New Button()
        ll_imagenes = New LinkLabel()
        ListView1 = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ToolTip1 = New ToolTip(components)
        lb_exc = New Label()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0)
        TableLayoutPanel1.Location = New Point(323, 316)
        TableLayoutPanel1.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(170, 33)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' OK_Button
        ' 
        OK_Button.Anchor = AnchorStyles.None
        OK_Button.Location = New Point(4, 3)
        OK_Button.Margin = New Padding(4, 3, 4, 3)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(77, 27)
        OK_Button.TabIndex = 0
        OK_Button.Text = "Aceptar"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = AnchorStyles.None
        Cancel_Button.Location = New Point(89, 3)
        Cancel_Button.Margin = New Padding(4, 3, 4, 3)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(77, 27)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Cancelar"
        ' 
        ' tx_mensaje
        ' 
        tx_mensaje.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tx_mensaje.Location = New Point(25, 27)
        tx_mensaje.Multiline = True
        tx_mensaje.Name = "tx_mensaje"
        tx_mensaje.ScrollBars = ScrollBars.Both
        tx_mensaje.Size = New Size(464, 234)
        tx_mensaje.TabIndex = 1
        ToolTip1.SetToolTip(tx_mensaje, "Escribe aquí tu mensaje, expláyate a tu gusto")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(25, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 15)
        Label1.TabIndex = 2
        Label1.Text = "Mensaje"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(25, 267)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(147, 19)
        CheckBox1.TabIndex = 3
        CheckBox1.Text = "Deseo recibir respuesta"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' tx_mail
        ' 
        tx_mail.Location = New Point(25, 292)
        tx_mail.Name = "tx_mail"
        tx_mail.Size = New Size(147, 23)
        tx_mail.TabIndex = 4
        tx_mail.Text = "Introduce tu email"
        tx_mail.Visible = False
        ' 
        ' bt_imagenes
        ' 
        bt_imagenes.Location = New Point(362, 267)
        bt_imagenes.Name = "bt_imagenes"
        bt_imagenes.Size = New Size(125, 23)
        bt_imagenes.TabIndex = 5
        bt_imagenes.Text = "Adjuntar archivos"
        ToolTip1.SetToolTip(bt_imagenes, "Adjunta imágenes y documentos que ayuden a entender el problema o sugerencia." & vbCrLf & "Recuerda que en total no deben superar los 5Mb por limitaciones del servidor de correo")
        bt_imagenes.UseVisualStyleBackColor = True
        ' 
        ' ll_imagenes
        ' 
        ll_imagenes.AutoSize = True
        ll_imagenes.Location = New Point(370, 292)
        ll_imagenes.Name = "ll_imagenes"
        ll_imagenes.Size = New Size(119, 15)
        ll_imagenes.TabIndex = 6
        ll_imagenes.TabStop = True
        ll_imagenes.Text = "Ver archivos adjuntos"
        ToolTip1.SetToolTip(ll_imagenes, "Muestra la lista de archivos adjuntos")
        ll_imagenes.Visible = False
        ' 
        ' ListView1
        ' 
        ListView1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ListView1.CheckBoxes = True
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader1})
        ListView1.GridLines = True
        ListViewGroup3.Header = "Imágenes"
        ListViewGroup3.Name = "ListViewGroup1"
        ListViewGroup4.Header = "Documentos"
        ListViewGroup4.Name = "ListViewGroup2"
        ListView1.Groups.AddRange(New ListViewGroup() {ListViewGroup3, ListViewGroup4})
        ListView1.Location = New Point(25, 321)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(462, 98)
        ListView1.TabIndex = 7
        ToolTip1.SetToolTip(ListView1, "Para eliminar adjuntos, chekea su casilla y pulsa el botón ""Del"" o ""Supr"" ")
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Archivo"
        ColumnHeader1.Width = 400
        ' 
        ' lb_exc
        ' 
        lb_exc.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lb_exc.Location = New Point(82, 8)
        lb_exc.Name = "lb_exc"
        lb_exc.Size = New Size(407, 16)
        lb_exc.TabIndex = 8
        lb_exc.TextAlign = ContentAlignment.TopCenter
        ToolTip1.SetToolTip(lb_exc, "Excepción capturada")
        ' 
        ' ReportarErrorForm
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(507, 363)
        Controls.Add(lb_exc)
        Controls.Add(ListView1)
        Controls.Add(ll_imagenes)
        Controls.Add(bt_imagenes)
        Controls.Add(tx_mail)
        Controls.Add(CheckBox1)
        Controls.Add(Label1)
        Controls.Add(tx_mensaje)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MaximumSize = New Size(523, 514)
        MinimizeBox = False
        MinimumSize = New Size(523, 402)
        Name = "ReportarErrorForm"
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "ReportarErrorForm"
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents tx_mensaje As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents tx_mail As TextBox
    Friend WithEvents bt_imagenes As Button
    Friend WithEvents ll_imagenes As LinkLabel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lb_exc As Label

End Class
