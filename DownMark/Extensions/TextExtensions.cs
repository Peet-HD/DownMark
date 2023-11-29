using System.Text;

namespace DownMark.Extensions;

public static class TextExtensions
{
    public static MarkdownBuilder Text(this MarkdownBuilder builder, string text, TextStyle style = TextStyle.None)
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
            .Append(text)
            .Append(styling);

        var markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }

    public enum TextStyle
    {
        None,
        Bold,
        Italic,
        BoldItalic
    }
}