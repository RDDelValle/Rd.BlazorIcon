namespace Rd.BlazorIcon.IconSetBuilder.Builders;

public abstract class IconSetPartialFileBuilder
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
    public abstract IconSetPartialClassBuilder IconSetPartialClassBuilder { get; init; }
    
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
        var contents = IconSetPartialClassBuilder.ToString();
        if (writeToFile)
        {
            File.WriteAllText(Path.Combine(OutputDirectory, $"{OutputFilename}.cs"), contents);

            Console.WriteLine($"Wrote to file: {OutputDirectory}/{OutputFilename}.cs");
        }
        
        if(printFileToConsole)
            Console.WriteLine(contents);
    }
}