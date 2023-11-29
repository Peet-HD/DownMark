using System.Text;

namespace DownMark.Extensions.Gitlab;

public static class InlineDiffExtensions
{
    public static MarkdownBuilder Addition(this MarkdownBuilder builder, string text)
    {
        return AdditionDeletion(builder, text, '+');
    }
    public static MarkdownBuilder Deletion(this MarkdownBuilder builder, string text)
    {
        return AdditionDeletion(builder, text, '-');
    }
    private static MarkdownBuilder AdditionDeletion(this MarkdownBuilder builder, string text, char sign)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder
            .Append('-')
            .Append(' ')
            .Append('{')
            .Append(sign)
            .Append(' ')
            .Append(text)
            .Append(' ')
            .Append(sign)
            .Append('}');

        var markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}