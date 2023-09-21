using System.Text;

namespace DownMark.Extensions
{
    public static class LinkExtensions
    {
        public static MarkdownBuilder Link(this MarkdownBuilder builder, string url, string title, string altText = "")
        {
            StringBuilder sb = new();
            sb.Append('[').Append(title).Append("](").Append(url);

            if (!string.IsNullOrWhiteSpace(altText))
            {
                sb.Append(' ').Append('"').Append(altText).Append('"');
            }
            sb.Append(')');

            var markdownText = sb.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}