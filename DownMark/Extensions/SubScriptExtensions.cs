using System.Text;

namespace DownMark.Extensions;

public static class SubScriptExtensions
{
    public static MarkdownBuilder Subscript(this MarkdownBuilder builder, string text)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("<sub>").Append(text).Append("</sub>");

        string markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}
