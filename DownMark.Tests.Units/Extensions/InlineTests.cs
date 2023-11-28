using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class InlineTests
{
    [Fact]
    public void TestInlineElement()
    {
        var inline = new MarkdownBuilder()
            .Text("Hello ")
            .Link("https://wikipedia.org/", "Wikipedia", "This is a link to wikipedia.")
            .Text(".");

        var expected = "Hello " +
            "[Wikipedia](https://wikipedia.org/ \"This is a link to wikipedia.\")." +
            $"{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Inline(inline)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
}
