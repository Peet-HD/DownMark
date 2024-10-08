using System.Text;
using DownMark.Models;

namespace DownMark.Extensions;

public static class TextExtensions
{
    public static MarkdownBuilder Text(this MarkdownBuilder builder, string content, TextStyle style = TextStyle.None)
    {
        var stringBuilder = new StringBuilder();

        string styling = style switch
        {
            TextStyle.Bold => "**",
            TextStyle.Italic => "*",
            TextStyle.BoldItalic => "***",
            TextStyle.None => "",
            _ => "",
        };

        stringBuilder = stringBuilder
            .Append(styling)
            .Append(content)
            .Append(styling);

        var markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
    public static MarkdownBuilder Text(this MarkdownBuilder builder, char content, TextStyle style = TextStyle.None)
    {
        var stringBuilder = new StringBuilder();

        string styling = style switch
        {
            TextStyle.Bold => "**",
            TextStyle.Italic => "*",
            TextStyle.BoldItalic => "***",
            TextStyle.None => "",
            _ => "",
        };

        stringBuilder = stringBuilder
            .Append(styling)
            .Append(content)
            .Append(styling);

        var markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}