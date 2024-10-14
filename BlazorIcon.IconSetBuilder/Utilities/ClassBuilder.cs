using System.Text;

namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public class ClassBuilder
{
    private readonly StringBuilder _builder = new();
    public string? ClassName { get; set; }
    public string? Content { get; set; }
    public string? DocsBlock { get; set; }

    public override string ToString()
    {
        if (!string.IsNullOrWhiteSpace(DocsBlock))
            _builder.AppendLine(DocsBlock);
        _builder.AppendLine($"      public class {ClassName}");
        _builder.AppendLine("       {");
        _builder.AppendLine(Content);
        _builder.AppendLine("       }");
        return _builder.ToString();
    }
}