




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

Imports WinForms = System.Windows.Forms

#End Region

#Region " DevCase.Core.Extensions.SplitContainer.SplitContainerExtensions "

Namespace DevCase.Core.Extensions.[SplitContainer]

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains custom extension methods to use with <see cref="WinForms.SplitContainer"/> control.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    <HideModuleName>
    Public Module SplitContainerExtensions

#Region " Public Extension Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Changes the orientation of the source <see cref="WinForms.SplitContainer"/> 
        ''' and assigns the 50% width for each <see cref="WinForms.SplitterPanel"/>.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source <see cref="WinForms.SplitContainer"/>.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        <Extension>
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub ChangeOrientation(ByVal sender As WinForms.SplitContainer, ByVal newOrientation As WinForms.Orientation)

            If sender.Orientation = newOrientation Then
                Exit Sub
            End If

            sender.Orientation = newOrientation

            ' If Not sender.IsSplitterFixed Then
            Select Case newOrientation

                Case WinForms.Orientation.Horizontal
                    sender.SplitterDistance = ((sender.Panel1.Height + sender.Panel2.Height) \ 2) - (sender.SplitterWidth \ 2)

                Case WinForms.Orientation.Vertical
                    sender.SplitterDistance = ((sender.Panel1.Width + sender.Panel2.Width) \ 2) - (sender.SplitterWidth \ 2)

            End Select
            ' End If

        End Sub

#End Region

    End Module

End Namespace

#End Region
