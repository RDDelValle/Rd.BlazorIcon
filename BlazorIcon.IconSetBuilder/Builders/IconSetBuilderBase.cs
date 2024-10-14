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
        Directories.EnsureRequiredDirectoriesExist(InputDirectory, OutputDirectory);
        var svgFiles = Directories.GetSvgFilesFromDirectory(InputDirectory);
        var propertiesBuilder = new PropertiesBuilder();
        foreach (var file in svgFiles)
        {
            var propertyName = file.ToCSharpPropertyName();
            var parsedElements = SvgParser.Parse(file);
            var property = new PropertyBuilder
            {
                Name = propertyName,
                Value = parsedElements
            }.ToString();
            propertiesBuilder.AppendProperty(property);
        }

        var value = new NamespaceBuilder
        {
            Namespace = OutputNamespace,
            Content = new ClassBuilder
            {
                DocsBlock = new DocsBlockBuilder
                {
                    VendorSource = VendorSource,
                    VendorName = VendorName,
                    VendorCopyright = VendorCopyright,
                    VendorLicense = VendorLicense
                }.ToString(),
                ClassName = OutputClassName,
                Content = propertiesBuilder.ToString()
            }.ToString()
        }.ToString();
        
        FileWriter.WriteToFile(OutputDirectory, OutputClassName, value);
    }
}