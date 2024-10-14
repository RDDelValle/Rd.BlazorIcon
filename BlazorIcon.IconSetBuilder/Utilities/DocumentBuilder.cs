using System.Text;

namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public class DocumentBuilder
{
    private readonly StringBuilder _builder = new();
    public NamespaceBuilder? NamespaceBuilder { get; set; }
    public DocsBlockBuilder? DocsBlockBuilder { get; set; }
    public ClassBuilder? ClassBuilder { get; set; }
    
    // public override string ToString()
    // {
    //     
    // }
}