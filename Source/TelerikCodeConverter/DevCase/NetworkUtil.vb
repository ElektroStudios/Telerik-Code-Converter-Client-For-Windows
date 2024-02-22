




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

Imports System.Net.NetworkInformation

Imports DevCase.Core.NET.Types.EventArgs
Imports DevCase.Core.Types

#End Region

#Region " DevCase.Core.NET.Tools.NetworkUtil "

Namespace DevCase.Core.NET.Tools

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Contains networking related utilities.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Friend NotInheritable Class NetworkUtil : Inherits AestheticObject

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="NetworkUtil"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerNonUserCode>
        Private Sub New()
        End Sub

#End Region

#Region " Properties "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a value indicating whether at least one of the current network adapters is capable of connecting to Internet.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' <see langword="True"/> if at least one of the current network adapters is capable of connecting to Internet; 
        ''' otherwise, <see langword="False"/>.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        Public Shared ReadOnly Property IsNetworkAvailable As Boolean
            <DebuggerStepThrough>
            Get
                Return GetNetworkAvailable()
            End Get
        End Property

#End Region

#Region " Events "

        Private Shared networkStatusHandler As NetworkStatusChangedEventArgs.NetworkStatusChangedDelegate

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Occurs when the state of Internet connectivity changes.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Public Class Form1
        ''' 
        '''     Private Sub Form1_Shown() Handles MyBase.Load
        ''' 
        '''         AddHandler NetworkStatusChanged, AddressOf DoNetworkStatusChanged
        ''' 
        '''     End Sub
        ''' 
        '''     Private Sub DoNetworkStatusChanged(ByVal sender As Object, e As NetworkStatusChangedEventArgs)
        ''' 
        '''         If e.IsAvailable Then
        '''             Console.WriteLine("Network is available.")
        ''' 
        '''         Else
        '''             Console.WriteLine("Network is not available.")
        ''' 
        '''         End If
        ''' 
        '''     End Sub
        ''' 
        ''' End Class
        ''' </code>
        ''' </example>
        Public Shared Custom Event NetworkStatusChanged As NetworkStatusChangedEventArgs.NetworkStatusChangedDelegate

            <MethodImpl(MethodImplOptions.Synchronized)>
            <DebuggerStepThrough>
            AddHandler(ByVal value As NetworkStatusChangedEventArgs.NetworkStatusChangedDelegate)

                If networkStatusHandler Is Nothing Then
                    AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf DoNetworkAvailabilityChanged
                    AddHandler NetworkChange.NetworkAddressChanged, AddressOf DoNetworkAddressChanged
                End If

                networkStatusHandler = DirectCast([Delegate].Combine(networkStatusHandler, value), NetworkStatusChangedEventArgs.NetworkStatusChangedDelegate)

            End AddHandler

            <MethodImpl(MethodImplOptions.Synchronized)>
            <DebuggerStepThrough>
            RemoveHandler(ByVal value As NetworkStatusChangedEventArgs.NetworkStatusChangedDelegate)

                networkStatusHandler = DirectCast([Delegate].Remove(networkStatusHandler, value), NetworkStatusChangedEventArgs.NetworkStatusChangedDelegate)

                If networkStatusHandler Is Nothing Then
                    AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf DoNetworkAvailabilityChanged
                    AddHandler NetworkChange.NetworkAddressChanged, AddressOf DoNetworkAddressChanged
                End If

            End RemoveHandler

            <MethodImpl(MethodImplOptions.Synchronized)>
            <DebuggerStepThrough>
            RaiseEvent(ByVal sender As Object, ByVal e As NetworkStatusChangedEventArgs)
                networkStatusHandler(sender, e)
            End RaiseEvent

        End Event

#End Region

#Region " Event-Handlers "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Handles the <see cref="Global.System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged"/> event.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source of the event.
        ''' </param>
        ''' 
        ''' <param name="e">
        ''' The <see cref="Global.System.Net.NetworkInformation.NetworkAvailabilityEventArgs"/> instance containing the event data.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Private Shared Sub DoNetworkAvailabilityChanged(ByVal sender As Object, ByVal e As NetworkAvailabilityEventArgs)

            NetworkUtil.RaiseNetworkChange(sender)

        End Sub

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Handles the <see cref="Global.System.Net.NetworkInformation.NetworkChange.NetworkAddressChanged"/> event.
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
        <DebuggerStepThrough>
        Private Shared Sub DoNetworkAddressChanged(ByVal sender As Object, ByVal e As Global.System.EventArgs)

            NetworkUtil.RaiseNetworkChange(sender)

        End Sub

#End Region

#Region " Private Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Evaluate the online network adapters to determine if at least one of them is capable of connecting to Internet.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if at least one of the current network adapters is capable of connecting to Internet; 
        ''' otherwise, <see langword="False"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Private Shared Function GetNetworkAvailable() As Boolean

            ' Only recognizes changes related to Internet adapters.
            If NetworkInterface.GetIsNetworkAvailable() Then

                ' However, this will include all adapters.
                Dim interfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

                For Each ni As NetworkInterface In interfaces

                    ' Filter so we see only Internet adapters.
                    If ni.OperationalStatus = OperationalStatus.Up Then

                        If (ni.NetworkInterfaceType <> NetworkInterfaceType.Tunnel) AndAlso
                        (ni.NetworkInterfaceType <> NetworkInterfaceType.Loopback) Then

                            Dim statistics As IPv4InterfaceStatistics = ni.GetIPv4Statistics()

                            ' All testing seems to prove that once an interface comes online
                            ' it has already accrued statistics for both received and sent...
                            If (statistics.BytesReceived > 0) AndAlso (statistics.BytesSent > 0) Then
                                Return True
                            End If

                        End If

                    End If

                Next ni

            End If

            Return False

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Raises the network change event.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="sender">
        ''' The source of the event.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Private Shared Sub RaiseNetworkChange(ByVal sender As Object)

            Static isNetworkAvailable As Boolean = Not GetNetworkAvailable()
            Dim change As Boolean = GetNetworkAvailable()

            If (change <> isNetworkAvailable) Then

                isNetworkAvailable = change
                RaiseEvent NetworkStatusChanged(sender, New NetworkStatusChangedEventArgs(change))

            End If

        End Sub

#End Region

    End Class

End Namespace

#End Region
