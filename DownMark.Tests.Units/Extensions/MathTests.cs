using DownMark.Extensions;
using DownMark.Tests.Units.Testdata;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class MathTests
{
    public static MathTestdata Testdata { get; } = [];

    [Theory]
    [MemberData(nameof(Testdata))]
    public void MathTest(string formula)
    {
        var expected = $"${formula}$" + Environment.NewLine+Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Math(formula)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
