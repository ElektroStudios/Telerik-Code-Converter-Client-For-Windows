




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

Imports System.Environment

#End Region

#Region " DevCase.Core.IO.Tools.Files "

Namespace DevCase.Core.IO.Tools

    Partial Public NotInheritable Class Files

#Region " Public Methods "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Creates a uniquely named, zero-byte temporary file on the system's default temporary folder with the specified file extension 
        ''' and returns the file.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim tmpFile As FileInfo = GetTempFile("txt")
        ''' Console.WriteLine(tmpFile.FullName)
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="extension">
        ''' The file extension to assign to the temporary file.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting <see cref="FileInfo"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentNullException">
        ''' extension
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetTempFile(ByVal extension As String) As FileInfo

            Return Files.GetTempFile(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), extension)

        End Function

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Creates a uniquely named, zero-byte temporary file on the specified folder with the specified file extension 
        ''' and returns the file.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <example> This is a code example.
        ''' <code>
        ''' Dim tmpFile As FileInfo = GetTempFile("C:\Folder\", "txt")
        ''' Console.WriteLine(tmpFile.FullName)
        ''' </code>
        ''' </example>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <param name="dirPath">
        ''' The full path of the folder where to create the temporary file.
        ''' </param>
        ''' 
        ''' <param name="extension">
        ''' The file extension to assign to the temporary file.
        ''' </param>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <returns>
        ''' The resulting <see cref="FileInfo"/>.
        ''' </returns>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <exception cref="ArgumentNullException">
        ''' dirPath or extension
        ''' </exception>
        ''' ----------------------------------------------------------------------------------------------------
        <DebuggerStepThrough>
        Public Shared Function GetTempFile(ByVal dirPath As String, ByVal extension As String) As FileInfo

            If String.IsNullOrWhiteSpace(dirPath) Then
                Throw New ArgumentNullException("dirPath")

            ElseIf String.IsNullOrWhiteSpace(extension) Then
                Throw New ArgumentNullException("extension")

            Else
                Dim dir As New DirectoryInfo(dirPath)
                If Not (dir.Exists) Then
                    Try
                        dir.Create()
                    Catch ex As Exception
                        Throw
                        Return Nothing
                    End Try
                End If

                Dim tmpFile As FileInfo = Nothing
                Dim newFilePath As String
                Dim defaultFolderPath As String = Environment.GetFolderPath(SpecialFolder.LocalApplicationData)
                Dim defaultFileExtension As String = "tmp"
                Do
                    If (tmpFile IsNot Nothing) AndAlso (tmpFile.Exists) Then
                        tmpFile.Delete()
                    End If
                    tmpFile = New FileInfo(Path.GetTempFileName())

                    If Not (dir.FullName.Equals(defaultFolderPath, StringComparison.OrdinalIgnoreCase)) Then
                        newFilePath = Path.Combine(dir.FullName, tmpFile.Name)
                    Else
                        newFilePath = tmpFile.FullName
                    End If

                    If Not (extension.Equals(defaultFileExtension, StringComparison.OrdinalIgnoreCase)) Then
                        newFilePath = Path.ChangeExtension(newFilePath, extension)
                    End If

                Loop Until (newFilePath.Equals(tmpFile.FullName, StringComparison.OrdinalIgnoreCase)) OrElse Not File.Exists(newFilePath)

                tmpFile.MoveTo(newFilePath)
                tmpFile.Refresh()

                Return tmpFile

            End If

        End Function

#End Region

    End Class

End Namespace

#End Region
