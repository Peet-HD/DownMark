using System.Text;

namespace DownMark.Extensions;

public static class KeyboardExtensions
{
    public static MarkdownBuilder KeyboardTag(this MarkdownBuilder builder, string key)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("<kdb>").Append(key).Append("</kbd>");

        string markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}
