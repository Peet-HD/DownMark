using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class SectionTestdata : TheoryData<string, string>
{
    public SectionTestdata()
    {
        Add("This is a summary", "This is a detail text.");
    }
}