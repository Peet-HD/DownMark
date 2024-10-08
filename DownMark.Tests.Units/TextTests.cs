using DownMark.Extensions;
using DownMark.Models;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units;

public class TextTests
{
    [Theory]
    [InlineData(TextStyle.Bold, "Hallo", "**Hallo**")]
    [InlineData(TextStyle.Italic, "Hallo", "*Hallo*")]
    [InlineData(TextStyle.BoldItalic, "Hallo", "***Hallo***")]
    [InlineData(TextStyle.None, "Hallo", "Hallo")]
    public void TestTextWithStyling(TextStyle style, string text, string expected)
    {

        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Text(text, style).Build();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TestTextWithoutStyling()
    {
        var text = "Hallo das ist ein Test";
        var expected = text;

        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Text(text).Build();
        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [InlineData(TextStyle.Bold, 'R', "**R**")]
    [InlineData(TextStyle.Italic, 'R', "*R*")]
    [InlineData(TextStyle.BoldItalic, 'R', "***R***")]
    [InlineData(TextStyle.None, 'R', "R")]
    public void TestCharacterWithStyling(TextStyle style, char text, string expected)
    {

        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Text(text, style).Build();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TestCharacterWithoutStyling()
    {
        var text = '%';
        var expected = text.ToString();

        var markdownBuilder = new MarkdownBuilder(new MarkdownOptions(MarkdownMode.Inline));

        var actual = markdownBuilder.Text(text).Build();
        actual.Should().BeEquivalentTo(expected);
    }
}
