using System;
using System.IO;

static readonly string TableDir = @"table";

foreach (var filename in Directory.GetFiles(TableDir, "*.tab.bytes", SearchOption.AllDirectories))
{
    // Remove the first 128 bytes from the file (signature)
    var bytes = File.ReadAllBytes(filename);
    var newBytes = new byte[bytes.Length - 128];
    Array.Copy(bytes, 128, newBytes, 0, newBytes.Length);
    File.WriteAllBytes(filename, newBytes);

    // Rename the file to .tsv
    File.Move(filename, filename.Replace(".tab.bytes", string.Empty) + ".tsv");

    Console.WriteLine($"Processed {filename}");
}

Console.WriteLine("Done!");
