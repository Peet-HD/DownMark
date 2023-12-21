using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class HeaderTests
{
    public static IEnumerable<object[]> TestData()
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new object[] { Guid.NewGuid().ToString() };
        }
    }
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
            .Header(text, Models.HeaderSize.H1)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH2Parameter(string text)
    {
        var expected = $"## {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, Models.HeaderSize.H2)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH3Parameter(string text)
    {
        var expected = $"### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, Models.HeaderSize.H3)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH4Parameter(string text)
    {
        var expected = $"#### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, Models.HeaderSize.H4)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH5Parameter(string text)
    {
        var expected = $"##### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, Models.HeaderSize.H5)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestHeaderWithH6Parameter(string text)
    {
        var expected = $"###### {text}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Header(text, Models.HeaderSize.H6)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}