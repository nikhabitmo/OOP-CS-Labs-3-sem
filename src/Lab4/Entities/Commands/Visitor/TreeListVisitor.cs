using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystemUnits;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Visitor;

public class TreeListVisitor : ITreeListVisitor
{
    private readonly int _maxDepth;

    public TreeListVisitor(int maxDepth)
    {
        _maxDepth = maxDepth;
    }

    public void VisitFile(File file, int depth)
    {
        Console.WriteLine($"{GetIndent(depth)}File: {file?.Name}");
    }

    public void VisitFolder(Folder folder, int depth)
    {
        Console.WriteLine($"{GetIndent(depth)}Folder: {folder?.Name}");

        folder = folder ?? throw new OperationCanceledException(nameof(folder));

        if (depth < _maxDepth && folder.Contents != null)
        {
            foreach (IFileSystemUnit unit in folder.Contents)
            {
                unit.Accept(this, depth + 1);
            }
        }
    }

    private static string GetIndent(int depth)
    {
        return new string(' ', depth * 2);
    }
}