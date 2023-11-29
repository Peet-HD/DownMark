using System.Text;

namespace DownMark.Extensions.Gitlab;

public static class TableOfContentsExtensions
{
    /// <summary>
    /// This method produces a table of content for the following headings.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static MarkdownBuilder TableOfContents(this MarkdownBuilder builder)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine().AppendLine("[[_TOC_]]").AppendLine();

        var markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}
