using DownMark.Extensions;

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

        Assert.Equal(expected, actual);
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

        Assert.Equal(expected, actual);
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

        Assert.Equal(expected, actual);
    }
}
