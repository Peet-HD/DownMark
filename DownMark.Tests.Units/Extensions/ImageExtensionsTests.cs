using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class ImageExtensionsTests
{
    public static IEnumerable<object[]> Testdata()
    {
        yield return new object[] { "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/passed.svg"
            , "Passed", "QualityGate has passed." };
        yield return new object[] { "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/failed.svg"
            , "Failed", "QualityGate has failed." };
        yield return new object[] { "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/not_computed.svg"
            , "Not computed", "QualityGate has not computed." };
    }
    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithAltText(string url, string title, string altText)
    {
        var expected = $"![{title}]({url} \"{altText}\")" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Image(url, title, altText)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithoutAltText(string url, string title, string altText)
    {
        _ = altText;
        var expected = $"![{title}]({url})" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Image(options => options
                .WithTitle(title)
                .WithUrl(url)
            ).Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestImageElementWithOptions(string url, string title, string altText)
    {
        var expected = $"![{title}]({url} \"{altText}\")" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .Image(options => options
                 .WithTitle(title)
                 .WithUrl(url)
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
                .WithWidth(width,"%")
                .WithHeight(height,"%")
                ).Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
