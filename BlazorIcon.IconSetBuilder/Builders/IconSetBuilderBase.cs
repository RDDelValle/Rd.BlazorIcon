using System.Text;
using Rd.BlazorIcon.IconSetBuilder.Utilities;

namespace Rd.BlazorIcon.IconSetBuilder.Builders;

public abstract class IconSetBuilderBase
{
    protected abstract string InputDirectory { get; }
    protected abstract string OutputDirectory { get; }
    protected abstract string OutputNamespace { get; }
    protected abstract string OutputClassName { get; }
    protected abstract string VendorSource { get; }
    protected abstract string VendorName { get; }
    protected abstract string VendorCopyright { get; }
    protected abstract string VendorLicense { get; }

    protected virtual void BuildIconSet()
    {
        var builder = new StringBuilder();

        var docsBlock = new DocsBlockBuilder
        {
            VendorSource = VendorSource,
            VendorName = VendorName,
            VendorCopyright = VendorCopyright,
            VendorLicense = VendorLicense
        };

        var classBuilder = new ClassBuilder
        {
            DocsBlock = docsBlock.ToString(),
            ClassName = OutputClassName,
            Content = "// SomeContent"
        };

        var namespaceBuilder = new NamespaceBuilder
        {
            Namespace = OutputNamespace,
            Content = classBuilder.ToString()
        };

        builder.AppendLine(namespaceBuilder.ToString());
        
        var outputPath = Path.Combine(OutputDirectory, $"{OutputClassName}.cs");
        File.WriteAllText(outputPath, builder.ToString());
        Console.WriteLine(builder.ToString());
    }
}