using Xunit;

namespace DownMark.Tests.Units.Testdata;

public class LinkTestdata : TheoryData<string, string, string>
{
    public LinkTestdata()
    {
        Add(new Uri(qualityGatePassed).AbsoluteUri, "Passed", "QualityGate has passed.");
        Add(new Uri(qualityGateFailed).AbsoluteUri, "Failed", "QualityGate has failed.");
        Add(new Uri(qualityGateNotComputed).AbsoluteUri, "Not computed", "QualityGate has not computed.");
    }

    private const string qualityGatePassed = "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/passed.svg";
    private const string qualityGateFailed = "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/failed.svg";
    private const string qualityGateNotComputed = "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/not_computed.svg";
}
