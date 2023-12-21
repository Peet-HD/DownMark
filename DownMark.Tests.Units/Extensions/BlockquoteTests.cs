using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class BlockquoteTests
{
    [Fact]
    public void BlockquoteTest()
    {

        var blockQuote = "Hello, this is a test.";
        var expected = "> " + blockQuote + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
.Blockquote(blockQuote)
.Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void BlockquoteWithMarkdownElementsTest()
    {
        var blockQuote = new MarkdownBuilder()
            .Text("Hello ")
            .Link("https://wikipedia.org/", "Wikipedia", "This is a link to wikipedia.")
            .Text(".");

        var expected = @"> Hello 
> [Wikipedia](https://wikipedia.org/ ""This is a link to wikipedia."")
> .


";
        var actual = new MarkdownBuilder()
            .Blockquote(blockQuote)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void MultilineBlockquoteTest()
    {
        string blockQuote = @"Hello,
This is a test.";

        var expected = $@">>>
{blockQuote}
>>>


";
        var actual = new MarkdownBuilder()
            .MultilineBlockquote(blockQuote)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
