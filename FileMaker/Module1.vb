Imports System.Data.Common
Imports Newtonsoft.Json

'TODO:4.  Create A Json file for the Project Class

'TODO:5.  Refactor writeFile procedure to take a string for data input

'TODO:6.  move the input variable up to the global class variable access

'TODO:7.  Seralize Project Class

'TODO:8.  Deseralize The Project json Class

'TODO:9.  Use snippets (insert comment) to add comments to procedures and functions

'TODO:10.Refactor your code to create subfolders in a separate procedure

'TODO:11.Remove reference comments

Module Module1

    'READ: 'More information on file reading and writing in the coursebook: pg 68: FileRead

    'https://drive.google.com/file/d/1qwb9Sq3bf9sWPdAUeiFX_xM1Knb4Ikpp/view

    Dim WeekNumber As String

    Dim FullDirectory As String

    'This function tells the console window what to write and what to read.
    Sub Main() 'A Sub is a function that doesn't return anything

        Dim input As String = 0

        While input <> "exit" 'This tells the console to display the follwing things as long as the input IS NOT exit. Notice that it must receive the exact input "exit" with respect to all lowercase, otherwis it won't work

            Console.WriteLine("please the week number.")

            WeekNumber = Console.ReadLine 'The Console will read whatever the user types as the WeekNumber string

            Console.WriteLine("Please enter a command  exit | create") 'Notice that the Console writes the lines in the order they appear in.

            input = Console.ReadLine.ToString()

            If input = "create" Then 'This line makes the condition needed to activate the MakeP2PProjectFolders function. In this case the condition is that user types in "create"

                MakeProjectFolders()
                SerializeProject()

            End If

        End While 'This marks the loop that is created by While. As long as we don't type in "exit" the Console will keep writing the lines as a loop.

    End Sub


    Sub SerializeProject()
        Dim myProject As New Project()
        myProject.Department = "Visual"
        myProject.Task = "Presentation"

        Dim json As String = JsonConvert.SerializeObject(myProject)

        Dim location As String = My.Computer.FileSystem.SpecialDirectories.Desktop 'variables must be declared before they are referenced



        Dim file As IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(location + "\jsobData.json", True)
        file.WriteLine(json)
        file.Close()


    End Sub







    Private Sub MakeProjectFolders() 'This is where the function utilized in the code above is actually defined as a procedure

        'TODO: Add Json database



        Dim newFolderPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop 'This tells the code to insert the computers Desktop directory everytime it reade the string newFolderPath.
        'this If statement is telling the program what to do in case the user enters a blank. The program will automatically name the folder Week#
        If WeekNumber = "" Then
            WeekNumber = " Week#\"

        End If

        '  My.Computer.FileSystem.CreateDirectory(newFolderPath + ProjectName)

        CreateProjectFolder(newFolderPath, WeekNumber) 'this function places a WeekNumber folder in our Desktop screen
        newFolderPath += "\" + WeekNumber 'now it updates every newFolderPath to reference the WeekNumber folder in our desktop.
        FullDirectory = newFolderPath

        'This creates a folder called Screenshots inside of the updated newFolderPath
        CreateProjectFolder(newFolderPath, "\Screenshots")

        'the dollar sign and brackets is a concatenation, so that two things can be added together. The dollar sign indicates that the things inside the brackets is a variable.
        CreateProjectFolder($"{newFolderPath}\Screenshots", "DiscordPost")
        CreateProjectFolder($"{newFolderPath}\Screenshots", "ProjectUpdates") ' notice that the comma indicates that all those folders will happen inside of screenshots and parallel to eachother
        CreateProjectFolder($"{newFolderPath}\Screenshots", "ICA")

        CreateProjectFolder(newFolderPath, "\WorkingApplication") 'notice that this follows the same formula as the screenshot folder, so it is a parallel folder

        'This creates a text file in in the main project folder
        WriteFile("ReadMe.txt", newFolderPath)
        'This creates a text file inside (or after) the Screenshots folder 
        WriteFile("ReadMe.txt", $"{newFolderPath}\WorkingApplication")




        Console.WriteLine("Project created in: " + FullDirectory) 'This tells the console to give you the full directory of the folder you created

    End Sub

    Private Sub WriteFile(fileName As String, location As String)

        'Ref:https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files-with-a-streamwriter

        If fileName <> "" Then

            Dim file As System.IO.StreamWriter

            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)

            file.WriteLine("Remember to create a log document with the date, team member names, and project notes for the day.")

            file.Close()

        End If

    End Sub

    'this is the definition of what the CreateProjectFolder function does - it is the function used within the Sub above
    'the things in the parenthesis are the arguments = the things that the function is working with/on. Notice that the data type neeeds to be read as.
    Sub CreateProjectFolder(newFolderPath As String, WeekNumber As String)
        'this says: create a directory in My Computer's File System that combines folders within the newFolderPath Variable Starting with the Variable WeekNumber
        My.Computer.FileSystem.CreateDirectory(newFolderPath + "\" + WeekNumber)

    End Sub

End Module