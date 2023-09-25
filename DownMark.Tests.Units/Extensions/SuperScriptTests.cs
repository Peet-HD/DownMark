using DownMark.Extensions;

namespace DownMark.Tests.Units.Extensions
{
    public class SuperScriptTests {
        [Fact]
        public void SuperScriptTest()
        {
            var sub = Guid.NewGuid().ToString();
            var expected = $"<sup>{sub}</sup>" + Environment.NewLine + Environment.NewLine;

            var actual = new MarkdownBuilder()
                .SuperScript(sub)
                .Build();

            Assert.Equal(expected, actual);
        }
    }
}
