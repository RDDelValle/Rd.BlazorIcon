using System.Text;
using System.Xml.Linq;

namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public class SvgParser
{
    private readonly StringBuilder _builder = new();

    private string Value => _builder.ToString();

    private SvgParser()
    { 
    }

    private void ParseElements(IEnumerable<XElement> elements)
    {
        foreach (var element in elements)
        {
            ParseElement(element);
        }
    }

    private void ParseElement(XElement element)
    {
        var builder = new StringBuilder();
        // Console.WriteLine(element);
                
        foreach (var innerElement in element.Elements())
        {
            var attributes = innerElement.Attributes();
            builder.Append($"<{innerElement.Name.LocalName} ");
            foreach (var attribute in attributes)
            {
                builder.Append($"{attribute.Name}=\"\"{attribute.Value}\"\" ");
            }
            builder.Append($"/>");
        }
        _builder.Append(builder);
    }

    public static string Parse(string file)
    {
        var builder = new SvgParser();
        var svgContent = File.ReadAllText(file);
        var svgDocument = XDocument.Parse(svgContent);
        var elements = svgDocument.Elements();
        builder.ParseElements(elements);
        return builder.Value;
    }
}