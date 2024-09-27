using DownMark.Extensions;
using DownMark.Tests.Units.Testdata;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class LinkTests
{
    public static LinkTestdata Testdata { get; } = [];

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithAltText(string url, string title, string altText)
    {
        var expected = $"[{title}]({url} \"{altText}\")" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Link(url, title, altText)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithoutAltText(string url, string title, string altText)
    {
        _ = altText;
        var expected = $"[{title}]({url})" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Link(url, title)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
