<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabelDevCase = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label1.Location = New System.Drawing.Point(12, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(380, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Telerik Code Converter Client for Windows v1.1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LinkLabelDevCase
        '
        Me.LinkLabelDevCase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LinkLabelDevCase.LinkColor = System.Drawing.Color.Black
        Me.LinkLabelDevCase.Location = New System.Drawing.Point(12, 334)
        Me.LinkLabelDevCase.Name = "LinkLabelDevCase"
        Me.LinkLabelDevCase.Size = New System.Drawing.Size(380, 21)
        Me.LinkLabelDevCase.TabIndex = 2
        Me.LinkLabelDevCase.TabStop = True
        Me.LinkLabelDevCase.Text = "http://codecanyon.net/item/DevCase-class-library-for-net/19260282"
        Me.LinkLabelDevCase.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 302)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(380, 37)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Powered by Telerik, and " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DevCase class Library for .NET developers"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.PictureBox1.BackgroundImage = Global.My.Resources.Resources.Elektro
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(16, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(376, 256)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'AboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(404, 361)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LinkLabelDevCase)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About..."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabelDevCase As LinkLabel
    Friend WithEvents Label2 As Label
End Class
