using DownMark.Extensions;
using DownMark.Models;
using DownMark.Tests.Units.Testdata;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class TaskTests
{
    public static TaskTestdata Testdata { get; } = [];

    [Theory]
    [MemberData(nameof(Testdata))]
    public void TestTasks(List<TaskEntity> list)
    {
        var expected = $"";
        foreach (var item in list)
        {
            var check = item.Checked
                ? "[x]"
                : "[ ]";
            var itemString = $"- {check} {item.Task}{Environment.NewLine}";
            expected += itemString;
        }
        expected += Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .TaskList(list)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
