using System.Text;

namespace Rd.BlazorIcon.IconSetBuilder;

/// <summary>
/// IconSetBuilder
/// A string builder class that adds utility methods to make builder usage mode readable.
/// </summary>
public sealed class IconSetClassBuilder()
{
    private readonly StringBuilder _builder = new();
    public string? ProjectRepo { get; init; } = "https://github.com/RDDelValle/Rd.BlazorIcons";
    public string? VendorSource { get; init; }
    public string? VendorName { get; init; }
    public string? VendorCopyright { get; init; }
    public string? VendorLicense { get; init; }
    public string Namespace { get; init; } = string.Empty;
    public string PrimaryClass { get; init; } = string.Empty;
    public string? SecondaryClass { get; init; }
    public string? TertiaryClass { get; init; }
    public Dictionary<string, object> Icons { get; init; } = new();

    public void AddIcon(string name, string icon)
    {
        Icons.Add(name, icon);
    }
    
    public override string ToString()
    {
        OpenNamespace();
        OpenPrimaryClass();
        OpenSecondaryClass();
        OpenTertiaryClass();
        foreach (var icon in Icons)
        {
            AppendIcon(icon.Key, icon.Value);
        }
        CloseTertiaryClass();
        CloseSecondaryClass();
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
        if(SecondaryClass is null && TertiaryClass is null)
        {
            AppendDocsBlock();
            AppendLine($"   [ExcludeFromCodeCoverage]");
        }
        AppendLine($"   public partial class {PrimaryClass}");
        AppendLine("    {");
    }
    
    private void ClosePrimaryClass()
    {
        AppendLine("    }");
    }
    
    private void OpenSecondaryClass()
    {
        if (string.IsNullOrWhiteSpace(SecondaryClass)) 
            return;
        if (TertiaryClass is null)
        {
            AppendDocsBlock();
            AppendLine($"       [ExcludeFromCodeCoverage]");
        }
        AppendLine($"       public partial class {SecondaryClass}");
        AppendLine("        {");
    }
    private void CloseSecondaryClass()
    {
        if (string.IsNullOrWhiteSpace(SecondaryClass)) 
            return;
        AppendLine("        }");
    }
    
    private void OpenTertiaryClass()
    {
        if (string.IsNullOrWhiteSpace(TertiaryClass)) 
            return;
            
        AppendDocsBlock();
        AppendLine($"           [ExcludeFromCodeCoverage]");
        AppendLine($"           public partial class {TertiaryClass}");
        AppendLine("            {");
    }
    
    private void CloseTertiaryClass()
    {
        if (string.IsNullOrWhiteSpace(TertiaryClass)) 
            return;
        AppendLine("            }");
    }
    
    private void AppendDocsBlock()
    {
        var tabSpaces = !string.IsNullOrWhiteSpace(TertiaryClass)
            ? "             "
            : !string.IsNullOrWhiteSpace(SecondaryClass)
                ? "         "
                : "     ";
        AppendLine($"{tabSpaces}///<summary>");
        AppendLine($"{tabSpaces}///   This file was generated by Rd.BlazorIcon.IconSetBuilder({ProjectRepo})");
        AppendLine($"{tabSpaces}///   Generated On: {DateTime.Now.ToShortDateString()} at {DateTime.Now.TimeOfDay}");
        if(!string.IsNullOrWhiteSpace(VendorCopyright) || !string.IsNullOrWhiteSpace(VendorLicense))
            AppendLine($"{tabSpaces}///   Note: View vendor copyright and/or license.");
        if(!string.IsNullOrWhiteSpace(VendorName))
            AppendLine($"{tabSpaces}///   Vendor: {VendorName}");
        if(!string.IsNullOrWhiteSpace(VendorSource))
            AppendLine($"{tabSpaces}///   Vendor Source: {VendorSource}");
        if(!string.IsNullOrWhiteSpace(VendorCopyright))
            AppendLine($"{tabSpaces}///   Vendor Copyright: {VendorCopyright}");
        if(!string.IsNullOrWhiteSpace(VendorLicense))
            AppendLine($"{tabSpaces}///   Vendor License: {VendorLicense}");
        AppendLine($"{tabSpaces}///</summary>");
    }
    
    private void AppendIcon(string name, object icon)
    {
        var tabSpaces = !string.IsNullOrWhiteSpace(TertiaryClass)
            ? "                 "
            : !string.IsNullOrWhiteSpace(SecondaryClass)
                ? "             "
                : "         ";
        _builder.AppendLine($"{tabSpaces}public const string {name} = @\"{icon}\";");
    }
    
    private void AppendLine(string line)
    {
        _builder.AppendLine(line);
    }
}