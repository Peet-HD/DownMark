using System;
using System.Text;

namespace DownMark.Extensions
{
    public static class SectionsExtensions
    {
        public static MarkdownBuilder CollapsibleSection(this MarkdownBuilder builder, string summary, string details)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder = stringBuilder
                  .AppendLine("<p>")
                  .AppendLine("<details>")
                  .AppendLine($"<summary>{summary}</summary>")
                  .AppendLine()
                  .AppendLine(details)
                  .AppendLine()
                  .AppendLine("</details>")
                  .AppendLine("</p>");

            string markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}
