using System.Text;

namespace DownMark.Extensions;

public static class MathExtensions
{
    public static MarkdownBuilder Math(this MarkdownBuilder builder, string formula)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder = stringBuilder
            .Append('$')
            .Append(formula)
            .Append('$');
        var markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}
