using DownMark.Extensions;

namespace DownMark.Tests.Units.Extensions
{
    public class LinkTests
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
            var expected = $"[{title}]({url} \"{altText}\")" + Environment.NewLine + Environment.NewLine;

            var actual = new MarkdownBuilder()
                .Link(url, title, altText)
                .Build();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(Testdata))]
        public void TestImageElementWithoutAltText(string url, string title, string altText)
        {
            var expected = $"[{title}]({url})" + Environment.NewLine + Environment.NewLine;

            var actual = new MarkdownBuilder()
                .Link(url, title)
                .Build();

            Assert.Equal(expected, actual);
        }
    }
}
