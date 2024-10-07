using Xunit;

namespace DownMark.Tests.Units.Testdata;

public class LinkTestdata : TheoryData<string, string, string>
{
    public LinkTestdata()
    {
        Add(qualityGatePassed, "Passed", "QualityGate has passed.");
        Add(qualityGateFailed, "Failed", "QualityGate has failed.");
        Add(qualityGateNotComputed, "Not computed", "QualityGate has not computed.");
    }

    private const string qualityGatePassed = "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/passed.svg";
    private const string qualityGateFailed = "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/failed.svg";
    private const string qualityGateNotComputed = "https://sonarsource.github.io/sonarcloud-github-static-resources/v2/checks/QualityGateBadge/not_computed.svg";
}
