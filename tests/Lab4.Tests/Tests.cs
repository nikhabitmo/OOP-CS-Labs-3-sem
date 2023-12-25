using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStates;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemStrategy;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;
using Itmo.ObjectOrientedProgramming.Lab4.Models.CommandResults.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]
    public void ParseConnectCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new DisconnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("connect C:// -m local", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseTreeListCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("tree list -d 3", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseDisconnectCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("disconnect", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseTreeGoToCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("tree goto /folder/subfolder", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseFileMoveCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("file move /source/file.txt /destination", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseFileCopyCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("file copy /source/file.txt /destination", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseFileMoveCommandWithMissingArgumentsReturnsErrorResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("file move /source/file.txt", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultError>(result);
    }

    [Fact]
    public void ParseFileCopyCommandWithInvalidPathsReturnsErrorResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("file copy", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultError>(result);
    }

    [Fact]
    public void ParseTreeListCommandWithInvalidDepthFlagReturnsErrorResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("tree list -d invalid_depth", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultError>(result);
    }

    [Fact]
    public void ParseFileDeleteCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("file delete file.txt", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseFileRenameCommandReturnsSuccessResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("file rename /old/file.txt /newfile.txt", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultSuccess>(result);
    }

    [Fact]
    public void ParseFileShowCommandWithInvalidModeReturnsErrorResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("file show /file.txt -m invalid_mode", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultError>(result);
    }

    [Fact]
    public void ParseInvalidCommandReturnsErrorResult()
    {
        // Arrange
        var localFileSystemStrategy = new LocalFileSystemStrategy(new Folder());
        var fileSystemState =
            new ConnectedFileSystem(localFileSystemStrategy, new FileSystem(localFileSystemStrategy));
        var parser = new ParserCommands();

        // Act
        CommandParserResult result = parser.Parse("invalid_command", fileSystemState);

        // Assert
        Assert.IsType<CommandParserResultError>(result);
    }
}
