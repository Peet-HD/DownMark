using System.Text;

namespace DownMark.Extensions
{
    public static class BlockQuoteExtensions
    {
        public static MarkdownBuilder Blockquote(this MarkdownBuilder builder, MarkdownBuilder blockquoteElement)
        {
            var stringBuilder = new StringBuilder();
            foreach (string item in blockquoteElement.Entities)
            {
                stringBuilder
                    .Append('>')
                    .Append(' ')
                    .AppendLine(item);
            }
            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder Blockquote(this MarkdownBuilder builder, string text)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .Append('>')
                .Append(' ')
                .Append(text);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder MultilineBlockquote(this MarkdownBuilder builder, string text)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine($">>>")
                .AppendLine(text)
                .AppendLine(">>>");

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }

}
