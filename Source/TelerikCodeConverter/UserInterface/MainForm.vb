




' THIS OPEN-SOURCE APPLICATION IS POWERED BY DEVCASE CLASS LIBRARY BY ELEKTRO STUDIOS.

' IF YOU LIKED THIS FREE APPLICATION, THEN PLEASE CONSIDER TO BUY DEVCASE CLASS LIBRARY FOR .NET AT:
' https://codecanyon.net/item/DevCase-class-library-for-net/19260282

' YOU CAN FIND THESE HELPER METHODS AND A MASSIVE AMOUNT MORE!, 
' +850 EXTENSION METHODS FOR ALL KIND OF TYPES, CUSTOM USER-CONTROLS, 
' EVERYTHING FOR THE NEWBIE And THE ADVANCED USER, FOR VB.NET AND C#. 

' DevCase is a utility framework containing new APIs and extensions to the core .NET Framework 
' to help complete your developer toolbox.
' It Is a set of general purpose classes provided as easy to consume packages.
' These utility classes and components provide productivity in day to day software development 
' mainly focused To WindowsForms. 

' UPDATES OF DevCase ARE MAINTAINED AND RELEASED EVERY MONTH.





#Region " Imports "

Imports DevCase.Application.UserInterface.Types
Imports DevCase.Core.Application.UserInterface.Tools
Imports DevCase.Core.Extensions.[SplitContainer]
Imports DevCase.Core.Interop.CodeDOM
Imports DevCase.Core.Interop.CodeDOM.TelerikUtil
Imports DevCase.Core.IO.Tools
Imports DevCase.Core.NET.Tools
Imports DevCase.Core.NET.Types.EventArgs
Imports DevCase.ThirdParty.ScintillaNet.Tools

Imports ScintillaNET

#End Region

''' ----------------------------------------------------------------------------------------------------
''' <summary>
''' The main <see cref="Form"/>.
''' </summary>
''' ----------------------------------------------------------------------------------------------------
Friend NotInheritable Class MainForm : Inherits Form

#Region " Private Fields "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' The current <see cref="TelerikCodeConverterMethod"/> value.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private currentCodeConverterMethod As TelerikCodeConverterMethod

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' The <see cref="WindowMagnetizer"/> instance.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private magnetizer As WindowMagnetizer

#End Region

#Region " Event Handlers "

#Region " Form "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Form.Load"/> event of the <see cref="MainForm"/> form.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.BuildScintillaControls()

        If Not My.Settings.WindowSize.IsEmpty Then
            Me.Size = My.Settings.WindowSize
        End If

        If Not My.Settings.WindowsPosition.IsEmpty Then
            Me.Location = My.Settings.WindowsPosition
        End If

        If Me.SplitContainerCsToVb.Orientation <> My.Settings.Orientation Then
            Me.ChangeOrientation()
        End If

        ' I assign this here and not in the Form's designer just to be able find the control with ease.
        Me.ToolStripStatusLabelConversionStatus.DisplayStyle = ToolStripItemDisplayStyle.Image

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Form.Shown"/> event of the <see cref="MainForm"/> form.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown

        ' Enable screen corner sticker feature.
        Me.magnetizer = New WindowMagnetizer(Me) With {
             .Enabled = True,
             .AllowOffscreen = True,
             .Threshold = 30
         }

        ' Update network connection status.
        AddHandler NetworkUtil.NetworkStatusChanged, AddressOf Me.NetworkStatusChangedHandler
        Me.UpdateNetworkStatus(NetworkUtil.IsNetworkAvailable)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Form.FormClosing"/> event of the <see cref="MainForm"/> form.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="FormClosingEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim f As Form = DirectCast(sender, Form)

        ' Save window size and location.
        Select Case f.WindowState

            Case FormWindowState.Normal
                My.Settings.WindowSize = f.Size
                My.Settings.WindowsPosition = f.Location

            Case Else ' Maximized, Minimized
                My.Settings.WindowSize = f.RestoreBounds.Size
                My.Settings.WindowsPosition = f.RestoreBounds.Location

        End Select

    End Sub

#End Region

#Region " Common Controls "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonConvert"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonConvert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonConvert.Click

        Me.TryConversion()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="FlatTabControl.FlatTabControl.SelectedIndexChanged"/> event of the <see cref="MainForm.TabControlMain"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub TabControlMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControlMain.SelectedIndexChanged

        Dim tabpageIndex As Integer = DirectCast(sender, FlatTabControl.FlatTabControl).SelectedIndex
        Me.currentCodeConverterMethod = DirectCast(tabpageIndex, TelerikCodeConverterMethod)

        Me.EnableOrDisableInputButtons()
        Me.EnableOrDisableOutputButtons()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="FlatTabControl.FlatTabControl.Resize"/> event of the <see cref="MainForm.TabControlMain"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub TabControlMain_Resize(sender As Object, e As EventArgs) Handles TabControlMain.Resize

        Dim tb As FlatTabControl.FlatTabControl = DirectCast(sender, FlatTabControl.FlatTabControl)

        ' Removes TabControl borders (Left, Right and Bottom).
        tb.Region = New Region(New RectangleF(tb.Left + SystemInformation.FrameBorderSize.Width,
                                              tb.Top,
                                              tb.Width - (SystemInformation.FrameBorderSize.Width * 2),
                                              tb.Height - SystemInformation.FrameBorderSize.Height))

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Scintilla.TextChanged"/> event of the 
    ''' <see cref="MainForm.ScintillaCsInput"/> and <see cref="MainForm.ScintillaVbInput"/> controls.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ScintillaInput_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles ScintillaCsInput.TextChanged,
            ScintillaVbInput.TextChanged

        Me.EnableOrDisableInputButtons()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Scintilla.TextChanged"/> event of the 
    ''' <see cref="MainForm.ScintillaCsOutput"/> and <see cref="MainForm.ScintillaVbOutput"/> controls.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ScintillaOutput_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles ScintillaCsOutput.TextChanged,
            ScintillaVbOutput.TextChanged

        Me.EnableOrDisableOutputButtons()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Scintilla.DragEnter"/> event of the 
    ''' <see cref="MainForm.ScintillaCsInput"/> and <see cref="MainForm.ScintillaVbInput"/> controls.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="DragEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ScintillaInput_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) _
    Handles ScintillaCsInput.DragEnter,
            ScintillaVbInput.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim files As IEnumerable(Of String) = DirectCast(e.Data.GetData(DataFormats.FileDrop), IEnumerable(Of String))
            If (files.Count <> 1) Then
                e.Effect = DragDropEffects.None

            Else
                Select Case Me.currentCodeConverterMethod
                    Case TelerikCodeConverterMethod.CSharpToVisualBasic
                        Select Case Path.GetExtension(files.Single()).ToLower()
                            Case ".cs", ".txt"
                                e.Effect = DragDropEffects.All
                            Case Else
                                e.Effect = DragDropEffects.None
                        End Select

                    Case TelerikCodeConverterMethod.VisualBasicToCSharp
                        Select Case Path.GetExtension(files.Single()).ToLower()
                            Case ".vb", ".txt"
                                e.Effect = DragDropEffects.All
                            Case Else
                                e.Effect = DragDropEffects.None
                        End Select

                End Select

            End If

        Else
            e.Effect = DragDropEffects.None

        End If

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Scintilla.DragDrop"/> event of the 
    ''' <see cref="MainForm.ScintillaCsInput"/> and <see cref="MainForm.ScintillaVbInput"/> controls.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="DragEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ScintillaInput_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) _
    Handles ScintillaCsInput.DragDrop,
            ScintillaVbInput.DragDrop

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim filepath As String = DirectCast(e.Data.GetData(DataFormats.FileDrop), IEnumerable(Of String)).Single()

            DirectCast(sender, Scintilla).Text = File.ReadAllText(filepath, Encoding.UTF8)

        End If

    End Sub

#End Region

#Region " Panel Buttons for C# Input Scintilla "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCleanCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanCsInput_Click(sender As Object, e As EventArgs) Handles ButtonCleanCsInput.Click

        Me.ScintillaCsInput.ClearAll()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCopyAllCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllCsInput_Click(sender As Object, e As EventArgs) Handles ButtonCopyAllCsInput.Click

        Clipboard.SetText(Me.ScintillaCsInput.Text, TextDataFormat.Text)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonSelectAllCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllCsInput_Click(sender As Object, e As EventArgs) Handles ButtonSelectAllCsInput.Click

        Me.ScintillaCsInput.SelectAll()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonOpenInVsCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioCsInput_Click(sender As Object, e As EventArgs) Handles ButtonOpenInVsCsInput.Click

        Dim fi As FileInfo = Files.GetTempFile("cs")
        File.WriteAllText(fi.FullName, Me.ScintillaCsInput.Text, Encoding.UTF8)

        Try
            Process.Start(fi.FullName)
        Catch ex As Exception
            ' Do Nothing.
        End Try

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCleanCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanCsInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCleanCsInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clear, My.Resources.Clear_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCopyAllCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllCsInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCopyAllCsInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clipboard, My.Resources.Clipboard_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonSelectAllCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllCsInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonSelectAllCsInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Seellect_All, My.Resources.Seellect_All_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonOpenInVsCsInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioCsInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonOpenInVsCsInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Run, My.Resources.Run_Gray)

    End Sub

#End Region

#Region " Panel Buttons for C# Output Scintilla "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCleanCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanCsOutput_Click(sender As Object, e As EventArgs) Handles ButtonCleanCsOutput.Click

        Me.ScintillaCsOutput.ReadOnly = False
        Me.ScintillaCsOutput.ClearAll()
        Me.ScintillaCsOutput.ReadOnly = True

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCopyAllCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllCsOutput_Click(sender As Object, e As EventArgs) Handles ButtonCopyAllCsOutput.Click

        Clipboard.SetText(Me.ScintillaCsOutput.Text, TextDataFormat.Text)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonSelectAllCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllCsOutput_Click(sender As Object, e As EventArgs) Handles ButtonSelectAllCsOutput.Click

        Me.ScintillaCsOutput.SelectAll()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonOpenInVsCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioCsOutput_Click(sender As Object, e As EventArgs) Handles ButtonOpenInVsCsOutput.Click

        Dim fi As FileInfo = Files.GetTempFile("cs")
        File.WriteAllText(fi.FullName, Me.ScintillaCsOutput.Text, Encoding.UTF8)

        Try
            Process.Start(fi.FullName)
        Catch ex As Exception
            ' Do Nothing.
        End Try

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCleanCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanCsOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCleanCsOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clear, My.Resources.Clear_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCopyAllCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllCsOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCopyAllCsOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clipboard, My.Resources.Clipboard_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonSelectAllCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllCsOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonSelectAllCsOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Seellect_All, My.Resources.Seellect_All_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonOpenInVsCsOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioCsOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonOpenInVsCsOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Run, My.Resources.Run_Gray)

    End Sub

#End Region

#Region " Panel Buttons for VB Input Scintilla "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCleanVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanVbInput_Click(sender As Object, e As EventArgs) Handles ButtonCleanVbInput.Click

        Me.ScintillaVbInput.ClearAll()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCopyAllVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllVbInput_Click(sender As Object, e As EventArgs) Handles ButtonCopyAllVbInput.Click

        Clipboard.SetText(Me.ScintillaVbInput.Text, TextDataFormat.Text)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonSelectAllVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllVbInput_Click(sender As Object, e As EventArgs) Handles ButtonSelectAllVbInput.Click

        Me.ScintillaVbInput.SelectAll()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonOpenInVsVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioVbInput_Click(sender As Object, e As EventArgs) Handles ButtonOpenInVsVbInput.Click

        Dim fi As FileInfo = Files.GetTempFile("vb")
        File.WriteAllText(fi.FullName, Me.ScintillaVbInput.Text, Encoding.UTF8)

        Try
            Process.Start(fi.FullName)
        Catch ex As Exception
            ' Do Nothing.
        End Try

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCleanVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanVbInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCleanVbInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clear, My.Resources.Clear_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCopyAllVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllVbInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCopyAllVbInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clipboard, My.Resources.Clipboard_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonSelectAllVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllVbInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonSelectAllVbInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Seellect_All, My.Resources.Seellect_All_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonOpenInVsVbInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioVbInput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonOpenInVsVbInput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Run, My.Resources.Run_Gray)

    End Sub

#End Region

#Region " Panel Buttons for VB Output Scintilla "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCleanVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanVbOutput_Click(sender As Object, e As EventArgs) Handles ButtonCleanVbOutput.Click

        Me.ScintillaVbOutput.ReadOnly = False
        Me.ScintillaVbOutput.ClearAll()
        Me.ScintillaVbOutput.ReadOnly = True

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonCopyAllVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllVbOutput_Click(sender As Object, e As EventArgs) Handles ButtonCopyAllVbOutput.Click

        Clipboard.SetText(Me.ScintillaVbOutput.Text, TextDataFormat.Text)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonSelectAllVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllVbOutput_Click(sender As Object, e As EventArgs) Handles ButtonSelectAllVbOutput.Click

        Me.ScintillaVbOutput.SelectAll()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.Click"/> event of the <see cref="MainForm.ButtonOpenInVsVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioVbOutput_Click(sender As Object, e As EventArgs) Handles ButtonOpenInVsVbOutput.Click

        Dim fi As FileInfo = Files.GetTempFile("vb")
        File.WriteAllText(fi.FullName, Me.ScintillaVbOutput.Text, Encoding.UTF8)

        Try
            Process.Start(fi.FullName)
        Catch ex As Exception
            ' Do Nothing.
        End Try

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCleanVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCleanVbOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCleanVbOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clear, My.Resources.Clear_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonCopyAllVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonCopyAllVbOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonCopyAllVbOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Clipboard, My.Resources.Clipboard_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonSelectAllVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonSelectAllVbOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonSelectAllVbOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Seellect_All, My.Resources.Seellect_All_Gray)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Button.EnabledChanged"/> event of the <see cref="MainForm.ButtonOpenInVsVbOutput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ButtonOpenInVisualStudioVbOutput_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonOpenInVsVbOutput.EnabledChanged

        Dim bt As Button = DirectCast(sender, Button)

        bt.BackgroundImage = If(bt.Enabled, My.Resources.Run, My.Resources.Run_Gray)

    End Sub

#End Region

#Region " ToolStrip Main "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripDropDownButton.DropDownOpening"/> event of the <see cref="MainForm.ToolStripDropDownButtonFile"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripDropDownButtonFile_DropDownOpening(sender As Object, e As EventArgs) Handles ToolStripDropDownButtonFile.DropDownOpening

        Select Case Me.currentCodeConverterMethod

            Case TelerikCodeConverterMethod.CSharpToVisualBasic
                Me.ToolStripMenuItemSaveOutput.Enabled =
                    Not String.IsNullOrEmpty(Me.ScintillaVbOutput.Text) AndAlso
                    Not Me.ScintillaVbOutput.Text.StartsWith("CONVERSION ERROR", StringComparison.OrdinalIgnoreCase)

            Case TelerikCodeConverterMethod.VisualBasicToCSharp
                Me.ToolStripMenuItemSaveOutput.Enabled =
                    Not String.IsNullOrEmpty(Me.ScintillaCsOutput.Text) AndAlso
                    Not Me.ScintillaCsOutput.Text.StartsWith("CONVERSION ERROR", StringComparison.OrdinalIgnoreCase)

        End Select

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="MainForm.ToolStripMenuItemOpenInput"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripMenuItemOpenInput_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemOpenInput.Click

        Using ofd As New OpenFileDialog()

            Select Case Me.currentCodeConverterMethod

                Case TelerikCodeConverterMethod.CSharpToVisualBasic
                    With ofd
                        .AutoUpgradeEnabled = True
                        .CheckFileExists = True
                        .CheckPathExists = True
                        .FileName = ""
                        .Filter = "Plain Text Files (UTF-8)|*.txt|C# Files|*.cs|All suported files|*.txt;*.cs"
                        .FilterIndex = 3
                        .Multiselect = False
                        .RestoreDirectory = True
                        .Title = "Select a C# source-code file to open."
                    End With
                    If ofd.ShowDialog() = DialogResult.OK Then
                        Me.ScintillaCsInput.SuspendLayout()
                        Me.ScintillaCsInput.Text = File.ReadAllText(ofd.FileName, Encoding.UTF8)
                        Me.ScintillaCsInput.ResumeLayout()
                    End If

                Case TelerikCodeConverterMethod.VisualBasicToCSharp
                    With ofd
                        .AutoUpgradeEnabled = True
                        .CheckFileExists = True
                        .CheckPathExists = True
                        .FileName = ""
                        .Filter = "Plain Text Files (UTF-8)|*.txt|Visual Basic Files|*.vb|All suported files|*.txt;*.vb"
                        .FilterIndex = 3
                        .Multiselect = False
                        .RestoreDirectory = True
                        .Title = "Select a Visual Basic source-code file to open."
                    End With
                    If ofd.ShowDialog() = DialogResult.OK Then
                        Me.ScintillaVbInput.SuspendLayout()
                        Me.ScintillaVbInput.Text = File.ReadAllText(ofd.FileName, Encoding.UTF8)
                        Me.ScintillaVbInput.ResumeLayout()
                    End If

            End Select

        End Using

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripDropDownButton.DropDownOpening"/> event of the <see cref="MainForm.ToolStripDropDownButtonFile"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripMenuItemSaveOutput_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSaveOutput.Click

        Using sfd As New SaveFileDialog()

            Select Case Me.currentCodeConverterMethod

                Case TelerikCodeConverterMethod.CSharpToVisualBasic
                    With sfd
                        .AddExtension = True
                        .AutoUpgradeEnabled = True
                        .CheckPathExists = True
                        .DefaultExt = "cs"
                        .FileName = "File"
                        .Filter = "Plain Text Files|*.txt|Visual Basic Files|*.vb|All suported files|*.txt;*.vb"
                        .FilterIndex = 2
                        .RestoreDirectory = True
                        .Title = "Select a file destination to save the C# source-code."
                    End With
                    If sfd.ShowDialog() = DialogResult.OK Then
                        File.WriteAllText(sfd.FileName, Me.ScintillaVbOutput.Text, Encoding.UTF8)
                    End If

                Case TelerikCodeConverterMethod.VisualBasicToCSharp
                    With sfd
                        .AddExtension = True
                        .AutoUpgradeEnabled = True
                        .CheckPathExists = True
                        .DefaultExt = "vb"
                        .FileName = "File"
                        .Filter = "Plain Text Files|*.txt|C# Files|*.cs|All suported files|*.txt;*.cs"
                        .FilterIndex = 2
                        .RestoreDirectory = True
                        .Title = "Select a file destination to save the VB.NET source-code."
                    End With
                    If sfd.ShowDialog() = DialogResult.OK Then
                        File.WriteAllText(sfd.FileName, Me.ScintillaCsOutput.Text, Encoding.UTF8)
                    End If

            End Select

        End Using

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripButton.Click"/> event of the <see cref="MainForm.ToolStripMenuItemCloseProgram"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripMenuItemCloseProgram_Click(sender As Object, e As EventArgs) _
    Handles ToolStripMenuItemCloseProgram.Click

        Me.Close()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="MainForm.ToolStripMenuItemDarkTheme"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub DarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDarkTheme.Click

        My.Settings.ColorTheme = 0

        Me.SetDarkColorTheme()
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="MainForm.ToolStripMenuItemLightTheme"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub LightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLightTheme.Click

        My.Settings.ColorTheme = 1

        Me.SetLightColorTheme()
    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripMenuItem.Click"/> event of the <see cref="MainForm.ToolStripMenuItemSystemTheme"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripMenuItemSystemTheme_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSystemTheme.Click

        My.Settings.ColorTheme = 2

        Me.SetSystemColorTheme()

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripButton.Click"/> event of the <see cref="MainForm.ToolStripButtonAbout"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripButtonAbout_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAbout.Click

        Using aboutform As New AboutForm()
            aboutform.ShowDialog(Me)
        End Using

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripButton.Click"/> event of the <see cref="MainForm.ToolStripButtonChangeOrientation"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripButtonChangeView_Click(sender As Object, e As EventArgs) Handles ToolStripButtonChangeOrientation.Click

        Me.ChangeOrientation()

    End Sub

#End Region

#Region " ContextMenu System-Tray "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Windows.Forms.ContextMenuStrip.Opening"/> event of the <see cref="MainForm.ContextMenuStripSysTray"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="CancelEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ContextMenuStripSysTray_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripSysTray.Opening

        Me.ToolStripMenuItemHide.Enabled = Me.Visible
        Me.ToolStripMenuItemRestore.Enabled = Not Me.ToolStripMenuItemHide.Enabled

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Windows.Forms.ContextMenuStrip.MouseDoubleClick"/> event of the <see cref="MainForm.ContextMenuStripSysTray"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="MouseEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub NotifyIconMain_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIconMain.MouseDoubleClick

        If Me.Visible Then
            GraphicalInterfaceUtil.MinimizeToSystray(Me, Me.NotifyIconMain)

        Else
            GraphicalInterfaceUtil.RestoreFromSystray(Me, Me.NotifyIconMain)

        End If

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripButton.Click"/> event of the <see cref="MainForm.ToolStripMenuItemHide"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripMenuItemHide_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemHide.Click

        GraphicalInterfaceUtil.MinimizeToSystray(Me, Me.NotifyIconMain)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripButton.Click"/> event of the <see cref="MainForm.ToolStripMenuItemRestore"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripMenuItemRestore_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRestore.Click

        GraphicalInterfaceUtil.RestoreFromSystray(Me, Me.NotifyIconMain)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="ToolStripButton.Click"/> event of the <see cref="MainForm.ToolStripMenuItemExit"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="e">
    ''' The <see cref="EventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ToolStripMenuItemExit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click

        Me.Close()

    End Sub

#End Region

#Region " Network Status "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="NetworkUtil.NetworkStatusChanged"/> event.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The sender.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="NetworkStatusChangedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub NetworkStatusChangedHandler(ByVal sender As Object, e As NetworkStatusChangedEventArgs)

        Me.UpdateNetworkStatus(e.IsAvailable)

    End Sub

#End Region

#End Region

#Region " Private Methods "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Tries the source-code conversion.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Async Sub TryConversion()

        Me.ToolStripProgressBarConverter.Style = ProgressBarStyle.Marquee
        Me.ToolStripStatusLabelConversionStatus.Image = Nothing

        Dim inputBox As Scintilla = Nothing
        Dim outputBox As Scintilla = Nothing
        Dim sourceCode As String = String.Empty

        Select Case Me.currentCodeConverterMethod

            Case TelerikCodeConverterMethod.VisualBasicToCSharp
                inputBox = Me.ScintillaVbInput
                outputBox = Me.ScintillaCsOutput
                sourceCode = Me.ScintillaVbInput.Text

            Case TelerikCodeConverterMethod.CSharpToVisualBasic
                inputBox = Me.ScintillaCsInput
                outputBox = Me.ScintillaVbOutput
                sourceCode = Me.ScintillaCsInput.Text

        End Select

        ' Disable controls to prevent consecutive requests to this method.
        Me.ButtonConvert.Enabled = False
        inputBox.Enabled = False
        Me.PanelCsInputActions.Enabled = False
        Me.PanelVbInputActions.Enabled = False
        Me.PanelCsOutputActions.Enabled = False
        Me.PanelVbOutputActions.Enabled = False
        Me.ToolStripMain.Enabled = False
        Me.TabControlMain.Enabled = False
        Dim result As String = String.Empty
        Try
            result = Await TelerikUtil.TelerikCodeConvertAsync(Me.currentCodeConverterMethod, sourceCode)

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error trying to establish a connection to the Telerik server.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Write result.
        outputBox.SuspendLayout()
        outputBox.ReadOnly = False
        outputBox.Text = result
        outputBox.ReadOnly = True
        outputBox.ResumeLayout()

        Me.ToolStripProgressBarConverter.Style = ProgressBarStyle.Blocks

        If Not result.StartsWith("CONVERSION ERROR", StringComparison.InvariantCultureIgnoreCase) Then
            Me.ToolStripProgressBarConverter.Value = Me.ToolStripProgressBarConverter.Maximum
            Me.ToolStripStatusLabelConversionStatus.Image = My.Resources.Success

        Else
            Me.ToolStripProgressBarConverter.Value = Me.ToolStripProgressBarConverter.Minimum
            Me.ToolStripStatusLabelConversionStatus.Image = My.Resources.Fail

        End If

        ' Re-enable the disabled controls.
        inputBox.Enabled = True
        Me.ButtonConvert.Enabled = True
        Me.PanelCsInputActions.Enabled = True
        Me.PanelVbInputActions.Enabled = True
        Me.PanelCsOutputActions.Enabled = True
        Me.PanelVbOutputActions.Enabled = True
        Me.ToolStripMain.Enabled = True
        Me.TabControlMain.Enabled = True

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Updates the network status on the User Interface.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="isAvailable">
    ''' A value indicating the new state of the network connection.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub UpdateNetworkStatus(ByVal isAvailable As Boolean)

        If (isAvailable) Then
            Me.Invoke(Sub()
                          Me.ButtonConvert.Enabled = True
                          Me.ToolStripStatusLabelNetwork.Text = "Network Status: Connected"
                          Me.ToolStripStatusLabelNetwork.Image = My.Resources.Success
                      End Sub)

        Else
            Me.Invoke(Sub()
                          Me.ButtonConvert.Enabled = False
                          Me.ToolStripStatusLabelNetwork.Text = "Network Status: Disconnected"
                          Me.ToolStripStatusLabelNetwork.Image = My.Resources.Fail
                      End Sub)

        End If

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Evaluates whether the buttons of <see cref="MainForm"/> should be enabled or disabled.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub EnableOrDisableInputButtons()

        Dim textLen As Integer

        Select Case Me.currentCodeConverterMethod ' same as chacking the current tabpage.

            Case TelerikCodeConverterMethod.CSharpToVisualBasic
                textLen = Me.ScintillaCsInput.TextLength
                Me.ButtonCleanCsInput.Enabled = (textLen <> 0)
                Me.ButtonCopyAllCsInput.Enabled = (textLen <> 0)
                Me.ButtonSelectAllCsInput.Enabled = (textLen <> 0)
                Me.ButtonOpenInVsCsInput.Enabled = (textLen <> 0)
                Me.ButtonConvert.Enabled = (textLen <> 0)

            Case TelerikCodeConverterMethod.VisualBasicToCSharp
                textLen = Me.ScintillaVbInput.TextLength
                Me.ButtonCleanVbInput.Enabled = (textLen <> 0)
                Me.ButtonCopyAllVbInput.Enabled = (textLen <> 0)
                Me.ButtonSelectAllVbInput.Enabled = (textLen <> 0)
                Me.ButtonOpenInVsVbInput.Enabled = (textLen <> 0)
                Me.ButtonConvert.Enabled = (textLen <> 0)

            Case Else
                ' Unexpected Enum value. This should never occur but its always safe to handle it.
                Throw New InvalidEnumArgumentException("Me.currentCodeConverterMethod", Me.currentCodeConverterMethod,
                                                       GetType(TelerikCodeConverterMethod))

        End Select

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Evaluates whether the buttons of <see cref="MainForm"/> should be enabled or disabled.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub EnableOrDisableOutputButtons()

        Dim textLen As Integer

        Select Case Me.currentCodeConverterMethod ' same as chacking the current tabpage.

            Case TelerikCodeConverterMethod.CSharpToVisualBasic
                textLen = Me.ScintillaVbOutput.TextLength
                Me.ButtonCleanVbOutput.Enabled = (textLen <> 0)
                Me.ButtonCopyAllVbOutput.Enabled = (textLen <> 0)
                Me.ButtonSelectAllVbOutput.Enabled = (textLen <> 0)
                Me.ButtonOpenInVsVbOutput.Enabled = (textLen <> 0)

            Case TelerikCodeConverterMethod.VisualBasicToCSharp
                textLen = Me.ScintillaCsOutput.TextLength
                Me.ButtonCleanCsOutput.Enabled = (textLen <> 0)
                Me.ButtonCopyAllCsOutput.Enabled = (textLen <> 0)
                Me.ButtonSelectAllCsOutput.Enabled = (textLen <> 0)
                Me.ButtonOpenInVsCsOutput.Enabled = (textLen <> 0)

            Case Else
                ' Unexpected Enum value. This should never occur but its always safe to handle it.
                Throw New InvalidEnumArgumentException("Me.currentCodeConverterMethod", Me.currentCodeConverterMethod,
                                                       GetType(TelerikCodeConverterMethod))

        End Select

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Changes the orientation of the Scintilla editors.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub ChangeOrientation()

        Dim currentOrientation As Orientation = Me.SplitContainerCsToVb.Orientation

        Select Case currentOrientation

            Case Orientation.Vertical
                Me.SplitContainerCsToVb.ChangeOrientation(Orientation.Horizontal)
                For Each bt As Button In Me.PanelVbOutputActions.Controls.OfType(Of Button)
                    bt.Dock = DockStyle.Bottom
                Next

                Me.SplitContainerVbToCs.ChangeOrientation(Orientation.Horizontal)
                For Each bt As Button In Me.PanelCsOutputActions.Controls.OfType(Of Button)
                    bt.Dock = DockStyle.Bottom
                Next

                Me.ToolStripButtonChangeOrientation.Image = My.Resources.Vertical

            Case Orientation.Horizontal
                Me.SplitContainerCsToVb.ChangeOrientation(Orientation.Vertical)
                For Each bt As Button In Me.PanelVbOutputActions.Controls.OfType(Of Button)
                    bt.Dock = DockStyle.Top
                Next

                Me.SplitContainerVbToCs.ChangeOrientation(Orientation.Vertical)
                For Each bt As Button In Me.PanelCsOutputActions.Controls.OfType(Of Button)
                    bt.Dock = DockStyle.Top
                Next

                Me.ToolStripButtonChangeOrientation.Image = My.Resources.Horizontal

        End Select

        My.Settings.Orientation = Me.SplitContainerCsToVb.Orientation

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Builds the design of the <see cref="Scintilla"/> controls.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub BuildScintillaControls()

        Select Case My.Settings.ColorTheme

            Case 0 ' Dark
                Me.SetDarkColorTheme()

            Case 1 ' Light
                Me.SetLightColorTheme()

            Case 2 ' System-default
                Me.SetSystemColorTheme()

            Case Else
                Throw New NotImplementedException("Wrong or not implemented color theme index.")

        End Select

        ScintillaNetUtil.AddLineNumbers(Me.ScintillaVbInput, marginIndex:=1)
        ScintillaNetUtil.AddLineNumbers(Me.ScintillaVbOutput, marginIndex:=1)
        ScintillaNetUtil.AddLineNumbers(Me.ScintillaCsInput, marginIndex:=1)
        ScintillaNetUtil.AddLineNumbers(Me.ScintillaCsOutput, marginIndex:=1)

        ScintillaNetUtil.DisableControlKeysPrint(Me.ScintillaVbInput)
        ScintillaNetUtil.DisableControlKeysPrint(Me.ScintillaVbOutput)
        ScintillaNetUtil.DisableControlKeysPrint(Me.ScintillaCsInput)
        ScintillaNetUtil.DisableControlKeysPrint(Me.ScintillaCsOutput)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the dark color theme on the UI.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub SetDarkColorTheme()

        ScintillaNetUtil.SetVbNetDarkStyle(Me.ScintillaVbInput)
        ScintillaNetUtil.SetVbNetDarkStyle(Me.ScintillaVbOutput)
        ScintillaNetUtil.SetCSharpDarkStyle(Me.ScintillaCsInput)
        ScintillaNetUtil.SetCSharpDarkStyle(Me.ScintillaCsOutput)

        Me.BackColor = Color.FromArgb(&HFF, &H25, &H25, &H26)
        Me.ForeColor = Color.Gainsboro

        Me.TableLayoutPanelAllTabs.BackColor = Color.FromArgb(255, 32, 33, 33)
        Me.TableLayoutPanelCsToVb.BackColor = Color.FromArgb(255, 32, 33, 33)
        Me.TableLayoutPanelVbToCs.BackColor = Color.FromArgb(255, 32, 33, 33)

        Me.SplitContainerCsToVb.BackColor = Color.Silver
        Me.SplitContainerVbToCs.BackColor = Color.Silver

        Me.PanelCsInputActions.BackColor = Color.FromArgb(255, 32, 33, 33)
        Me.PanelCsOutputActions.BackColor = Color.FromArgb(255, 32, 33, 33)
        Me.PanelVbInputActions.BackColor = Color.FromArgb(255, 32, 33, 33)
        Me.PanelVbOutputActions.BackColor = Color.FromArgb(255, 32, 33, 33)

        Me.TabControlMain.myBackColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.TabControlMain.ForeColor = Me.ForeColor

        Me.ButtonConvert.BackColor = Color.FromArgb(255, 47, 48, 48)
        Me.ButtonConvert.ForeColor = Me.ForeColor

        Me.ToolStripMain.BackColor = Color.FromArgb(&HFF, &H20, &H21, &H21)
        Me.ToolStripMain.ForeColor = Me.ForeColor

        Me.StatusStripMain.BackColor = Color.FromArgb(&HFF, &H20, &H21, &H21)
        Me.StatusStripMain.ForeColor = Me.ForeColor

        Me.ButtonCleanCsInput.BackColor = Color.DimGray
        Me.ButtonCopyAllCsInput.BackColor = Color.DimGray
        Me.ButtonSelectAllCsInput.BackColor = Color.DimGray
        Me.ButtonOpenInVsCsInput.BackColor = Color.DimGray

        Me.ButtonCleanVbInput.BackColor = Color.DimGray
        Me.ButtonCopyAllVbInput.BackColor = Color.DimGray
        Me.ButtonSelectAllVbInput.BackColor = Color.DimGray
        Me.ButtonOpenInVsVbInput.BackColor = Color.DimGray

        Me.ButtonCleanCsOutput.BackColor = Color.DimGray
        Me.ButtonCopyAllCsOutput.BackColor = Color.DimGray
        Me.ButtonSelectAllCsOutput.BackColor = Color.DimGray
        Me.ButtonOpenInVsCsOutput.BackColor = Color.DimGray

        Me.ButtonCleanVbOutput.BackColor = Color.DimGray
        Me.ButtonCopyAllVbOutput.BackColor = Color.DimGray
        Me.ButtonSelectAllVbOutput.BackColor = Color.DimGray
        Me.ButtonOpenInVsVbOutput.BackColor = Color.DimGray

        Me.ButtonCleanCsInput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonCopyAllCsInput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonSelectAllCsInput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonOpenInVsCsInput.FlatAppearance.BorderColor = Color.Black

        Me.ButtonCleanVbInput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonCopyAllVbInput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonSelectAllVbInput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonOpenInVsVbInput.FlatAppearance.BorderColor = Color.Black

        Me.ButtonCleanCsOutput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonCopyAllCsOutput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonSelectAllCsOutput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonOpenInVsCsOutput.FlatAppearance.BorderColor = Color.Black

        Me.ButtonCleanVbOutput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonCopyAllVbOutput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonSelectAllVbOutput.FlatAppearance.BorderColor = Color.Black
        Me.ButtonOpenInVsVbOutput.FlatAppearance.BorderColor = Color.Black

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the light color theme on the UI.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub SetLightColorTheme()

        ScintillaNetUtil.SetVbNetLightStyle(Me.ScintillaVbInput)
        ScintillaNetUtil.SetVbNetLightStyle(Me.ScintillaVbOutput)
        ScintillaNetUtil.SetCSharpLightStyle(Me.ScintillaCsInput)
        ScintillaNetUtil.SetCSharpLightStyle(Me.ScintillaCsOutput)

        Me.BackColor = Color.Gainsboro
        Me.ForeColor = Color.Black

        Me.TableLayoutPanelAllTabs.BackColor = Color.Gainsboro
        Me.TableLayoutPanelCsToVb.BackColor = Color.Gainsboro
        Me.TableLayoutPanelVbToCs.BackColor = Color.Gainsboro

        Me.SplitContainerCsToVb.BackColor = Color.SteelBlue
        Me.SplitContainerVbToCs.BackColor = Color.SteelBlue

        Me.PanelCsInputActions.BackColor = Color.SteelBlue
        Me.PanelCsOutputActions.BackColor = Color.SteelBlue
        Me.PanelVbInputActions.BackColor = Color.SteelBlue
        Me.PanelVbOutputActions.BackColor = Color.SteelBlue

        Me.TabControlMain.myBackColor = Color.Silver
        Me.TabControlMain.ForeColor = Me.ForeColor

        Me.ButtonConvert.BackColor = Color.LightSteelBlue
        Me.ButtonConvert.ForeColor = Me.ForeColor

        Me.ToolStripMain.BackColor = Color.Gainsboro
        Me.ToolStripMain.ForeColor = Me.ForeColor

        Me.StatusStripMain.BackColor = Color.Gainsboro
        Me.StatusStripMain.ForeColor = Me.ForeColor

        Me.ButtonCleanCsInput.BackColor = Color.LightSteelBlue
        Me.ButtonCopyAllCsInput.BackColor = Color.LightSteelBlue
        Me.ButtonSelectAllCsInput.BackColor = Color.LightSteelBlue
        Me.ButtonOpenInVsCsInput.BackColor = Color.LightSteelBlue

        Me.ButtonCleanVbInput.BackColor = Color.LightSteelBlue
        Me.ButtonCopyAllVbInput.BackColor = Color.LightSteelBlue
        Me.ButtonSelectAllVbInput.BackColor = Color.LightSteelBlue
        Me.ButtonOpenInVsVbInput.BackColor = Color.LightSteelBlue

        Me.ButtonCleanCsOutput.BackColor = Color.LightSteelBlue
        Me.ButtonCopyAllCsOutput.BackColor = Color.LightSteelBlue
        Me.ButtonSelectAllCsOutput.BackColor = Color.LightSteelBlue
        Me.ButtonOpenInVsCsOutput.BackColor = Color.LightSteelBlue

        Me.ButtonCleanVbOutput.BackColor = Color.LightSteelBlue
        Me.ButtonCopyAllVbOutput.BackColor = Color.LightSteelBlue
        Me.ButtonSelectAllVbOutput.BackColor = Color.LightSteelBlue
        Me.ButtonOpenInVsVbOutput.BackColor = Color.LightSteelBlue

        Me.ButtonCleanCsInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonCopyAllCsInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonSelectAllCsInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonOpenInVsCsInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)

        Me.ButtonCleanVbInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonCopyAllVbInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonSelectAllVbInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonOpenInVsVbInput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)

        Me.ButtonCleanCsOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonCopyAllCsOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonSelectAllCsOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonOpenInVsCsOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)

        Me.ButtonCleanVbOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonCopyAllVbOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonSelectAllVbOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)
        Me.ButtonOpenInVsVbOutput.FlatAppearance.BorderColor = Color.FromArgb(&HFF, &H3E, &H3E, &H42)

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the system color theme on the UI.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub SetSystemColorTheme()

        ScintillaNetUtil.SetVbNetSystemStyle(Me.ScintillaVbInput)
        ScintillaNetUtil.SetVbNetSystemStyle(Me.ScintillaVbOutput)
        ScintillaNetUtil.SetCSharpSystemStyle(Me.ScintillaCsInput)
        ScintillaNetUtil.SetCSharpSystemStyle(Me.ScintillaCsOutput)

        Me.BackColor = Form.DefaultBackColor
        Me.ForeColor = Form.DefaultForeColor

        Me.TableLayoutPanelAllTabs.BackColor = TableLayoutPanel.DefaultBackColor
        Me.TableLayoutPanelCsToVb.BackColor = TableLayoutPanel.DefaultBackColor
        Me.TableLayoutPanelVbToCs.BackColor = TableLayoutPanel.DefaultBackColor

        Me.SplitContainerCsToVb.BackColor = SplitContainer.DefaultBackColor
        Me.SplitContainerVbToCs.BackColor = SplitContainer.DefaultBackColor

        Me.PanelCsInputActions.BackColor = Panel.DefaultBackColor
        Me.PanelCsOutputActions.BackColor = Panel.DefaultBackColor
        Me.PanelVbInputActions.BackColor = Panel.DefaultBackColor
        Me.PanelVbOutputActions.BackColor = Panel.DefaultBackColor

        Me.TabControlMain.myBackColor = TabControl.DefaultBackColor
        Me.TabControlMain.ForeColor = TabControl.DefaultForeColor

        Me.ButtonConvert.BackColor = Button.DefaultBackColor
        Me.ButtonConvert.ForeColor = Button.DefaultForeColor

        Me.ToolStripMain.BackColor = ToolStrip.DefaultBackColor
        Me.ToolStripMain.ForeColor = ToolStrip.DefaultForeColor

        Me.StatusStripMain.BackColor = StatusStrip.DefaultBackColor
        Me.StatusStripMain.ForeColor = StatusStrip.DefaultForeColor

        Me.ButtonCleanCsInput.BackColor = Button.DefaultBackColor
        Me.ButtonCopyAllCsInput.BackColor = Button.DefaultBackColor
        Me.ButtonSelectAllCsInput.BackColor = Button.DefaultBackColor
        Me.ButtonOpenInVsCsInput.BackColor = Button.DefaultBackColor

        Me.ButtonCleanVbInput.BackColor = Button.DefaultBackColor
        Me.ButtonCopyAllVbInput.BackColor = Button.DefaultBackColor
        Me.ButtonSelectAllVbInput.BackColor = Button.DefaultBackColor
        Me.ButtonOpenInVsVbInput.BackColor = Button.DefaultBackColor

        Me.ButtonCleanCsOutput.BackColor = Button.DefaultBackColor
        Me.ButtonCopyAllCsOutput.BackColor = Button.DefaultBackColor
        Me.ButtonSelectAllCsOutput.BackColor = Button.DefaultBackColor
        Me.ButtonOpenInVsCsOutput.BackColor = Button.DefaultBackColor

        Me.ButtonCleanVbOutput.BackColor = Button.DefaultBackColor
        Me.ButtonCopyAllVbOutput.BackColor = Button.DefaultBackColor
        Me.ButtonSelectAllVbOutput.BackColor = Button.DefaultBackColor
        Me.ButtonOpenInVsVbOutput.BackColor = Button.DefaultBackColor

        Me.ButtonCleanCsInput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonCopyAllCsInput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonSelectAllCsInput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonOpenInVsCsInput.FlatAppearance.BorderColor = Button.DefaultBackColor

        Me.ButtonCleanVbInput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonCopyAllVbInput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonSelectAllVbInput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonOpenInVsVbInput.FlatAppearance.BorderColor = Button.DefaultBackColor

        Me.ButtonCleanCsOutput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonCopyAllCsOutput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonSelectAllCsOutput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonOpenInVsCsOutput.FlatAppearance.BorderColor = Button.DefaultBackColor

        Me.ButtonCleanVbOutput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonCopyAllVbOutput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonSelectAllVbOutput.FlatAppearance.BorderColor = Button.DefaultBackColor
        Me.ButtonOpenInVsVbOutput.FlatAppearance.BorderColor = Button.DefaultBackColor

    End Sub

#End Region

End Class
