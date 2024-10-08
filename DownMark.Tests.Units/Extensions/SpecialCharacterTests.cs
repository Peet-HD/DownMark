using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class SpecialCharacterTests
{
    #region Whitespace
    [Fact]
    public void TestWhitespaceWithDefaultOptions()
    {
        var expected = $" {Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Whitespace()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestWhitespaceWithBlockMode()
    {
        var expected = $" {Environment.NewLine}{Environment.NewLine}";
        var options = new MarkdownOptions(MarkdownMode.Block);
        var actual = new MarkdownBuilder(options)
            .Whitespace()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestWhitespaceWithInlineMode()
    {
        var expected = $" ";
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var actual = new MarkdownBuilder(options)
            .Whitespace()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    #endregion
    #region Space
    [Fact]
    public void TestSpaceWithDefaultOptions()
    {
        var expected = $" {Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Space()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestSpaceWithBlockMode()
    {
        var expected = $" {Environment.NewLine}{Environment.NewLine}";
        var options = new MarkdownOptions(MarkdownMode.Block);
        var actual = new MarkdownBuilder(options)
            .Space()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestSpaceWithInlineMode()
    {
        var expected = $" ";
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var actual = new MarkdownBuilder(options)
            .Space()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    #endregion
    #region Character
    [Theory]
    [InlineData('!')]
    [InlineData('a')]
    public void TestCharacterWithDefaultOptions(char character)
    {
        var expected = character + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Character(character)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [InlineData('$')]
    [InlineData('&')]
    public void TestCharacterWithBlockMode(char character)
    {
        var expected = character + Environment.NewLine + Environment.NewLine;
        var options = new MarkdownOptions(MarkdownMode.Block);
        var actual = new MarkdownBuilder(options)
            .Character(character)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [InlineData('ß')]
    [InlineData('1')]
    public void TestCharacterWithInlineMode(char character)
    {
        var expected = character.ToString();
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var actual = new MarkdownBuilder(options)
            .Character(character)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    #endregion
    #region Newline
    [Theory]
    [InlineData(Models.OperatingSystem.Windows, "\r\n")]
    [InlineData(Models.OperatingSystem.Mac, "\r")]
    [InlineData(Models.OperatingSystem.Linux, "\n")]
    public void TestNewlineWithOsOptionAndWithDefaultOptions(Models.OperatingSystem os, string expected)
    {
        expected += Environment.NewLine + Environment.NewLine;
        var builder = new MarkdownBuilder();
        builder.Newline(os);
        var actual = builder.Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestNewlineWithDefaultValueAndWithDefaultOptions()
    {
        var expected = "\n" + Environment.NewLine + Environment.NewLine;
        var builder = new MarkdownBuilder();
        builder.Newline();
        var actual = builder.Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(Models.OperatingSystem.Windows, "\r\n")]
    [InlineData(Models.OperatingSystem.Mac, "\r")]
    [InlineData(Models.OperatingSystem.Linux, "\n")]
    public void TestNewlineWithOsOptionAndWithBlockMode(Models.OperatingSystem os, string expected)
    {
        expected += Environment.NewLine + Environment.NewLine;
        var options = new MarkdownOptions(MarkdownMode.Block);
        var builder = new MarkdownBuilder(options);
        builder.Newline(os);
        var actual = builder.Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestNewlineWithDefaultValueAndWithBlockMode()
    {
        var expected = "\n" + Environment.NewLine + Environment.NewLine;
        var options = new MarkdownOptions(MarkdownMode.Block);
        var builder = new MarkdownBuilder(options);
        builder.Newline();
        var actual = builder.Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(Models.OperatingSystem.Windows, "\r\n")]
    [InlineData(Models.OperatingSystem.Mac, "\r")]
    [InlineData(Models.OperatingSystem.Linux, "\n")]
    public void TestNewlineWithOsOptionAndWithInlineMode(Models.OperatingSystem os, string expected)
    {
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var builder = new MarkdownBuilder(options);
        builder.Newline(os);
        var actual = builder.Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestNewlineWithDefaultValueAndWithInlineMode()
    {
        var expected = "\n";
        var options = new MarkdownOptions(MarkdownMode.Inline);
        var builder = new MarkdownBuilder(options);
        builder.Newline();
        var actual = builder.Build();

        actual.Should().BeEquivalentTo(expected);
    }

    #endregion
}
