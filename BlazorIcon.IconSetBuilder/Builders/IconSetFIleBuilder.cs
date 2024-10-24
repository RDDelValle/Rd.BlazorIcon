using System.Xml.Linq;

namespace Rd.BlazorIcon.IconSetBuilder.Builders;

public abstract class IconSetFileBuilder
{
    /// <summary>
    /// Directory where icon set class should be witten
    /// </summary>
    public abstract string OutputDirectory { get; init; }
    
    /// <summary>
    /// Name of the new icons set .cs class to be written
    /// </summary>
    public abstract string OutputFilename { get; init; }
    
    /// <summary>
    /// Used for building the class that is to be printed to file.
    /// </summary>
    public abstract IconSetClassBuilder IconSetClassBuilder { get; init; }
    
    /// <summary>
    /// <b>WhiteListIcons:</b>
    /// If left null the OnBuildFile method should process all icons.
    /// Else it will only precess icons in whitelist.<br/>
    /// <b>Value should that of the svg filename</b>:
    /// Usually the vendor classname minus the vendor prefix.
    /// ex: bi-x-lg = x-lg<br/>
    /// <b>Useful for custom slim builds in projects.</b>
    /// </summary>
    public abstract string[]? WhiteListIcons { get; init; }
    
    /// <summary>
    /// Method should read svg icons from file or files, parse them and add them to IconSetClassBuilder
    /// </summary>
    protected abstract void BuildIconSet();

    /// <summary>
    /// Reads and return svg file
    /// </summary>
    /// <param name="svgFileName">name of file</param>
    /// <returns></returns>
    protected XElement ReadSvgFile(string svgFileName)
        => XElement.Load(svgFileName, LoadOptions.None);

    /// <summary>
    /// Reads all directories from directory
    /// </summary>
    /// <param name="directory">Directory that contains directories to read</param>
    /// <returns>Array of directories in directory</returns>
    /// <exception cref="DirectoryNotFoundException">If directory no found</exception>
    /// <exception cref="FileNotFoundException">If no directories in directory</exception>
    protected string[] GetDirectoriesFromDirectory(string directory)
    {
        if (!Directory.Exists(directory))
            throw new DirectoryNotFoundException($"Source directory not found: {directory}");
        var directories = Directory.GetDirectories(directory);
        if (directories.Length == 0)
            throw new FileNotFoundException($"No directories found in the directory: {directory}.");
        Console.WriteLine($"Read {directories.Length} directories. From directory: {directory}");
        return directories;
    }
    
    /// <summary>
    /// Reads a single svg from directory
    /// </summary>
    /// <param name="svgDirectory">Directory that contains svg to read</param>
    /// <param name="svgFileName">Name of svg file</param>
    /// <returns>Svg file from directory</returns>
    /// <exception cref="DirectoryNotFoundException">If directory not found<</exception>
    /// <exception cref="FileNotFoundException">If svg does not exist in directory</exception>
    protected string GetSvgFileFromDirectory(string svgDirectory, string svgFileName)
    {
        if (!Directory.Exists(svgDirectory))
            throw new DirectoryNotFoundException($"Source directory not found: {svgDirectory}");
        var svgFile = Directory.GetFiles(svgDirectory, $"{svgFileName}.svg").First();
        if (svgFile is null)
            throw new FileNotFoundException($"SVG file: {svgFileName} not found in the directory: {svgDirectory}.");
        Console.WriteLine($"Read {svgFileName}. From directory: {svgDirectory}");
        return svgFile;
    }
    
    /// <summary>
    /// Reads all svg file from directory
    /// </summary>
    /// <param name="svgDirectory">Directory that contains svg to read</param>
    /// <returns>Array of file names in directory</returns>
    /// <exception cref="DirectoryNotFoundException">If directory not found</exception>
    /// <exception cref="FileNotFoundException">If no files exist in directory</exception>
    protected string[] GetSvgFilesFromDirectory(string svgDirectory)
    {
        if (!Directory.Exists(svgDirectory))
            throw new DirectoryNotFoundException($"Source directory not found: {svgDirectory}");
        var svgFiles = Directory.GetFiles(svgDirectory, "*.svg");
        if (svgFiles.Length == 0)
            throw new FileNotFoundException($"No SVG files found in the directory: {svgDirectory}.");
        Console.WriteLine($"Read {svgFiles.Length} SVG files. From directory: {svgDirectory}");
        return svgFiles;
    }
     
    /// <summary>
    /// <b>WriteToFile</b>
    /// Write icon set to file.
    /// </summary>
    /// <param name="printFileToConsole">Show file output in console.</param>
    /// <param name="writeToFile">Write icons set to file. Useful when only wanting console output.</param>
    public virtual void WriteToFile(bool printFileToConsole = false, bool writeToFile = true)
    {
        if(!Directory.Exists(OutputDirectory))
            Directory.CreateDirectory(OutputDirectory);
        BuildIconSet();
        var contents = IconSetClassBuilder.ToString();
        if (writeToFile)
        {
            File.WriteAllText(Path.Combine(OutputDirectory, $"{OutputFilename}.cs"), contents);

            Console.WriteLine($"{IconSetClassBuilder.Icons.Count} icons written to file: {OutputDirectory}/{OutputFilename}.cs");
        }
        
        if(printFileToConsole)
            Console.WriteLine(contents);
    }
}