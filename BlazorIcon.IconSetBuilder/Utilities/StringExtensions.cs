using System.Globalization;

namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public static class StringExtensions
{
    public static string ToCSharpPropertyName(this string filename)
        => filename
            .StripDirectoriesFromFilename()
            .StripFileExtension()
            .ToPascalCase();

    private static string StripDirectoriesFromFilename(this string filename)
        => filename.Split("/").Last();

    private static string StripFileExtension(this string filename)
        => filename.Split(".").First();

    private static string ToPascalCase(this string filename)
    {
        // Split by hyphens
        string[] parts = filename.Split('-');

        // Capitalize first letter of each part
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parts[i].ToLower());
        }

        // Concatenate parts
        string result = string.Concat(parts);

        // If the initial character of the value is a digit, prepend it with an underscore
        if (char.IsDigit(filename[0]))
        {
            result = "_" + result;
        }

        return result;
    }
}