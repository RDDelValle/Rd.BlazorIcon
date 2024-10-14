namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public static class Directories
{
    public static string[] GetSvgFilesFromDirectory(string fromDirectory)
    {
        var svgFiles = Directory.GetFiles(fromDirectory, "*.svg");
        if (svgFiles.Length == 0)
            throw new FileNotFoundException($"No SVG files found in the directory: {fromDirectory}.");
        return svgFiles;
    }

    public static void EnsureRequiredDirectoriesExist(string inputDirectory, string outputDirectory)
    {
        if (!Directory.Exists(inputDirectory))
            throw new DirectoryNotFoundException($"Source directory not found: {inputDirectory}");
        if (!Directory.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);
    }
}