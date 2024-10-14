using System.Text;

namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public class PropertiesBuilder
{
    private readonly StringBuilder _builder = new();

    public void AppendProperty(string property)
    {
        _builder.AppendLine(property);
    }
    
    public override string ToString()
        => _builder.ToString();
}