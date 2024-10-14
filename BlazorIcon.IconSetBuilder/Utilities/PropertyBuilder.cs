namespace Rd.BlazorIcon.IconSetBuilder.Utilities;

public class PropertyBuilder
{
    public string? Name { get; set; }
    public string? Value { get; set; }

    public override string ToString()
    {
        return $"           public const string {Name} = {Value};";
    }
}