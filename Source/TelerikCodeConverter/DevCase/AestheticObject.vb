




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





#Region " DevCase.Core.Types.AestheticObject "

Namespace DevCase.Core.Types

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' This is a class to consume for aesthetic purposes.
    ''' <para></para>
    ''' A default (emptyness) class that inherits from <see cref="Object"/>, with these base members hidden:
    ''' <para></para>
    ''' <see cref="Global.System.Object.GetHashCode"/>, <see cref="Global.System.Object.GetType"/>, 
    ''' <see cref="Global.System.Object.Equals(Object)"/>, <see cref="Global.System.Object.Equals(Object, Object)"/>,
    ''' <see cref="Global.System.Object.ReferenceEquals(Object, Object)"/>, <see cref="Global.System.Object.ToString()"/>.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Friend MustInherit Class AestheticObject : Inherits Object

#Region " Hidden Base Members (of Object) "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Serves as a hash function for a particular type.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        <DebuggerNonUserCode>
        Public Overridable Shadows Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the <see cref="Type"/> of the current instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The exact runtime type of the current instance.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        <DebuggerNonUserCode>
        Public Overridable Shadows Function [GetType]() As Type
            Return MyBase.GetType()
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the specified <see cref="Object"/> is equal to this instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="obj">
        ''' Another object to compare to.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if the specified <see cref="Object"/> is equal to this instance; 
        ''' otherwise, <see langword="False"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        <DebuggerNonUserCode>
        Public Overridable Shadows Function Equals(ByVal obj As Object) As Boolean
            Return MyBase.Equals(obj)
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the specified <see cref="Object"/> instances are considered equal.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="objA">
        ''' The first object to compare.
        ''' </param>
        ''' 
        ''' <param name="objB">
        ''' The second object to compare.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if the objects are considered equal; otherwise, <see langword="False"/>.
        ''' <para></para>
        ''' If both <paramref name="objA"/> and <paramref name="objB"/> are <see langword="Nothing"/>, 
        ''' the method returns <see langword="True"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        <DebuggerNonUserCode>
        Public Shared Shadows Function Equals(ByVal objA As Object, ByVal objB As Object) As Boolean
            Return Object.Equals(objA, objB)
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Determines whether the specified <see cref="Object"/> instances are the same instance.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="objA">
        ''' The first object to compare.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="objB">
        ''' The second object to compare.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' <see langword="True"/> if <paramref name="objA"/> is the same instance as <paramref name="objB"/> 
        ''' or if both are <see langword="Nothing"/>; otherwise, <see langword="False"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        <DebuggerNonUserCode>
        Public Shared Shadows Function ReferenceEquals(ByVal objA As Object, ByVal objB As Object) As Boolean
            Return Object.ReferenceEquals(objA, objB)
        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Returns a String that represents the current object.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' A string that represents the current object.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Never)>
        <DebuggerNonUserCode>
        Public Overrides Function ToString() As String
            Return MyBase.ToString()
        End Function

#End Region

    End Class

End Namespace

#End Region
