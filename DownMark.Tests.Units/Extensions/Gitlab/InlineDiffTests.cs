using DownMark.Extensions.Gitlab;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions.Gitlab;

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

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void DeletionTest()
    {
        var text = Guid.NewGuid().ToString();
        var expected = $"- {{- {text} -}}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Deletion(text)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
