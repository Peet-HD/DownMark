namespace DownMark.Extensions
{
    public static class HorizontalLineExtensions
    {
        public static MarkdownBuilder HorizontalLine(this MarkdownBuilder builder)
        {
            var markdownText = "***";
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}