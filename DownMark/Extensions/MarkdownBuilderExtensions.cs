using System.Text;

namespace DownMark.Extensions
{
    public static class MarkdownBuilderExtensions
    {
        public static string Build(this MarkdownBuilder markdownBuilder)
        {
            StringBuilder stringBuilder = new();


            foreach (string item in markdownBuilder.Entities)
            {
                stringBuilder.AppendLine(item);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}