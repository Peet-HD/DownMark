using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class KeyboardTests
{
    [Fact]
    public void KeyboardTest()
    {
        var key = "Enter";
        var expected = $"<kdb>{key}</kbd>" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .KeyboardTag(key)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
