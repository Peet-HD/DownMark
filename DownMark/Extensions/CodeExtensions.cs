using System.Text;

namespace DownMark.Extensions
{
    public static class CodeExtensions
    {
        public static MarkdownBuilder Code(this MarkdownBuilder builder, string code, string fileFormat = "")
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine($"```{fileFormat}")
                .AppendLine(code)
                .AppendLine("```");

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}