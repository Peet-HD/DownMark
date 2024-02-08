using Xunit;

namespace DownMark.Tests.Units.Testdata;

public class MathTestdata : TheoryData<string>
{
    public MathTestdata()
    {
        Add("a^2+b^2=c^c");
        Add("e=mc^2");
    }
}
