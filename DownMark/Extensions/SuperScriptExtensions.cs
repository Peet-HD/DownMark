using System.Text;

namespace DownMark.Extensions
{
    public static class SuperScriptExtensions
    {
        public static MarkdownBuilder SuperScript(this MarkdownBuilder builder, string text)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<sup>").Append(text).Append("</sup>");

            string markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}
