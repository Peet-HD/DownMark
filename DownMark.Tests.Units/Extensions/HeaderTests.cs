using DownMark.Extensions;
using DownMark.Tests.Units.Testdata;
using FluentAssertions;
using Xunit;
using HeaderSize = DownMark.Models.HeaderSize;

namespace DownMark.Tests.Units.Extensions;

public class HeaderTests
{
    public static HeaderTestdata TestData { get; } = [];

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithDefaultParameter(string text)
    {
        var expected = $"# {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH1Parameter(string text)
    {
        var expected = $"# {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, HeaderSize.H1)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH2Parameter(string text)
    {
        var expected = $"## {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, HeaderSize.H2)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH3Parameter(string text)
    {
        var expected = $"### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, HeaderSize.H3)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH4Parameter(string text)
    {
        var expected = $"#### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, HeaderSize.H4)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH5Parameter(string text)
    {
        var expected = $"##### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, HeaderSize.H5)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH6Parameter(string text)
    {
        var expected = $"###### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, HeaderSize.H6)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}