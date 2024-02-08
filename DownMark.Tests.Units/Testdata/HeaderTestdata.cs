using Xunit;

namespace DownMark.Tests.Units.Testdata;

public class HeaderTestdata : TheoryData<string>
{
    public HeaderTestdata() => Add(Guid.NewGuid().ToString());
}
