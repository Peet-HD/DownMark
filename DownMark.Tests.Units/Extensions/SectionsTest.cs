using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class SectionsTests
{

    [Theory]
    [InlineData("This is a summary","This is a detail text.")]
    public void SectionTest(string summary, string text)
    {
        var expected = $"<p>" + Environment.NewLine +
           $"<details>" + Environment.NewLine +
           $"<summary>{summary}</summary>" + Environment.NewLine +
           Environment.NewLine
           + text + Environment.NewLine +
           Environment.NewLine +
           "</details>" + Environment.NewLine +
           "</p>" + Environment.NewLine +
           Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .CollapsibleSection(summary, text)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
