using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class HorizontalLineTests
{
    [Fact]
    public void TestHorizontalLine()
    {
        var expected = $"***{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .HorizontalLine()
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
