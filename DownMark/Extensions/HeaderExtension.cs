using System.Text;
using DownMark.Models;

namespace DownMark.Extensions
{
    public static class HeaderExtension
    {
        public static MarkdownBuilder Header(this MarkdownBuilder builder, string text, HeaderSize size = HeaderSize.H1)
        {
            StringBuilder stringBuilder = new();

            stringBuilder = size switch
            {
                HeaderSize.H1 => stringBuilder.Append('#'),
                HeaderSize.H2 => stringBuilder.Append("##"),
                HeaderSize.H3 => stringBuilder.Append("###"),
                HeaderSize.H4 => stringBuilder.Append("####"),
                HeaderSize.H5 => stringBuilder.Append("#####"),
                HeaderSize.H6 => stringBuilder.Append("######"),
                _ => stringBuilder.Append('#'),
            };

            stringBuilder.Append(' ').Append(text);
            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}