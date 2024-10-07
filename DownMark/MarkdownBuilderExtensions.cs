using System.Collections.Generic;
using System.Text;

namespace DownMark;

public static class MarkdownBuilderExtensions
{
    public static string Build(this MarkdownBuilder markdownBuilder)
    {
        StringBuilder stringBuilder = new();

        stringBuilder = markdownBuilder.Options.Mode switch
        {
            MarkdownMode.Block => stringBuilder.ApplyBlockMode(markdownBuilder.Entities),
            MarkdownMode.Inline => stringBuilder.ApplyInlineMode(markdownBuilder.Entities),
            _ => throw new System.NotImplementedException()
        };

        return stringBuilder.ToString();
    }

    private static StringBuilder ApplyBlockMode(this StringBuilder stringBuilder, List<string> entities)
    {
        foreach (string item in entities)
        {
            stringBuilder.AppendLine(item);
            stringBuilder.AppendLine();
        }
        return stringBuilder;
    }
    private static StringBuilder ApplyInlineMode(this StringBuilder stringBuilder, List<string> entities)
    {
        foreach (string item in entities)
        {
            stringBuilder.Append(item);
        }
        return stringBuilder;
    }
}