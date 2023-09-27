using System.Text;

namespace DownMark.Extensions.Gitlab
{
    public static class ReferenceExtensions
    {
        public static MarkdownBuilder User(this MarkdownBuilder builder, string name)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append('@').Append(name);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }

        public static MarkdownBuilder Group(this MarkdownBuilder builder, string name)
        {
            return builder.User(name);
        }

        public static MarkdownBuilder Everybody(this MarkdownBuilder builder)
        {
            builder.Entities.Add("@all");
            return builder;
        }

        public static MarkdownBuilder Project(this MarkdownBuilder builder, string project)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(project).Append('>');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }

        public static MarkdownBuilder Issue(this MarkdownBuilder builder, int issue)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append('#').Append(issue);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }

        public static MarkdownBuilder MergeRequest(this MarkdownBuilder builder, int mergeRequest)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append('!').Append(mergeRequest);
            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}