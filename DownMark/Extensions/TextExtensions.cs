using System;
using System.Text;
using static DownMark.Extensions.TextExtensions;

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

    public static MarkdownBuilder Whitespace(this MarkdownBuilder builder)
    {
        builder.Entities.Add(" ");
        return builder;
    }
    public static MarkdownBuilder Space(this MarkdownBuilder builder) => builder.Whitespace();
    public static MarkdownBuilder Newline(this MarkdownBuilder builder, OperatingSystem operatingSystem = OperatingSystem.Linux)
    {
        var newlineSymbol = operatingSystem switch
        {
            OperatingSystem.Linux => "\n",
            OperatingSystem.Windows => "\r\n",
            OperatingSystem.Mac => "\r",
            _ => "\n"
        };

        builder.Entities.Add(newlineSymbol);
        return builder;
    }

    public enum TextStyle
    {
        None,
        Bold,
        Italic,
        BoldItalic
    }

    public enum OperatingSystem
    {
        Linux,
        Windows,
        Mac
    }
}