




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


#End Region

#Region " About Form "

''' ----------------------------------------------------------------------------------------------------
''' <summary>
''' The About <see cref="Form"/>.
''' </summary>
''' ----------------------------------------------------------------------------------------------------
Friend NotInheritable Class AboutForm : Inherits Form

#Region " Event Handlers "

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="Form.Load"/> event of the <see cref="AboutForm"/> form.
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
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set Dark or Light theme colors.
        Me.BackColor = My.Forms.MainForm.BackColor
        Me.ForeColor = My.Forms.MainForm.ForeColor
        Me.LinkLabelDevCase.LinkColor = Me.ForeColor

    End Sub

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the <see cref="LinkLabel.LinkClicked"/> event of the <see cref="AboutForm.LinkLabelDevCase"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <param name="sender">
    ''' The source of the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    ''' The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.
    ''' </param>
    ''' ----------------------------------------------------------------------------------------------------
    Private Sub LinkLabelDevCase_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelDevCase.LinkClicked

        Try
            Process.Start(DirectCast(sender, LinkLabel).Text)

        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Error trying to open the default web browser.", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region

End Class

#End Region
