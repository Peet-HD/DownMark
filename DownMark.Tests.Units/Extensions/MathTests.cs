using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class MathTests {
    [Theory]
    [InlineData("a^2+b^2=c^c")]
    [InlineData("e=mc^2")]
    public void MathTest(string formula)
    {
        var expected = $"${formula}$" + Environment.NewLine+Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Math(formula)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
