using System.Text;

namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public class NamespaceBuilder
{
    private readonly StringBuilder _builder = new();
    public string? Namespace { get; set; }
    public string? Content { get; set; }
    
    public override string ToString()
    {
        _builder.AppendLine($"namespace {Namespace}");
        _builder.AppendLine("{");
        _builder.AppendLine(Content);
        _builder.AppendLine("}");
        return _builder.ToString();
    }
}