<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        GroupBox1 = New GroupBox()
        Button5 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        TextBox2 = New TextBox()
        Label5 = New Label()
        Button1 = New Button()
        NumericUpDown1 = New NumericUpDown()
        GroupBox2 = New GroupBox()
        Label6 = New Label()
        Button6 = New Button()
        TextBox3 = New TextBox()
        Label4 = New Label()
        GroupBox3 = New GroupBox()
        DateTimePicker2 = New DateTimePicker()
        DateTimePicker1 = New DateTimePicker()
        Label2 = New Label()
        NumericUpDown2 = New NumericUpDown()
        CheckBox1 = New CheckBox()
        Label1 = New Label()
        GroupBox4 = New GroupBox()
        Button2 = New Button()
        TextBox5 = New TextBox()
        Label8 = New Label()
        ToolTip1 = New ToolTip(components)
        Label3 = New Label()
        Label7 = New Label()
        TextBox1 = New TextBox()
        PictureBox1 = New PictureBox()
        GroupBox1.SuspendLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Button5)
        GroupBox1.Controls.Add(Button4)
        GroupBox1.Controls.Add(Button3)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.ForeColor = SystemColors.Info
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Margin = New Padding(4, 5, 4, 5)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(4, 5, 4, 5)
        GroupBox1.Size = New Size(1012, 119)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Ruta al ejecutable ffmpeg"
        ' 
        ' Button5
        ' 
        Button5.BackColor = SystemColors.ControlDark
        Button5.Location = New Point(790, 46)
        Button5.Margin = New Padding(4, 5, 4, 5)
        Button5.Name = "Button5"
        Button5.Size = New Size(53, 57)
        Button5.TabIndex = 6
        Button5.Text = "??"
        ToolTip1.SetToolTip(Button5, resources.GetString("Button5.ToolTip"))
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.ControlDark
        Button4.Location = New Point(720, 46)
        Button4.Margin = New Padding(4, 5, 4, 5)
        Button4.Name = "Button4"
        Button4.Size = New Size(53, 57)
        Button4.TabIndex = 5
        Button4.Text = "|||"
        ToolTip1.SetToolTip(Button4, "Pulsa éste botón para que la aplicación búsque automáticamente en las rutas típicas donde debería estar")
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.ControlDark
        Button3.Location = New Point(650, 46)
        Button3.Margin = New Padding(4, 5, 4, 5)
        Button3.Name = "Button3"
        Button3.Size = New Size(53, 57)
        Button3.TabIndex = 4
        Button3.Text = "..."
        ToolTip1.SetToolTip(Button3, "Abrir diálogo para buscar ffmpeg.exe")
        Button3.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = SystemColors.ControlDark
        TextBox2.Location = New Point(18, 46)
        TextBox2.Margin = New Padding(4, 5, 4, 5)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(620, 57)
        TextBox2.TabIndex = 3
        ToolTip1.SetToolTip(TextBox2, resources.GetString("TextBox2.ToolTip"))
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Transparent
        Label5.Location = New Point(18, 84)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(622, 30)
        Label5.TabIndex = 7
        Label5.Text = "----------------------------------------------------------------------------"
        Label5.TextAlign = ContentAlignment.TopCenter
        Label5.Visible = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.BackColor = SystemColors.ActiveCaption
        Button1.Font = New Font("Segoe UI", 10.875F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(772, 568)
        Button1.Margin = New Padding(4, 5, 4, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(226, 97)
        Button1.TabIndex = 3
        Button1.Text = "Crear vídeo corto"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.BackColor = SystemColors.ControlDark
        NumericUpDown1.ForeColor = SystemColors.Info
        NumericUpDown1.Location = New Point(343, 71)
        NumericUpDown1.Margin = New Padding(4, 5, 4, 5)
        NumericUpDown1.Maximum = New Decimal(New Integer() {Integer.MaxValue, 0, 0, 0})
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(176, 57)
        NumericUpDown1.TabIndex = 5
        ToolTip1.SetToolTip(NumericUpDown1, "El momento donde iniciará el nuevo vídeo.")
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label6)
        GroupBox2.Controls.Add(Button6)
        GroupBox2.Controls.Add(TextBox3)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Dock = DockStyle.Top
        GroupBox2.ForeColor = SystemColors.Info
        GroupBox2.Location = New Point(0, 119)
        GroupBox2.Margin = New Padding(4, 5, 4, 5)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(4, 5, 4, 5)
        GroupBox2.Size = New Size(1012, 122)
        GroupBox2.TabIndex = 6
        GroupBox2.TabStop = False
        GroupBox2.Text = "Ruta al archivo original"
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Location = New Point(816, 20)
        Label6.Name = "Label6"
        Label6.Size = New Size(182, 102)
        Label6.TabIndex = 7
        Label6.Text = "Duración:" & vbCrLf & "1:23:45"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ToolTip1.SetToolTip(Label6, "Ésta es la duración que tiene el vídeo original")
        Label6.Visible = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = SystemColors.ControlDark
        Button6.Location = New Point(650, 47)
        Button6.Margin = New Padding(4, 5, 4, 5)
        Button6.Name = "Button6"
        Button6.Size = New Size(53, 57)
        Button6.TabIndex = 5
        Button6.Text = "..."
        ToolTip1.SetToolTip(Button6, "Abrir un diálogo para buscar un vídeo")
        Button6.UseVisualStyleBackColor = False
        ' 
        ' TextBox3
        ' 
        TextBox3.BackColor = SystemColors.ControlDark
        TextBox3.ForeColor = SystemColors.Info
        TextBox3.Location = New Point(18, 47)
        TextBox3.Margin = New Padding(4, 5, 4, 5)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(620, 57)
        TextBox3.TabIndex = 3
        ToolTip1.SetToolTip(TextBox3, "La ruta del archivo de vídeo del que se va a extraer un tramo en un nuevo archivo de vídeo")
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Transparent
        Label4.Location = New Point(18, 82)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(622, 30)
        Label4.TabIndex = 6
        Label4.Text = "----------------------------------------------------------------------------"
        Label4.TextAlign = ContentAlignment.TopCenter
        Label4.Visible = False
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(DateTimePicker2)
        GroupBox3.Controls.Add(DateTimePicker1)
        GroupBox3.Controls.Add(Label2)
        GroupBox3.Controls.Add(NumericUpDown2)
        GroupBox3.Controls.Add(CheckBox1)
        GroupBox3.Controls.Add(Label1)
        GroupBox3.Controls.Add(NumericUpDown1)
        GroupBox3.Dock = DockStyle.Top
        GroupBox3.ForeColor = SystemColors.Info
        GroupBox3.Location = New Point(0, 241)
        GroupBox3.Margin = New Padding(4, 5, 4, 5)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(4, 5, 4, 5)
        GroupBox3.Size = New Size(1012, 143)
        GroupBox3.TabIndex = 7
        GroupBox3.TabStop = False
        GroupBox3.Text = "Desde y hasta donde cortar"
        ToolTip1.SetToolTip(GroupBox3, "En ésta fila selecciona que tramo cortar, indicando un inicio y un final." & vbCrLf & "Puedes alternar si hacerlo en segundos o con formato horas:minutos:segundos marcando la casilla de Modo")
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        DateTimePicker2.Format = DateTimePickerFormat.Time
        DateTimePicker2.Location = New Point(824, 69)
        DateTimePicker2.MinDate = New Date(2026, 2, 6, 0, 0, 0, 0)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(176, 57)
        DateTimePicker2.TabIndex = 11
        ToolTip1.SetToolTip(DateTimePicker2, "El momento donde finalizará el nuevo vídeo.")
        DateTimePicker2.Value = New Date(2026, 2, 6, 0, 0, 0, 0)
        DateTimePicker2.Visible = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Format = DateTimePickerFormat.Time
        DateTimePicker1.Location = New Point(339, 71)
        DateTimePicker1.MinDate = New Date(2026, 2, 6, 0, 0, 0, 0)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(176, 57)
        DateTimePicker1.TabIndex = 10
        ToolTip1.SetToolTip(DateTimePicker1, "El momento donde iniciará el nuevo vídeo.")
        DateTimePicker1.Value = New Date(2026, 2, 6, 0, 0, 0, 0)
        DateTimePicker1.Visible = False
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Location = New Point(513, 71)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(311, 51)
        Label2.TabIndex = 8
        Label2.Text = "Hasta el segundo"
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        NumericUpDown2.BackColor = SystemColors.ControlDark
        NumericUpDown2.ForeColor = SystemColors.Info
        NumericUpDown2.Location = New Point(847, 69)
        NumericUpDown2.Margin = New Padding(4, 5, 4, 5)
        NumericUpDown2.Maximum = New Decimal(New Integer() {Integer.MaxValue, 23283, 0, 0})
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(135, 57)
        NumericUpDown2.TabIndex = 7
        ToolTip1.SetToolTip(NumericUpDown2, "El momento donde finalizará el nuevo vídeo.")
        ' 
        ' CheckBox1
        ' 
        CheckBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CheckBox1.AutoSize = True
        CheckBox1.BackColor = Color.Transparent
        CheckBox1.Location = New Point(636, 13)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(300, 55)
        CheckBox1.TabIndex = 6
        CheckBox1.Text = "Modo h:mm:ss"
        ToolTip1.SetToolTip(CheckBox1, "Alternar entre usar un formato de tiempo horas:minutos:segundos o usar segundos cómo número entero")
        CheckBox1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(13, 71)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(322, 51)
        Label1.TabIndex = 6
        Label1.Text = "Desde el segundo"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(Button2)
        GroupBox4.Controls.Add(TextBox5)
        GroupBox4.Controls.Add(Label8)
        GroupBox4.Dock = DockStyle.Top
        GroupBox4.ForeColor = SystemColors.Info
        GroupBox4.Location = New Point(0, 384)
        GroupBox4.Margin = New Padding(4, 5, 4, 5)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(4, 5, 4, 5)
        GroupBox4.Size = New Size(1012, 129)
        GroupBox4.TabIndex = 8
        GroupBox4.TabStop = False
        GroupBox4.Text = "Ruta al archivo de salida"
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ControlDark
        Button2.Location = New Point(650, 48)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(53, 57)
        Button2.TabIndex = 5
        Button2.Text = "..."
        ToolTip1.SetToolTip(Button2, resources.GetString("Button2.ToolTip"))
        Button2.UseVisualStyleBackColor = False
        ' 
        ' TextBox5
        ' 
        TextBox5.BackColor = SystemColors.ControlDark
        TextBox5.ForeColor = SystemColors.Info
        TextBox5.Location = New Point(13, 48)
        TextBox5.Margin = New Padding(4, 5, 4, 5)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(620, 57)
        TextBox5.TabIndex = 3
        ToolTip1.SetToolTip(TextBox5, "El nuevo archivo que se va a crear")
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.Transparent
        Label8.Location = New Point(11, 81)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(622, 30)
        Label8.TabIndex = 7
        Label8.Text = "----------------------------------------------------------------------------"
        Label8.TextAlign = ContentAlignment.TopCenter
        Label8.Visible = False
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label3.Location = New Point(10, 712)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(988, 193)
        Label3.TabIndex = 9
        Label3.Text = " +-+-+-+-+-+-+-+-+-+-+-+" & vbCrLf & " |C|r|o|k|e|t|W|o|r|l|d|" & vbCrLf & " +-+-+-+-+-+-+-+-+-+-+-+"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.Transparent
        Label7.Dock = DockStyle.Top
        Label7.Font = New Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(0, 513)
        Label7.Name = "Label7"
        Label7.Size = New Size(1012, 36)
        Label7.TabIndex = 10
        Label7.Text = "Todos los datos deben ser correctos antes de pulsar el botón"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = SystemColors.ControlDark
        TextBox1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.ForeColor = SystemColors.Info
        TextBox1.Location = New Point(15, 568)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.ScrollBars = ScrollBars.Both
        TextBox1.Size = New Size(590, 97)
        TextBox1.TabIndex = 11
        TextBox1.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.InitialImage = My.Resources.Resources.logo
        PictureBox1.Location = New Point(53, 750)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(100, 100)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 12
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(192F, 192F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.ControlDarkDark
        ClientSize = New Size(1012, 684)
        Controls.Add(PictureBox1)
        Controls.Add(TextBox1)
        Controls.Add(Label7)
        Controls.Add(Label3)
        Controls.Add(GroupBox4)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(Button1)
        Controls.Add(GroupBox1)
        Font = New Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.Info
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        MaximumSize = New Size(1200, 970)
        MinimumSize = New Size(1038, 755)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Crear Short desde vídeo"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox

End Class
