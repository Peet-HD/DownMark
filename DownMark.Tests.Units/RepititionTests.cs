using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units;

public class RepititionTests
{
    [Theory]
    [InlineData("Hello", 5, "HelloHelloHelloHelloHello")]
    public void TestRepitionWithString(string text, int repeat, string expected)
    {

        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Repetition(text, repeat).Build();
        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestRepitionWithStringAndDefaultCount()
    {
        var text = "Hello";
        var expected = "Hello";
        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Repetition(text).Build();
        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [InlineData('-', 5, "-----")]
    public void TestRepitionWithCharacter(char text, int repeat, string expected)
    {

        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Repetition(text, repeat).Build();
        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestRepitionWithCharacterAndWithDefaultCount()
    {
        var text = '?';
        var expected = "?";
        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Repetition(text).Build();
        actual.Should().BeEquivalentTo(expected);
    }
}
