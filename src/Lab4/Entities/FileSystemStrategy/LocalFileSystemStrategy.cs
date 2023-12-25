using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Modes.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;

public class LocalFileSystemStrategy : IFileSystemStrategy
{
    public LocalFileSystemStrategy(Folder rootFolder)
    {
        RootFolder = rootFolder;
    }

    public string WorkingDirectory { get; set; } = string.Empty;
    public Folder RootFolder { get; set; }

    public CommandResult TreeGoTo(string path)
    {
        WorkingDirectory = path;

        return new CommandResultSuccess();
    }

    public CommandResult TreeList(int depth, ITreeListVisitor visitor)
    {
        RootFolder.Accept(visitor, depth);

        return new CommandResultSuccess();
    }

    public CommandResult DeleteFile(string path)
    {
        try
        {
            string fullPath = System.IO.Path.GetFullPath(path);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                return new CommandResultSuccess { Message = "File deleted successfully." };
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            return new CommandResultError { Message = $"File not found: {ex.Message}" };
        }
        catch (System.IO.IOException ex)
        {
            return new CommandResultError { Message = $"Error deleting file: {ex.Message}" };
        }
        catch (UnauthorizedAccessException ex)
        {
            return new CommandResultError { Message = $"Unauthorized access: {ex.Message}" };
        }

        return new CommandResultError { Message = "Something went wrong" };
    }

    public CommandResult CopyFile(string sourcePath, string destinationPath)
    {
        try
        {
            string fullSourcePath = System.IO.Path.GetFullPath(sourcePath);
            string fullDestinationPath = System.IO.Path.GetFullPath(destinationPath);

            if (System.IO.File.Exists(fullSourcePath))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fullDestinationPath) ??
                                                    string.Empty);

                System.IO.File.Copy(fullSourcePath, fullDestinationPath, true);

                return new CommandResultSuccess { Message = "File copied successfully." };
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            return new CommandResultError { Message = $"Source file not found: {ex.Message}" };
        }
        catch (System.IO.IOException ex)
        {
            return new CommandResultError { Message = $"Error copying file: {ex.Message}" };
        }
        catch (UnauthorizedAccessException ex)
        {
            return new CommandResultError { Message = $"Unauthorized access: {ex.Message}" };
        }

        return new CommandResultError { Message = "Something went wrong" };
    }

    public CommandResult ShowFile(string path, OutputMode mode)
    {
        if (mode is ConsoleOutputMode)
        {
            Console.WriteLine(System.IO.File.ReadLines(path));

            return new CommandResultLogging { Message = "The file was successfully showed" };
        }

        return new CommandResultError { Message = "Something went wrong" };
    }

    public CommandResult MoveFile(string sourcePath, string destinationPath)
    {
        try
        {
            if (System.IO.File.Exists(sourcePath))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(destinationPath) ??
                                                    string.Empty);

                System.IO.File.Move(sourcePath, destinationPath);

                return new CommandResultSuccess { Message = "File moved successfully." };
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            return new CommandResultError { Message = $"Source file not found: {ex.Message}" };
        }
        catch (System.IO.IOException ex)
        {
            return new CommandResultError { Message = $"Error moving file: {ex.Message}" };
        }
        catch (UnauthorizedAccessException ex)
        {
            return new CommandResultError { Message = $"Unauthorized access: {ex.Message}" };
        }

        return new CommandResultError { Message = "Something went wrong" };
    }

    public CommandResult RenameFile(string path, string filename)
    {
        try
        {
            string fullPath = System.IO.Path.GetFullPath(path);

            if (System.IO.File.Exists(fullPath))
            {
                string? directory = System.IO.Path.GetDirectoryName(fullPath);
                if (directory != null)
                {
                    string newFilePath = System.IO.Path.Combine(directory, filename);

                    System.IO.File.Move(fullPath, newFilePath);
                }

                return new CommandResultSuccess { Message = "File renamed successfully." };
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            return new CommandResultError { Message = $"File not found: {ex.Message}" };
        }
        catch (System.IO.IOException ex)
        {
            return new CommandResultError { Message = $"Error renaming file: {ex.Message}" };
        }
        catch (UnauthorizedAccessException ex)
        {
            return new CommandResultError { Message = $"Unauthorized access: {ex.Message}" };
        }

        return new CommandResultError { Message = "Something went wrong" };
    }
}