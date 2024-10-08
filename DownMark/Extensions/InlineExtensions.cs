using System;
using System.Text;

namespace DownMark.Extensions;

public static class InlineExtensions
{
    [Obsolete("Will be removed in future release. Please consider using \n\"new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline))\"\n instead.", DiagnosticId ="DOWNMARK-0001")]
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
