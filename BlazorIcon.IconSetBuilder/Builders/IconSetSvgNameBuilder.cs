using System.Globalization;

namespace Rd.BlazorIcon.IconSetBuilder.Builders;

public class IconSetSvgNameBuilder
{
    /// <summary>
    /// File name to format
    /// </summary>
    public string FileName { get; init; } = string.Empty;
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Formatted file name</returns>
    public override string ToString()
    {
        return FileName.ToCSharpPropertyName();
    }
}

internal static class IconSetSvgNameBuilderStringExtensions
{
    /// <summary>
    /// Takes a file name value and formats to x C# property name.
    /// <br/>
    /// Ex: ex-directory/ex-directory/example.svg => example.svg
    /// </summary>
    /// <param name="value">filename to be formatted</param>
    /// <returns>A formatted C# property name</returns>
    public static string ToCSharpPropertyName(this string value)
        => value
            .StripDirectoriesFromFilename()
            .StripFileExtension()
            .ToPascalCase();

    /// <summary>
    /// Takes a file name value and removes the directories
    /// <br/>
    /// Ex: ex-directory/ex-directory/example.svg => example.svg
    /// </summary>
    /// <param name="value">string to be formatted</param>
    /// <returns>filename minus directories</returns>
    private static string StripDirectoriesFromFilename(this string value)
        => value.Split("/").Last();

    /// <summary>
    /// Takes a file name value and removes the extension
    /// <br/>
    /// Ex: example.svg => example
    /// </summary>
    /// <param name="value">string to be formatted</param>
    /// <returns>filename minus extension</returns>
    private static string StripFileExtension(this string value)
        => value.Split(".").First();

    /// <summary>
    /// Takes a file name value and formats to Pascal case.
    /// <br/>
    /// Ex: 1-ex-name => _1ExName
    /// <br/>
    /// Ex: ex-name => ExName
    /// </summary>
    /// <param name="value">string to be formatted</param>
    /// <returns>A pascal case property name</returns>
    private static string ToPascalCase(this string value)
    {
        // Split by hyphens
        string[] parts;
        parts = value.Split(value.Contains('_') ? '_' : '-');

        // Capitalize first letter of each part
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parts[i].ToLower());
        }

        // Concatenate parts
        string result = string.Concat(parts);

        // If the initial character of the value is a digit, prepend it with an underscore
        if (char.IsDigit(value[0]))
        {
            result = "_" + result;
        }

        return result;
    }
}