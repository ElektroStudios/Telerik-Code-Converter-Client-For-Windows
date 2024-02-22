




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





#Region " DevCase.Core.Application.UserInterface.Tools.GraphicalInterfaceUtil "

Namespace DevCase.Core.Application.UserInterface.Tools

    Partial Public NotInheritable Class GraphicalInterfaceUtil

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Minimizes the specified <see cref="Form"/> to system-tray.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="form">
        ''' The target <see cref="Form"/> to minimize.
        ''' </param>
        ''' 
        ''' <param name="ntfy">
        ''' The <see cref="NotifyIcon"/>.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentNullException">
        ''' ntfy
        ''' </exception>
        ''' 
        ''' <exception cref="ArgumentException">
        ''' The NotifyIcon doesn't have an icon.;ntfy
        ''' or
        ''' The Form is not visible.;form
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub MinimizeToSystray(ByVal form As Form, ByVal ntfy As NotifyIcon)

            If (ntfy Is Nothing) Then
                Throw New ArgumentNullException(paramName:="ntfy")

            ElseIf (ntfy.Icon Is Nothing) Then
                Throw New ArgumentException(message:="The NotifyIcon doesn't have an icon.",
                                            paramName:="ntfy")

            ElseIf Not (form.Visible) Then
                Throw New ArgumentException(message:="The Form is not visible.",
                                            paramName:="form")

            Else
                form.Hide()

                If Not (ntfy.Visible) Then
                    ntfy.Visible = True
                End If

            End If

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Restores the visibility of the specified <see cref="Form"/> from system-tray.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="form">
        ''' The target <see cref="Form"/> to restore.
        ''' </param>
        ''' 
        ''' <param name="ntfy">
        ''' The <see cref="NotifyIcon"/>.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentNullException">
        ''' ntfy
        ''' </exception>
        ''' 
        ''' <exception cref="ArgumentException">
        ''' The NotifyIcon doesn't have an icon.;ntfy
        ''' or
        ''' The Form is already visible.;form
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub RestoreFromSystray(ByVal form As Form, ByVal ntfy As NotifyIcon)

            If (ntfy Is Nothing) Then
                Throw New ArgumentNullException(paramName:="ntfy")

            ElseIf (ntfy.Icon Is Nothing) Then
                Throw New ArgumentException(message:="The NotifyIcon doesn't have an icon.",
                                            paramName:="ntfy")

            ElseIf (form.Visible) Then
                Throw New ArgumentException(message:="The Form is already visible.",
                                            paramName:="form")

            Else
                form.Show()

                If Not (ntfy.Visible) Then
                    ntfy.Visible = True
                End If

            End If

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Toogles the visibility of the specified <see cref="Form"/> 
        ''' to minimize it to system-tray or restore it from system-tray.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="form">
        ''' The target <see cref="Form"/> to toofle its visibility.
        ''' </param>
        ''' 
        ''' <param name="ntfy">
        ''' The <see cref="NotifyIcon"/>.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentNullException">
        ''' ntfy
        ''' </exception>
        ''' 
        ''' <exception cref="ArgumentException">
        ''' The NotifyIcon doesn't have an icon.;ntfy
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Sub ToogleFormSystray(ByVal form As Form, ByVal ntfy As NotifyIcon)

            If (ntfy Is Nothing) Then
                Throw New ArgumentNullException(paramName:="ntfy")

            ElseIf (ntfy.Icon Is Nothing) Then
                Throw New ArgumentException(message:="The NotifyIcon doesn't have an icon.",
                                            paramName:="ntfy")

            Else
                If (form.Visible) Then
                    form.Hide()

                ElseIf Not (form.Visible) Then
                    form.Show()

                End If

                If Not (ntfy.Visible) Then
                    ntfy.Visible = True
                End If

            End If

        End Sub

#End Region

    End Class

End Namespace

#End Region
