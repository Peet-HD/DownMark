using DownMark.Extensions;
using DownMark.Extensions.Gitlab;

namespace DownMark.Tests.Units.Extensions.Gitlab
{
    public class GitlabInlineDiffTests
    {
        [Fact]
        public void AdditionTest()
        {
            var text = Guid.NewGuid().ToString();
            var expected = $"- {{+ {text} +}}" + Environment.NewLine + Environment.NewLine;
            var actual = new MarkdownBuilder()
                .Addition(text)
                .Build();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void DeletionTest()
        {
            var text = Guid.NewGuid().ToString();
            var expected = $"- {{- {text} -}}" + Environment.NewLine + Environment.NewLine;
            var actual = new MarkdownBuilder()
                .Deletion(text)
                .Build();

            Assert.Equal(expected, actual);
        }
    }
}
