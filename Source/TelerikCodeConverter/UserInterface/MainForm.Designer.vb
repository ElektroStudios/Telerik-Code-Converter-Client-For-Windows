<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm : Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ScintillaVbInput = New ScintillaNET.Scintilla()
        Me.ScintillaCsOutput = New ScintillaNET.Scintilla()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelNetwork = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelConversionDescription = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBarConverter = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabelConversionStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControlMain = New FlatTabControl.FlatTabControl()
        Me.TabPageCsToVb = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelCsToVb = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelCsInputActions = New System.Windows.Forms.Panel()
        Me.ButtonOpenInVsCsInput = New System.Windows.Forms.Button()
        Me.ButtonSelectAllCsInput = New System.Windows.Forms.Button()
        Me.ButtonCopyAllCsInput = New System.Windows.Forms.Button()
        Me.ButtonCleanCsInput = New System.Windows.Forms.Button()
        Me.PanelVbOutputActions = New System.Windows.Forms.Panel()
        Me.ButtonOpenInVsVbOutput = New System.Windows.Forms.Button()
        Me.ButtonSelectAllVbOutput = New System.Windows.Forms.Button()
        Me.ButtonCopyAllVbOutput = New System.Windows.Forms.Button()
        Me.ButtonCleanVbOutput = New System.Windows.Forms.Button()
        Me.SplitContainerCsToVb = New System.Windows.Forms.SplitContainer()
        Me.ScintillaCsInput = New ScintillaNET.Scintilla()
        Me.ScintillaVbOutput = New ScintillaNET.Scintilla()
        Me.TabPageVbToCs = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanelVbToCs = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelCsOutputActions = New System.Windows.Forms.Panel()
        Me.ButtonOpenInVsCsOutput = New System.Windows.Forms.Button()
        Me.ButtonSelectAllCsOutput = New System.Windows.Forms.Button()
        Me.ButtonCopyAllCsOutput = New System.Windows.Forms.Button()
        Me.ButtonCleanCsOutput = New System.Windows.Forms.Button()
        Me.SplitContainerVbToCs = New System.Windows.Forms.SplitContainer()
        Me.PanelVbInputActions = New System.Windows.Forms.Panel()
        Me.ButtonOpenInVsVbInput = New System.Windows.Forms.Button()
        Me.ButtonSelectAllVbInput = New System.Windows.Forms.Button()
        Me.ButtonCopyAllVbInput = New System.Windows.Forms.Button()
        Me.ButtonCleanVbInput = New System.Windows.Forms.Button()
        Me.TableLayoutPanelAllTabs = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonConvert = New System.Windows.Forms.Button()
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButtonFile = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemOpenInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSaveOutput = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCloseProgram = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButtonColor = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemDarkTheme = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLightTheme = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSystemTheme = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButtonChangeOrientation = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonAbout = New System.Windows.Forms.ToolStripButton()
        Me.NotifyIconMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripSysTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStripMain.SuspendLayout()
        Me.TabControlMain.SuspendLayout()
        Me.TabPageCsToVb.SuspendLayout()
        Me.TableLayoutPanelCsToVb.SuspendLayout()
        Me.PanelCsInputActions.SuspendLayout()
        Me.PanelVbOutputActions.SuspendLayout()
        CType(Me.SplitContainerCsToVb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerCsToVb.Panel1.SuspendLayout()
        Me.SplitContainerCsToVb.Panel2.SuspendLayout()
        Me.SplitContainerCsToVb.SuspendLayout()
        Me.TabPageVbToCs.SuspendLayout()
        Me.TableLayoutPanelVbToCs.SuspendLayout()
        Me.PanelCsOutputActions.SuspendLayout()
        CType(Me.SplitContainerVbToCs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerVbToCs.Panel1.SuspendLayout()
        Me.SplitContainerVbToCs.Panel2.SuspendLayout()
        Me.SplitContainerVbToCs.SuspendLayout()
        Me.PanelVbInputActions.SuspendLayout()
        Me.TableLayoutPanelAllTabs.SuspendLayout()
        Me.ToolStripMain.SuspendLayout()
        Me.ContextMenuStripSysTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'ScintillaVbInput
        '
        Me.ScintillaVbInput.AllowDrop = True
        Me.ScintillaVbInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScintillaVbInput.CaretLineVisible = True
        Me.ScintillaVbInput.CaretPeriod = 200
        Me.ScintillaVbInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScintillaVbInput.Lexer = ScintillaNET.Lexer.Vb
        Me.ScintillaVbInput.Location = New System.Drawing.Point(0, 0)
        Me.ScintillaVbInput.Name = "ScintillaVbInput"
        Me.ScintillaVbInput.ScrollWidth = 382
        Me.ScintillaVbInput.Size = New System.Drawing.Size(427, 385)
        Me.ScintillaVbInput.TabIndex = 0
        Me.ScintillaVbInput.Text = "Write VB code or drop a VB source file into this window..."
        Me.ScintillaVbInput.Zoom = 2
        '
        'ScintillaCsOutput
        '
        Me.ScintillaCsOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScintillaCsOutput.CaretLineVisible = True
        Me.ScintillaCsOutput.CaretPeriod = 200
        Me.ScintillaCsOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScintillaCsOutput.Lexer = ScintillaNET.Lexer.Cpp
        Me.ScintillaCsOutput.Location = New System.Drawing.Point(0, 0)
        Me.ScintillaCsOutput.Name = "ScintillaCsOutput"
        Me.ScintillaCsOutput.ReadOnly = True
        Me.ScintillaCsOutput.ScrollWidth = 125
        Me.ScintillaCsOutput.Size = New System.Drawing.Size(435, 385)
        Me.ScintillaCsOutput.TabIndex = 0
        Me.ScintillaCsOutput.Zoom = 2
        '
        'StatusStripMain
        '
        Me.StatusStripMain.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelNetwork, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabelConversionDescription, Me.ToolStripProgressBarConverter, Me.ToolStripStatusLabelConversionStatus})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 479)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Size = New System.Drawing.Size(944, 22)
        Me.StatusStripMain.TabIndex = 3
        Me.StatusStripMain.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelNetwork
        '
        Me.ToolStripStatusLabelNetwork.Name = "ToolStripStatusLabelNetwork"
        Me.ToolStripStatusLabelNetwork.Size = New System.Drawing.Size(87, 17)
        Me.ToolStripStatusLabelNetwork.Text = "Network Status"
        Me.ToolStripStatusLabelNetwork.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel3.Text = "|"
        '
        'ToolStripStatusLabelConversionDescription
        '
        Me.ToolStripStatusLabelConversionDescription.Name = "ToolStripStatusLabelConversionDescription"
        Me.ToolStripStatusLabelConversionDescription.Size = New System.Drawing.Size(160, 17)
        Me.ToolStripStatusLabelConversionDescription.Text = "Last Code Conversion Status:"
        '
        'ToolStripProgressBarConverter
        '
        Me.ToolStripProgressBarConverter.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStripProgressBarConverter.Name = "ToolStripProgressBarConverter"
        Me.ToolStripProgressBarConverter.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabelConversionStatus
        '
        Me.ToolStripStatusLabelConversionStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripStatusLabelConversionStatus.Name = "ToolStripStatusLabelConversionStatus"
        Me.ToolStripStatusLabelConversionStatus.Size = New System.Drawing.Size(83, 17)
        Me.ToolStripStatusLabelConversionStatus.Text = "{Status Image}"
        '
        'TabControlMain
        '
        Me.TabControlMain.Controls.Add(Me.TabPageCsToVb)
        Me.TabControlMain.Controls.Add(Me.TabPageVbToCs)
        Me.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMain.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlMain.myBackColor = System.Drawing.SystemColors.Control
        Me.TabControlMain.Name = "TabControlMain"
        Me.TabControlMain.SelectedIndex = 0
        Me.TabControlMain.Size = New System.Drawing.Size(944, 420)
        Me.TabControlMain.TabIndex = 4
        '
        'TabPageCsToVb
        '
        Me.TabPageCsToVb.BackColor = System.Drawing.Color.Transparent
        Me.TabPageCsToVb.Controls.Add(Me.TableLayoutPanelCsToVb)
        Me.TabPageCsToVb.Location = New System.Drawing.Point(4, 25)
        Me.TabPageCsToVb.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageCsToVb.Name = "TabPageCsToVb"
        Me.TabPageCsToVb.Size = New System.Drawing.Size(936, 391)
        Me.TabPageCsToVb.TabIndex = 1
        Me.TabPageCsToVb.Text = "C# to VB"
        '
        'TableLayoutPanelCsToVb
        '
        Me.TableLayoutPanelCsToVb.ColumnCount = 3
        Me.TableLayoutPanelCsToVb.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanelCsToVb.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelCsToVb.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanelCsToVb.Controls.Add(Me.PanelCsInputActions, 0, 0)
        Me.TableLayoutPanelCsToVb.Controls.Add(Me.PanelVbOutputActions, 2, 0)
        Me.TableLayoutPanelCsToVb.Controls.Add(Me.SplitContainerCsToVb, 1, 0)
        Me.TableLayoutPanelCsToVb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelCsToVb.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelCsToVb.Name = "TableLayoutPanelCsToVb"
        Me.TableLayoutPanelCsToVb.RowCount = 1
        Me.TableLayoutPanelCsToVb.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelCsToVb.Size = New System.Drawing.Size(936, 391)
        Me.TableLayoutPanelCsToVb.TabIndex = 1
        '
        'PanelCsInputActions
        '
        Me.PanelCsInputActions.AutoSize = True
        Me.PanelCsInputActions.Controls.Add(Me.ButtonOpenInVsCsInput)
        Me.PanelCsInputActions.Controls.Add(Me.ButtonSelectAllCsInput)
        Me.PanelCsInputActions.Controls.Add(Me.ButtonCopyAllCsInput)
        Me.PanelCsInputActions.Controls.Add(Me.ButtonCleanCsInput)
        Me.PanelCsInputActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCsInputActions.Location = New System.Drawing.Point(0, 0)
        Me.PanelCsInputActions.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelCsInputActions.Name = "PanelCsInputActions"
        Me.PanelCsInputActions.Size = New System.Drawing.Size(24, 391)
        Me.PanelCsInputActions.TabIndex = 2
        '
        'ButtonOpenInVsCsInput
        '
        Me.ButtonOpenInVsCsInput.BackgroundImage = Global.My.Resources.Resources.Run
        Me.ButtonOpenInVsCsInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonOpenInVsCsInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonOpenInVsCsInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonOpenInVsCsInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpenInVsCsInput.Location = New System.Drawing.Point(0, 72)
        Me.ButtonOpenInVsCsInput.Name = "ButtonOpenInVsCsInput"
        Me.ButtonOpenInVsCsInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonOpenInVsCsInput.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.ButtonOpenInVsCsInput, "Run Code")
        Me.ButtonOpenInVsCsInput.UseVisualStyleBackColor = True
        '
        'ButtonSelectAllCsInput
        '
        Me.ButtonSelectAllCsInput.BackgroundImage = Global.My.Resources.Resources.Seellect_All
        Me.ButtonSelectAllCsInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonSelectAllCsInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSelectAllCsInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonSelectAllCsInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelectAllCsInput.Location = New System.Drawing.Point(0, 48)
        Me.ButtonSelectAllCsInput.Name = "ButtonSelectAllCsInput"
        Me.ButtonSelectAllCsInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonSelectAllCsInput.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ButtonSelectAllCsInput, "Select all text")
        Me.ButtonSelectAllCsInput.UseVisualStyleBackColor = True
        '
        'ButtonCopyAllCsInput
        '
        Me.ButtonCopyAllCsInput.BackgroundImage = Global.My.Resources.Resources.Clipboard
        Me.ButtonCopyAllCsInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCopyAllCsInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCopyAllCsInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCopyAllCsInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCopyAllCsInput.Location = New System.Drawing.Point(0, 24)
        Me.ButtonCopyAllCsInput.Name = "ButtonCopyAllCsInput"
        Me.ButtonCopyAllCsInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCopyAllCsInput.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ButtonCopyAllCsInput, "Copy all text")
        Me.ButtonCopyAllCsInput.UseVisualStyleBackColor = True
        '
        'ButtonCleanCsInput
        '
        Me.ButtonCleanCsInput.AutoSize = True
        Me.ButtonCleanCsInput.BackgroundImage = Global.My.Resources.Resources.Clear
        Me.ButtonCleanCsInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCleanCsInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCleanCsInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCleanCsInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCleanCsInput.Location = New System.Drawing.Point(0, 0)
        Me.ButtonCleanCsInput.Name = "ButtonCleanCsInput"
        Me.ButtonCleanCsInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCleanCsInput.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ButtonCleanCsInput, "Clear all text")
        Me.ButtonCleanCsInput.UseVisualStyleBackColor = True
        '
        'PanelVbOutputActions
        '
        Me.PanelVbOutputActions.AutoSize = True
        Me.PanelVbOutputActions.Controls.Add(Me.ButtonOpenInVsVbOutput)
        Me.PanelVbOutputActions.Controls.Add(Me.ButtonSelectAllVbOutput)
        Me.PanelVbOutputActions.Controls.Add(Me.ButtonCopyAllVbOutput)
        Me.PanelVbOutputActions.Controls.Add(Me.ButtonCleanVbOutput)
        Me.PanelVbOutputActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelVbOutputActions.Location = New System.Drawing.Point(912, 0)
        Me.PanelVbOutputActions.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelVbOutputActions.Name = "PanelVbOutputActions"
        Me.PanelVbOutputActions.Size = New System.Drawing.Size(24, 391)
        Me.PanelVbOutputActions.TabIndex = 3
        '
        'ButtonOpenInVsVbOutput
        '
        Me.ButtonOpenInVsVbOutput.BackgroundImage = Global.My.Resources.Resources.Run_Gray
        Me.ButtonOpenInVsVbOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonOpenInVsVbOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonOpenInVsVbOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonOpenInVsVbOutput.Enabled = False
        Me.ButtonOpenInVsVbOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpenInVsVbOutput.Location = New System.Drawing.Point(0, 72)
        Me.ButtonOpenInVsVbOutput.Name = "ButtonOpenInVsVbOutput"
        Me.ButtonOpenInVsVbOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonOpenInVsVbOutput.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.ButtonOpenInVsVbOutput, "Run Code")
        Me.ButtonOpenInVsVbOutput.UseVisualStyleBackColor = True
        '
        'ButtonSelectAllVbOutput
        '
        Me.ButtonSelectAllVbOutput.BackgroundImage = Global.My.Resources.Resources.Seellect_All_Gray
        Me.ButtonSelectAllVbOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonSelectAllVbOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSelectAllVbOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonSelectAllVbOutput.Enabled = False
        Me.ButtonSelectAllVbOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelectAllVbOutput.Location = New System.Drawing.Point(0, 48)
        Me.ButtonSelectAllVbOutput.Name = "ButtonSelectAllVbOutput"
        Me.ButtonSelectAllVbOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonSelectAllVbOutput.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.ButtonSelectAllVbOutput, "Select all text")
        Me.ButtonSelectAllVbOutput.UseVisualStyleBackColor = True
        '
        'ButtonCopyAllVbOutput
        '
        Me.ButtonCopyAllVbOutput.BackgroundImage = Global.My.Resources.Resources.Clipboard_Gray
        Me.ButtonCopyAllVbOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCopyAllVbOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCopyAllVbOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCopyAllVbOutput.Enabled = False
        Me.ButtonCopyAllVbOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCopyAllVbOutput.Location = New System.Drawing.Point(0, 24)
        Me.ButtonCopyAllVbOutput.Name = "ButtonCopyAllVbOutput"
        Me.ButtonCopyAllVbOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCopyAllVbOutput.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ButtonCopyAllVbOutput, "Copy all text")
        Me.ButtonCopyAllVbOutput.UseVisualStyleBackColor = True
        '
        'ButtonCleanVbOutput
        '
        Me.ButtonCleanVbOutput.BackgroundImage = Global.My.Resources.Resources.Clear_Gray
        Me.ButtonCleanVbOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCleanVbOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCleanVbOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCleanVbOutput.Enabled = False
        Me.ButtonCleanVbOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCleanVbOutput.Location = New System.Drawing.Point(0, 0)
        Me.ButtonCleanVbOutput.Name = "ButtonCleanVbOutput"
        Me.ButtonCleanVbOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCleanVbOutput.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ButtonCleanVbOutput, "Clear all text")
        Me.ButtonCleanVbOutput.UseVisualStyleBackColor = True
        '
        'SplitContainerCsToVb
        '
        Me.SplitContainerCsToVb.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainerCsToVb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerCsToVb.Location = New System.Drawing.Point(27, 3)
        Me.SplitContainerCsToVb.Name = "SplitContainerCsToVb"
        '
        'SplitContainerCsToVb.Panel1
        '
        Me.SplitContainerCsToVb.Panel1.Controls.Add(Me.ScintillaCsInput)
        '
        'SplitContainerCsToVb.Panel2
        '
        Me.SplitContainerCsToVb.Panel2.Controls.Add(Me.ScintillaVbOutput)
        Me.SplitContainerCsToVb.Size = New System.Drawing.Size(882, 385)
        Me.SplitContainerCsToVb.SplitterDistance = 427
        Me.SplitContainerCsToVb.SplitterWidth = 20
        Me.SplitContainerCsToVb.TabIndex = 0
        '
        'ScintillaCsInput
        '
        Me.ScintillaCsInput.AllowDrop = True
        Me.ScintillaCsInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScintillaCsInput.CaretLineVisible = True
        Me.ScintillaCsInput.CaretPeriod = 200
        Me.ScintillaCsInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScintillaCsInput.Lexer = ScintillaNET.Lexer.Cpp
        Me.ScintillaCsInput.Location = New System.Drawing.Point(0, 0)
        Me.ScintillaCsInput.Name = "ScintillaCsInput"
        Me.ScintillaCsInput.ScrollWidth = 386
        Me.ScintillaCsInput.Size = New System.Drawing.Size(427, 385)
        Me.ScintillaCsInput.TabIndex = 0
        Me.ScintillaCsInput.Text = "Write C# code or drop a C# source file into this window..."
        Me.ScintillaCsInput.Zoom = 2
        '
        'ScintillaVbOutput
        '
        Me.ScintillaVbOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ScintillaVbOutput.CaretLineVisible = True
        Me.ScintillaVbOutput.CaretPeriod = 200
        Me.ScintillaVbOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScintillaVbOutput.Location = New System.Drawing.Point(0, 0)
        Me.ScintillaVbOutput.Name = "ScintillaVbOutput"
        Me.ScintillaVbOutput.ReadOnly = True
        Me.ScintillaVbOutput.ScrollWidth = 125
        Me.ScintillaVbOutput.Size = New System.Drawing.Size(435, 385)
        Me.ScintillaVbOutput.TabIndex = 0
        Me.ScintillaVbOutput.Zoom = 2
        '
        'TabPageVbToCs
        '
        Me.TabPageVbToCs.BackColor = System.Drawing.Color.Transparent
        Me.TabPageVbToCs.Controls.Add(Me.TableLayoutPanelVbToCs)
        Me.TabPageVbToCs.Location = New System.Drawing.Point(4, 25)
        Me.TabPageVbToCs.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageVbToCs.Name = "TabPageVbToCs"
        Me.TabPageVbToCs.Size = New System.Drawing.Size(936, 391)
        Me.TabPageVbToCs.TabIndex = 0
        Me.TabPageVbToCs.Text = "VB to C#"
        '
        'TableLayoutPanelVbToCs
        '
        Me.TableLayoutPanelVbToCs.ColumnCount = 3
        Me.TableLayoutPanelVbToCs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanelVbToCs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelVbToCs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanelVbToCs.Controls.Add(Me.PanelCsOutputActions, 2, 0)
        Me.TableLayoutPanelVbToCs.Controls.Add(Me.SplitContainerVbToCs, 1, 0)
        Me.TableLayoutPanelVbToCs.Controls.Add(Me.PanelVbInputActions, 0, 0)
        Me.TableLayoutPanelVbToCs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelVbToCs.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelVbToCs.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanelVbToCs.Name = "TableLayoutPanelVbToCs"
        Me.TableLayoutPanelVbToCs.RowCount = 1
        Me.TableLayoutPanelVbToCs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelVbToCs.Size = New System.Drawing.Size(936, 391)
        Me.TableLayoutPanelVbToCs.TabIndex = 2
        '
        'PanelCsOutputActions
        '
        Me.PanelCsOutputActions.AutoSize = True
        Me.PanelCsOutputActions.Controls.Add(Me.ButtonOpenInVsCsOutput)
        Me.PanelCsOutputActions.Controls.Add(Me.ButtonSelectAllCsOutput)
        Me.PanelCsOutputActions.Controls.Add(Me.ButtonCopyAllCsOutput)
        Me.PanelCsOutputActions.Controls.Add(Me.ButtonCleanCsOutput)
        Me.PanelCsOutputActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCsOutputActions.Location = New System.Drawing.Point(912, 0)
        Me.PanelCsOutputActions.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelCsOutputActions.Name = "PanelCsOutputActions"
        Me.PanelCsOutputActions.Size = New System.Drawing.Size(24, 391)
        Me.PanelCsOutputActions.TabIndex = 4
        '
        'ButtonOpenInVsCsOutput
        '
        Me.ButtonOpenInVsCsOutput.BackgroundImage = Global.My.Resources.Resources.Run_Gray
        Me.ButtonOpenInVsCsOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonOpenInVsCsOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonOpenInVsCsOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonOpenInVsCsOutput.Enabled = False
        Me.ButtonOpenInVsCsOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpenInVsCsOutput.Location = New System.Drawing.Point(0, 72)
        Me.ButtonOpenInVsCsOutput.Name = "ButtonOpenInVsCsOutput"
        Me.ButtonOpenInVsCsOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonOpenInVsCsOutput.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.ButtonOpenInVsCsOutput, "Run Code")
        Me.ButtonOpenInVsCsOutput.UseVisualStyleBackColor = True
        '
        'ButtonSelectAllCsOutput
        '
        Me.ButtonSelectAllCsOutput.BackgroundImage = Global.My.Resources.Resources.Seellect_All_Gray
        Me.ButtonSelectAllCsOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonSelectAllCsOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSelectAllCsOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonSelectAllCsOutput.Enabled = False
        Me.ButtonSelectAllCsOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelectAllCsOutput.Location = New System.Drawing.Point(0, 48)
        Me.ButtonSelectAllCsOutput.Name = "ButtonSelectAllCsOutput"
        Me.ButtonSelectAllCsOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonSelectAllCsOutput.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ButtonSelectAllCsOutput, "Select all text")
        Me.ButtonSelectAllCsOutput.UseVisualStyleBackColor = True
        '
        'ButtonCopyAllCsOutput
        '
        Me.ButtonCopyAllCsOutput.BackgroundImage = Global.My.Resources.Resources.Clipboard_Gray
        Me.ButtonCopyAllCsOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCopyAllCsOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCopyAllCsOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCopyAllCsOutput.Enabled = False
        Me.ButtonCopyAllCsOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCopyAllCsOutput.Location = New System.Drawing.Point(0, 24)
        Me.ButtonCopyAllCsOutput.Name = "ButtonCopyAllCsOutput"
        Me.ButtonCopyAllCsOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCopyAllCsOutput.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ButtonCopyAllCsOutput, "Copy all text")
        Me.ButtonCopyAllCsOutput.UseVisualStyleBackColor = True
        '
        'ButtonCleanCsOutput
        '
        Me.ButtonCleanCsOutput.AutoSize = True
        Me.ButtonCleanCsOutput.BackgroundImage = Global.My.Resources.Resources.Clear_Gray
        Me.ButtonCleanCsOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCleanCsOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCleanCsOutput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCleanCsOutput.Enabled = False
        Me.ButtonCleanCsOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCleanCsOutput.Location = New System.Drawing.Point(0, 0)
        Me.ButtonCleanCsOutput.Name = "ButtonCleanCsOutput"
        Me.ButtonCleanCsOutput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCleanCsOutput.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ButtonCleanCsOutput, "Clear all text")
        Me.ButtonCleanCsOutput.UseVisualStyleBackColor = True
        '
        'SplitContainerVbToCs
        '
        Me.SplitContainerVbToCs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerVbToCs.Location = New System.Drawing.Point(27, 3)
        Me.SplitContainerVbToCs.Name = "SplitContainerVbToCs"
        '
        'SplitContainerVbToCs.Panel1
        '
        Me.SplitContainerVbToCs.Panel1.Controls.Add(Me.ScintillaVbInput)
        '
        'SplitContainerVbToCs.Panel2
        '
        Me.SplitContainerVbToCs.Panel2.Controls.Add(Me.ScintillaCsOutput)
        Me.SplitContainerVbToCs.Size = New System.Drawing.Size(882, 385)
        Me.SplitContainerVbToCs.SplitterDistance = 427
        Me.SplitContainerVbToCs.SplitterWidth = 20
        Me.SplitContainerVbToCs.TabIndex = 0
        '
        'PanelVbInputActions
        '
        Me.PanelVbInputActions.AutoSize = True
        Me.PanelVbInputActions.Controls.Add(Me.ButtonOpenInVsVbInput)
        Me.PanelVbInputActions.Controls.Add(Me.ButtonSelectAllVbInput)
        Me.PanelVbInputActions.Controls.Add(Me.ButtonCopyAllVbInput)
        Me.PanelVbInputActions.Controls.Add(Me.ButtonCleanVbInput)
        Me.PanelVbInputActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelVbInputActions.Location = New System.Drawing.Point(0, 0)
        Me.PanelVbInputActions.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelVbInputActions.Name = "PanelVbInputActions"
        Me.PanelVbInputActions.Size = New System.Drawing.Size(24, 391)
        Me.PanelVbInputActions.TabIndex = 3
        '
        'ButtonOpenInVsVbInput
        '
        Me.ButtonOpenInVsVbInput.BackgroundImage = Global.My.Resources.Resources.Run
        Me.ButtonOpenInVsVbInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonOpenInVsVbInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonOpenInVsVbInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonOpenInVsVbInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpenInVsVbInput.Location = New System.Drawing.Point(0, 72)
        Me.ButtonOpenInVsVbInput.Name = "ButtonOpenInVsVbInput"
        Me.ButtonOpenInVsVbInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonOpenInVsVbInput.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.ButtonOpenInVsVbInput, "Run Code")
        Me.ButtonOpenInVsVbInput.UseVisualStyleBackColor = True
        '
        'ButtonSelectAllVbInput
        '
        Me.ButtonSelectAllVbInput.BackgroundImage = Global.My.Resources.Resources.Seellect_All
        Me.ButtonSelectAllVbInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonSelectAllVbInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSelectAllVbInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonSelectAllVbInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelectAllVbInput.Location = New System.Drawing.Point(0, 48)
        Me.ButtonSelectAllVbInput.Name = "ButtonSelectAllVbInput"
        Me.ButtonSelectAllVbInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonSelectAllVbInput.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.ButtonSelectAllVbInput, "Select all text")
        Me.ButtonSelectAllVbInput.UseVisualStyleBackColor = True
        '
        'ButtonCopyAllVbInput
        '
        Me.ButtonCopyAllVbInput.BackgroundImage = Global.My.Resources.Resources.Clipboard
        Me.ButtonCopyAllVbInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCopyAllVbInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCopyAllVbInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCopyAllVbInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCopyAllVbInput.Location = New System.Drawing.Point(0, 24)
        Me.ButtonCopyAllVbInput.Name = "ButtonCopyAllVbInput"
        Me.ButtonCopyAllVbInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCopyAllVbInput.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ButtonCopyAllVbInput, "Copy all text")
        Me.ButtonCopyAllVbInput.UseVisualStyleBackColor = True
        '
        'ButtonCleanVbInput
        '
        Me.ButtonCleanVbInput.AutoSize = True
        Me.ButtonCleanVbInput.BackgroundImage = Global.My.Resources.Resources.Clear
        Me.ButtonCleanVbInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCleanVbInput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCleanVbInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCleanVbInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCleanVbInput.Location = New System.Drawing.Point(0, 0)
        Me.ButtonCleanVbInput.Name = "ButtonCleanVbInput"
        Me.ButtonCleanVbInput.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCleanVbInput.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.ButtonCleanVbInput, "Clear all text")
        Me.ButtonCleanVbInput.UseVisualStyleBackColor = True
        '
        'TableLayoutPanelAllTabs
        '
        Me.TableLayoutPanelAllTabs.BackColor = System.Drawing.Color.Silver
        Me.TableLayoutPanelAllTabs.ColumnCount = 1
        Me.TableLayoutPanelAllTabs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelAllTabs.Controls.Add(Me.TabControlMain, 0, 0)
        Me.TableLayoutPanelAllTabs.Controls.Add(Me.ButtonConvert, 0, 1)
        Me.TableLayoutPanelAllTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelAllTabs.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanelAllTabs.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanelAllTabs.Name = "TableLayoutPanelAllTabs"
        Me.TableLayoutPanelAllTabs.RowCount = 2
        Me.TableLayoutPanelAllTabs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelAllTabs.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelAllTabs.Size = New System.Drawing.Size(944, 454)
        Me.TableLayoutPanelAllTabs.TabIndex = 5
        '
        'ButtonConvert
        '
        Me.ButtonConvert.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonConvert.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonConvert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonConvert.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonConvert.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonConvert.Location = New System.Drawing.Point(0, 420)
        Me.ButtonConvert.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonConvert.Name = "ButtonConvert"
        Me.ButtonConvert.Size = New System.Drawing.Size(944, 34)
        Me.ButtonConvert.TabIndex = 0
        Me.ButtonConvert.Text = "CONVERT CODE"
        Me.ButtonConvert.UseVisualStyleBackColor = False
        '
        'ToolStripMain
        '
        Me.ToolStripMain.BackColor = System.Drawing.Color.Gainsboro
        Me.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButtonFile, Me.ToolStripSeparator2, Me.ToolStripDropDownButtonColor, Me.ToolStripButtonChangeOrientation, Me.ToolStripSeparator1, Me.ToolStripButtonAbout})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(944, 25)
        Me.ToolStripMain.TabIndex = 6
        '
        'ToolStripDropDownButtonFile
        '
        Me.ToolStripDropDownButtonFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemOpenInput, Me.ToolStripMenuItemSaveOutput, Me.ToolStripMenuItemCloseProgram})
        Me.ToolStripDropDownButtonFile.Image = Global.My.Resources.Resources.File
        Me.ToolStripDropDownButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButtonFile.Name = "ToolStripDropDownButtonFile"
        Me.ToolStripDropDownButtonFile.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripDropDownButtonFile.Text = "File"
        '
        'ToolStripMenuItemOpenInput
        '
        Me.ToolStripMenuItemOpenInput.Image = Global.My.Resources.Resources.Open
        Me.ToolStripMenuItemOpenInput.Name = "ToolStripMenuItemOpenInput"
        Me.ToolStripMenuItemOpenInput.Size = New System.Drawing.Size(206, 22)
        Me.ToolStripMenuItemOpenInput.Text = "Open Source File..."
        '
        'ToolStripMenuItemSaveOutput
        '
        Me.ToolStripMenuItemSaveOutput.Image = Global.My.Resources.Resources.Save
        Me.ToolStripMenuItemSaveOutput.Name = "ToolStripMenuItemSaveOutput"
        Me.ToolStripMenuItemSaveOutput.Size = New System.Drawing.Size(206, 22)
        Me.ToolStripMenuItemSaveOutput.Text = "Save Conversion To File..."
        '
        'ToolStripMenuItemCloseProgram
        '
        Me.ToolStripMenuItemCloseProgram.Image = Global.My.Resources.Resources.tray_exit
        Me.ToolStripMenuItemCloseProgram.Name = "ToolStripMenuItemCloseProgram"
        Me.ToolStripMenuItemCloseProgram.Size = New System.Drawing.Size(206, 22)
        Me.ToolStripMenuItemCloseProgram.Text = "Close Program"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButtonColor
        '
        Me.ToolStripDropDownButtonColor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemDarkTheme, Me.ToolStripMenuItemLightTheme, Me.ToolStripMenuItemSystemTheme})
        Me.ToolStripDropDownButtonColor.Image = Global.My.Resources.Resources.Color
        Me.ToolStripDropDownButtonColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButtonColor.Name = "ToolStripDropDownButtonColor"
        Me.ToolStripDropDownButtonColor.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripDropDownButtonColor.Text = "Color Theme"
        '
        'ToolStripMenuItemDarkTheme
        '
        Me.ToolStripMenuItemDarkTheme.Image = Global.My.Resources.Resources.Black
        Me.ToolStripMenuItemDarkTheme.Name = "ToolStripMenuItemDarkTheme"
        Me.ToolStripMenuItemDarkTheme.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripMenuItemDarkTheme.Text = "Dark"
        '
        'ToolStripMenuItemLightTheme
        '
        Me.ToolStripMenuItemLightTheme.Image = Global.My.Resources.Resources.White
        Me.ToolStripMenuItemLightTheme.Name = "ToolStripMenuItemLightTheme"
        Me.ToolStripMenuItemLightTheme.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripMenuItemLightTheme.Text = "Light"
        '
        'ToolStripMenuItemSystemTheme
        '
        Me.ToolStripMenuItemSystemTheme.Image = Global.My.Resources.Resources.windows
        Me.ToolStripMenuItemSystemTheme.Name = "ToolStripMenuItemSystemTheme"
        Me.ToolStripMenuItemSystemTheme.Size = New System.Drawing.Size(112, 22)
        Me.ToolStripMenuItemSystemTheme.Text = "System"
        '
        'ToolStripButtonChangeOrientation
        '
        Me.ToolStripButtonChangeOrientation.Image = Global.My.Resources.Resources.Horizontal
        Me.ToolStripButtonChangeOrientation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonChangeOrientation.Name = "ToolStripButtonChangeOrientation"
        Me.ToolStripButtonChangeOrientation.Size = New System.Drawing.Size(131, 22)
        Me.ToolStripButtonChangeOrientation.Text = "Change Orientation"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonAbout
        '
        Me.ToolStripButtonAbout.Image = Global.My.Resources.Resources.About
        Me.ToolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAbout.Name = "ToolStripButtonAbout"
        Me.ToolStripButtonAbout.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButtonAbout.Text = "About..."
        '
        'NotifyIconMain
        '
        Me.NotifyIconMain.ContextMenuStrip = Me.ContextMenuStripSysTray
        Me.NotifyIconMain.Icon = CType(resources.GetObject("NotifyIconMain.Icon"), System.Drawing.Icon)
        Me.NotifyIconMain.Text = "Telerik Code Converter Client for Windows"
        Me.NotifyIconMain.Visible = True
        '
        'ContextMenuStripSysTray
        '
        Me.ContextMenuStripSysTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemHide, Me.ToolStripMenuItemRestore, Me.ToolStripMenuItemExit})
        Me.ContextMenuStripSysTray.Name = "ContextMenuStripSysTray"
        Me.ContextMenuStripSysTray.Size = New System.Drawing.Size(161, 70)
        '
        'ToolStripMenuItemHide
        '
        Me.ToolStripMenuItemHide.Image = Global.My.Resources.Resources.tray_hide
        Me.ToolStripMenuItemHide.Name = "ToolStripMenuItemHide"
        Me.ToolStripMenuItemHide.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItemHide.Text = "Hide Window"
        '
        'ToolStripMenuItemRestore
        '
        Me.ToolStripMenuItemRestore.Image = Global.My.Resources.Resources.tray_show
        Me.ToolStripMenuItemRestore.Name = "ToolStripMenuItemRestore"
        Me.ToolStripMenuItemRestore.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItemRestore.Text = "Restore Window"
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.Image = Global.My.Resources.Resources.tray_exit
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        Me.ToolStripMenuItemExit.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripMenuItemExit.Text = "Close Program"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(944, 501)
        Me.Controls.Add(Me.TableLayoutPanelAllTabs)
        Me.Controls.Add(Me.StatusStripMain)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(520, 360)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Telerik Code Converter Client for Windows - by Elektro Studios"
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.TabControlMain.ResumeLayout(False)
        Me.TabPageCsToVb.ResumeLayout(False)
        Me.TableLayoutPanelCsToVb.ResumeLayout(False)
        Me.TableLayoutPanelCsToVb.PerformLayout()
        Me.PanelCsInputActions.ResumeLayout(False)
        Me.PanelCsInputActions.PerformLayout()
        Me.PanelVbOutputActions.ResumeLayout(False)
        Me.SplitContainerCsToVb.Panel1.ResumeLayout(False)
        Me.SplitContainerCsToVb.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerCsToVb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerCsToVb.ResumeLayout(False)
        Me.TabPageVbToCs.ResumeLayout(False)
        Me.TableLayoutPanelVbToCs.ResumeLayout(False)
        Me.TableLayoutPanelVbToCs.PerformLayout()
        Me.PanelCsOutputActions.ResumeLayout(False)
        Me.PanelCsOutputActions.PerformLayout()
        Me.SplitContainerVbToCs.Panel1.ResumeLayout(False)
        Me.SplitContainerVbToCs.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerVbToCs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerVbToCs.ResumeLayout(False)
        Me.PanelVbInputActions.ResumeLayout(False)
        Me.PanelVbInputActions.PerformLayout()
        Me.TableLayoutPanelAllTabs.ResumeLayout(False)
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ContextMenuStripSysTray.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ScintillaVbInput As ScintillaNET.Scintilla
    Friend WithEvents ScintillaCsOutput As ScintillaNET.Scintilla
    Friend WithEvents StatusStripMain As StatusStrip
    Friend WithEvents ToolStripStatusLabelConversionDescription As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBarConverter As ToolStripProgressBar
    Friend WithEvents TabControlMain As FlatTabControl.FlatTabControl
    Friend WithEvents TabPageVbToCs As TabPage
    Friend WithEvents TabPageCsToVb As TabPage
    Friend WithEvents TableLayoutPanelAllTabs As TableLayoutPanel
    Friend WithEvents SplitContainerCsToVb As SplitContainer
    Friend WithEvents ScintillaCsInput As ScintillaNET.Scintilla
    Friend WithEvents ScintillaVbOutput As ScintillaNET.Scintilla
    Friend WithEvents ButtonConvert As Button
    Friend WithEvents ToolStripMain As ToolStrip
    Friend WithEvents ToolStripDropDownButtonColor As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemDarkTheme As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLightTheme As ToolStripMenuItem
    Friend WithEvents ToolStripButtonAbout As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents NotifyIconMain As NotifyIcon
    Friend WithEvents ToolStripStatusLabelNetwork As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButtonFile As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemOpenInput As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItemSaveOutput As ToolStripMenuItem
    Friend WithEvents ContextMenuStripSysTray As ContextMenuStrip
    Friend WithEvents ToolStripMenuItemRestore As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemHide As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemExit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCloseProgram As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelConversionStatus As ToolStripStatusLabel
    Friend WithEvents TableLayoutPanelCsToVb As TableLayoutPanel
    Friend WithEvents PanelCsInputActions As Panel
    Friend WithEvents ButtonCopyAllCsInput As Button
    Friend WithEvents ButtonCleanCsInput As Button
    Friend WithEvents PanelVbOutputActions As Panel
    Friend WithEvents ButtonCopyAllVbOutput As Button
    Friend WithEvents ButtonCleanVbOutput As Button
    Friend WithEvents ButtonSelectAllCsInput As Button
    Friend WithEvents ButtonSelectAllVbOutput As Button
    Friend WithEvents ButtonOpenInVsCsInput As Button
    Friend WithEvents ButtonOpenInVsVbOutput As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TableLayoutPanelVbToCs As TableLayoutPanel
    Friend WithEvents ButtonOpenInVsCsOutput As Button
    Friend WithEvents ButtonSelectAllCsOutput As Button
    Friend WithEvents ButtonCopyAllCsOutput As Button
    Friend WithEvents ButtonCleanCsOutput As Button
    Friend WithEvents ButtonOpenInVsVbInput As Button
    Friend WithEvents ButtonSelectAllVbInput As Button
    Friend WithEvents ButtonCopyAllVbInput As Button
    Friend WithEvents ButtonCleanVbInput As Button
    Friend WithEvents ToolStripButtonChangeOrientation As ToolStripButton
    Friend WithEvents SplitContainerVbToCs As SplitContainer
    Friend WithEvents PanelCsOutputActions As Panel
    Friend WithEvents PanelVbInputActions As Panel
    Friend WithEvents ToolStripMenuItemSystemTheme As ToolStripMenuItem
End Class
