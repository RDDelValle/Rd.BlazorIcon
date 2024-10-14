namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public static class FileWriter
{
    public static void WriteToFile(string OutputDirectory, string OutputClassName, string contents)
    {
        File.WriteAllText(Path.Combine(OutputDirectory, $"{OutputClassName}.cs"), contents);
        
        Console.WriteLine($"Wrote to directory:");
        Console.WriteLine($"Output Directory: {OutputDirectory}");
        Console.WriteLine($"Output Class Name: {OutputClassName}");
        // Console.WriteLine($"Contents:");
        // Console.WriteLine(contents);
    }
}