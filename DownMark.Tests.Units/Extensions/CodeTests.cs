using DownMark.Extensions;
using DownMark.Tests.Units.Testdata;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class CodeTests
{
    public static CodeTestdata Testdata { get; } = [];

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestCodeBlock(string format, string code)
    {
        var expected = $"```{format}{Environment.NewLine}{code}{Environment.NewLine}```{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Code(code, format)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
