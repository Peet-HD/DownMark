using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class HorizontalLineTests
{
    [Fact]
    public void TestDefaultHorizontalLineForMarkdown()
    {
        var expected = $"***{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .HorizontalLine()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("ts", "tstststststststststs")]
    [InlineData("/\\", "/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\")]
    public void TestHorizontalLineWithText(string content, string expected)
    {
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var actual = new MarkdownBuilder(options)
            .HorizontalLine(content)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("ts", 5, "tststststs")]
    [InlineData("/\\", 5, "/\\/\\/\\/\\/\\")]
    public void TestHorizontalLineWithTextAndCustomLength(string content, int length, string expected)
    {
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var actual = new MarkdownBuilder(options)
            .HorizontalLine(content, length)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData('=', "==========")]
    [InlineData('-', "----------")]
    public void TestHorizontalLineWithCharacter(char content, string expected)
    {
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var actual = new MarkdownBuilder(options)
            .HorizontalLine(content)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData('=', 5, "=====")]
    [InlineData('-', 5, "-----")]
    public void TestHorizontalLineWithCharacterAndCustomLength(char content, int length, string expected)
    {
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var actual = new MarkdownBuilder(options)
            .HorizontalLine(content, length)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
