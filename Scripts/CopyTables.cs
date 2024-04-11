using System;
using System.IO;

static readonly string NewTableDir = @"table";
static readonly string OldTableDir = @"..\Resources\table";

// Copy the new tables over the old tables
foreach (var filename in Directory.GetFiles(OldTableDir, "*.tsv", SearchOption.AllDirectories))
{
    var newFilename = filename.Replace(OldTableDir, NewTableDir);
    
    if (!File.Exists(newFilename))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"WARNING: New table does not exist! {newFilename}");
        Console.ResetColor();
        continue;
    }
    
    if (File.Exists(filename))
        File.Delete(filename);
    
    File.Copy(newFilename, filename);
    
    Console.WriteLine($"Copied {newFilename} to {filename}");
}

Console.WriteLine("Done!");
