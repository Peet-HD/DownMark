using System.Text;

namespace DownMark.Extensions.Gitlab
{
    public static class GitlabReferenceExtensions
    {
        #region Users and Groups
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
        #endregion
        #region Reference Links
        public static MarkdownBuilder Project(this MarkdownBuilder builder, string project)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(project).Append('>');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder Issue(this MarkdownBuilder builder, int issue, string? projectPath = null)
        {
            return InternalLinking(builder, issue, '#', projectPath);
        }
        public static MarkdownBuilder MergeRequest(this MarkdownBuilder builder, int mergeRequest, string? projectPath = null)
        {
            return InternalLinking(builder, mergeRequest, '!', projectPath);
        }
        public static MarkdownBuilder Snippet(this MarkdownBuilder builder, int snippet, string? projectPath = null)
        {
            return InternalLinking(builder, snippet, '$', projectPath);
        }
        public static MarkdownBuilder Epic(this MarkdownBuilder builder, int epic, string? projectPath = null)
        {
            return InternalLinking(builder, epic, '&', projectPath);
        }
        private static MarkdownBuilder InternalLinking(MarkdownBuilder builder, int id, char refChar, string? projectPath)
        {
            var stringBuilder = new StringBuilder();
            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath);
            }

            stringBuilder.Append(refChar).Append(id);
            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        #endregion
        public static MarkdownBuilder Iteration(this MarkdownBuilder builder, string title)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .Append('*')
                .Append("iteration")
                .Append(':')
                .Append('"')
                .Append(title)
                .Append('"');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder Vulnerability(this MarkdownBuilder builder, int project, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .Append('[')
                .Append("vulnerability")
                .Append(':');

            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath).Append('/');
            }

            stringBuilder
                .Append(project)
                .Append(']');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder FeatureFlag(this MarkdownBuilder builder, int project, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .Append('[')
                .Append("feature_flag")
                .Append(':');

            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath).Append('/');
            }

            stringBuilder
                .Append(project)
                .Append(']');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        #region Label
        public static MarkdownBuilder Label(this MarkdownBuilder builder, int id, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();
            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath);
            }
            stringBuilder
                .Append('~')
                .Append(id);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder Label(this MarkdownBuilder builder, string name, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();
            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath);
            }
            stringBuilder
                .Append('~')
                .Append('"')
                .Append(name)
                .Append('"');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        #endregion
        #region Milestone
        public static MarkdownBuilder Milestone(this MarkdownBuilder builder, int id, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();
            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath);
            }
            stringBuilder
                .Append('%')
                .Append(id);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder Milestone(this MarkdownBuilder builder, string name, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();
            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath);
            }
            stringBuilder
                .Append('%')
                .Append('"')
                .Append(name)
                .Append('"');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        #endregion
        #region Commits
        public static MarkdownBuilder Commit(this MarkdownBuilder builder, string commit, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();
            if (projectPath is not null)
            {
                stringBuilder
                    .Append(projectPath)
                    .Append('@');
            }
            stringBuilder
                .Append(commit);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder CommitRange(this MarkdownBuilder builder, string from, string to, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();
            if (projectPath is not null)
            {
                stringBuilder
                    .Append(projectPath)
                    .Append('@');
            }
            stringBuilder
                .Append(from)
                .Append("...")
                .Append(to);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        #endregion
        public static MarkdownBuilder FileReference(this MarkdownBuilder builder, string title, string filePath, int? line = null)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append('[').Append(title).Append(']')
                .Append('(').Append(filePath);

            if (line is not null)
            {
                stringBuilder.Append("#L").Append(line);
            }
            stringBuilder.Append(')');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder Alert(this MarkdownBuilder builder, int id, string? projectPath = null)
        {
            var stringBuilder = new StringBuilder();

            if (projectPath is not null)
            {
                stringBuilder.Append(projectPath);
            }

            stringBuilder.Append('^').Append("alert").Append('#').Append(id);

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
        public static MarkdownBuilder Contact(this MarkdownBuilder builder, string email)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append('[')
                .Append("contact")
                .Append(':')
                .Append(email)
                .Append(']');

            var markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}