using System.Text;

namespace DownMark.Extensions;

public static class InlineExtensions
{
    public static MarkdownBuilder Inline(this MarkdownBuilder builder, MarkdownBuilder inlineElement)
    {
        var stringBuilder = new StringBuilder();
        foreach (string item in inlineElement.Entities)
        {
            stringBuilder.Append(item);
        }
        var markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}
