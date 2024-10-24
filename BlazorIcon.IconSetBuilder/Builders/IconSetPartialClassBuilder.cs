using System.Text;

namespace Rd.BlazorIcon.IconSetBuilder.Builders;

/// <summary>
/// IconSetBuilder
/// A string builder class that adds utility methods to make builder usage mode readable.
/// </summary>
public sealed class IconSetPartialClassBuilder()
{
    private readonly StringBuilder _builder = new();
    
    public string Namespace { get; init; } = string.Empty;
    public string PrimaryClass { get; init; } = string.Empty;
    public string[] SecondaryClasses { get; init; } = [];
    
    public override string ToString()
    {
        OpenNamespace();
        OpenPrimaryClass();
        foreach (var name in SecondaryClasses)
        {
            AppendSecondaryClass(name);
        }
        ClosePrimaryClass();
        CloseNamespace();
        return _builder.ToString();
    }
    
    private void OpenNamespace()
    {
        AppendLine("using System.Diagnostics.CodeAnalysis;");
        AppendLine("");
        AppendLine($"namespace {Namespace}");
        AppendLine("{");
    }
    
    private void CloseNamespace()
    {
        AppendLine("}");
    }

    private void OpenPrimaryClass()
    {
        AppendLine($"   [ExcludeFromCodeCoverage]");
        AppendLine($"   public partial class {PrimaryClass}");
        AppendLine("    {");
    }
    
    private void ClosePrimaryClass()
    {
        AppendLine("    }");
    }
    
    private void AppendSecondaryClass(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            return;
        
        AppendLine($"       public partial class {name}");
        AppendLine("        {");
        AppendLine("        }");
    }
    
    private void AppendLine(string line)
    {
        _builder.AppendLine(line);
    }
}