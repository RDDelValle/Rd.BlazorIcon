// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using Rd.BlazorIcon.IconSetBuilder;

// new BootstrapIconSetBuilder().WriteToFile(false, true);


string svgString = @"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 16 16""><path d=""M0 2a1 1 0 0 1 1-1h14a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H1a1 1 0 0 1-1-1zm8.5 0v8H15V2zm0 9v3H15v-3zm-1-9H1v3h6.5zM1 14h6.5V6H1z"" /></svg>";

// Define the regular expression pattern to match the opening and closing svg tags
string openingTagPattern = @"<svg\b[^>]*>";
string closingTagPattern = @"<\/svg>";

// Remove the opening svg tag
svgString = Regex.Replace(svgString, openingTagPattern, "", RegexOptions.IgnoreCase);

// Remove the closing svg tag
svgString = Regex.Replace(svgString, closingTagPattern, "", RegexOptions.IgnoreCase);

Console.WriteLine("Result string: " + svgString);