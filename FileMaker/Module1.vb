Imports System.Data.Common
Imports System.IO
Imports Newtonsoft.Json

'TODO:1. Change Procedure name to your own procedure name X

'TODO:2.  Add Json package to the resources X

'TODO:3. Create A Project Class X


'TODO:4.  Create A Json file for the Project Class X

'TODO:5.  Refactor writeFile procedure to take a string for data input

'TODO:6.  move the input variable up to the global class variable access

'TODO:7.  Seralize Project Class

'TODO:8.  Deseralize The Project json Class

'TODO:9.  Use snippets (insert comment) to add comments to procedures and functions X

'TODO:10.Refactor your code to create subfolders in a separate procedure

'TODO:11.Remove reference comments X

Module Module1

    Dim WeekNumber As String

    Dim FullDirectory As String

    Sub Main()

        Dim input As String = ""

        While input <> "exit"

            Console.WriteLine("Please enter the week number.")
            WeekNumber = Console.ReadLine
            Console.WriteLine("Please enter a command  exit | create")
            input = Console.ReadLine.ToLower()

            If input = "create" Then
                MakeProjectFolders()
                SerializeProject()

            End If

        End While

    End Sub





    Private Sub MakeProjectFolders()

        Dim newFolderPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop
        If WeekNumber = "" Then
            WeekNumber = "Week#"
        End If

        CreateSubFolder(newFolderPath, WeekNumber)
        newFolderPath += "\" + WeekNumber
        FullDirectory = newFolderPath
        WriteFile("ReadMe", newFolderPath)

        CreateSubFolder(newFolderPath, "\Screenshots")
        CreateSubFolder($"{newFolderPath}\Screenshots", "DiscordPost")
        CreateSubFolder($"{newFolderPath}\Screenshots", "ProjectUpdates")
        CreateSubFolder($"{newFolderPath}\Screenshots", "ICA")
        CreateSubFolder(newFolderPath, "\WorkingApplication")
        WriteFile("ReadMe", $"{newFolderPath}\WorkingApplication")

        Console.WriteLine("Project created in: " + FullDirectory) 'This tells the console to give you the full directory of the folder you created

    End Sub




    Sub SerializeProject()
        Dim myProject As New Project()
        myProject.Department = "Visual"
        myProject.Task = "Presentation"

        Dim json As String = JsonConvert.SerializeObject(myProject)

        Dim location As String = My.Computer.FileSystem.SpecialDirectories.Desktop
        Dim currentDirectory As String = FullDirectory

        Dim file As IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(FullDirectory + "\commonTasks.json", True)
        file.WriteLine(json)
        file.Close()


    End Sub


    Private Sub WriteFile(fileName As String, location As String)

        If fileName <> "" Then

            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)
            file.WriteLine("Remember to create a log document with the date, team member names, and project notes for the day.")
            file.Close()

        End If

    End Sub


    Sub CreateSubFolder(newFolderPath As String, WeekNumber As String)
        My.Computer.FileSystem.CreateDirectory(newFolderPath + "\" + WeekNumber)
    End Sub

End Module