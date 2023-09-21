using System.Text;
using DownMark.Models;

namespace DownMark.Extensions
{
    public static class ListExtensions
    {
        public static MarkdownBuilder List(this MarkdownBuilder builder, MarkdownList list)
        {
            var stringBuilder = new StringBuilder();

            string markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}
