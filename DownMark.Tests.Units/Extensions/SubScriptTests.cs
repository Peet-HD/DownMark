using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class SubScriptTests {
    [Fact]
    public void SubScriptTest()
    {
        var sub = Guid.NewGuid().ToString();
        var expected = $"<sub>{sub}</sub>" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Subscript(sub)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
