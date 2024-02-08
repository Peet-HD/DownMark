using DownMark.Extensions;
using DownMark.Tests.Units.Testdata;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class ImageExtensionsTests
{
    public static LinkTestdata Testdata { get; } = [];

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithAltText(Uri url, string title, string altText)
    {
        var expected = $"![{title}]({url} \"{altText}\")" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Image(url.AbsoluteUri, title, altText)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithoutAltText(Uri url, string title, string altText)
    {
        _ = altText;
        var expected = $"![{title}]({url})" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Image(options => options
                .WithTitle(title)
                .WithUrl(url.AbsoluteUri)
            ).Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithOptions(Uri url, string title, string altText)
    {
        var expected = $"![{title}]({url} \"{altText}\")" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Image(options => options
                 .WithTitle(title)
                 .WithUrl(url.AbsoluteUri)
                 .WithAltText(altText)
            ).Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TestImageElementWithWidthAndHeight()
    {
        var url = "drawing.jpg";
        var alt = "drawing";
        int width = 200;
        int height = 100;
        var expected = $"<img src=\"{url}\" alt=\"{alt}\" width=\"{width}px\" height=\"{height}px\"/>" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Image(options => options
                .WithAltText(alt)
                .WithUrl(url)
                .WithWidth(width)
                .WithHeight(height)
                ).Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void TestImageElementWithWidthUnitAndHeightUnit()
    {
        var url = "drawing.jpg";
        var alt = "drawing";
        int width = 200;
        int height = 100;
        var expected = $"<img src=\"{url}\" alt=\"{alt}\" width=\"{width}%\" height=\"{height}%\"/>" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Image(options => options
                .WithAltText(alt)
                .WithUrl(url)
                .WithWidth(width, "%")
                .WithHeight(height, "%")
                ).Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
