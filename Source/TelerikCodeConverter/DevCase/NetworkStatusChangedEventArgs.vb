




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

Imports DevCase.Core.Types

#End Region

#Region " DevCase.Core.NET.Types.EventArgs.NetworkStatusChangedEventArgs "

Namespace DevCase.Core.NET.Types.EventArgs

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains the event-data of a <see cref="DevCase.Core.NET.Tools.NetworkUtil.NetworkStatusChanged"/> event.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Friend NotInheritable Class NetworkStatusChangedEventArgs : Inherits AestheticEventArgs

#Region " Delegates "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Delegate NetworkStatusChangedHandler. Define the method signature for network status changes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source of the event.
        ''' </param>
        ''' 
        ''' <param name="e">
        ''' The <see cref="NetworkStatusChangedEventArgs"/> instance containing the event data.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        Public Delegate Sub NetworkStatusChangedDelegate(ByVal sender As Object, ByVal e As NetworkStatusChangedEventArgs)

#End Region

#Region " Properties "

        ''' <summary>
        ''' Gets a <see langword="Boolean"/> value indicating the current state of internet connectivity.
        ''' </summary>
        Public ReadOnly Property IsAvailable As Boolean
            <DebuggerStepThrough>
            Get
                Return Me.isAvailableB
            End Get
        End Property
        ''' <summary>
        ''' ( Backing field )
        ''' A <see langword="Boolean"/> value indicating the current state of internet connectivity.
        ''' </summary>
        Private ReadOnly isAvailableB As Boolean

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="NetworkStatusChangedEventArgs"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="isAvailable">
        ''' A <see langword="Boolean"/> value indicating the current state of Internet connectivity.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Sub New(ByVal isAvailable As Boolean)
            Me.isAvailableB = isAvailable
        End Sub

#End Region

    End Class

End Namespace

#End Region
