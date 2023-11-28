using DownMark.Extensions;
using DownMark.Models;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class TaskTests
{
    public static IEnumerable<object[]> TestData()
    {
        var data = new List<object[]>();
        for (int i = 0; i < 50; i++)
        {
            var item = TaskList(10);
            data.Add([item]);
        }
        return data;
    }

    private static List<TaskEntity> TaskList(int amount = 10)
    {
        var item = new List<TaskEntity>();
        for (int j = 0; j < amount; j++)
        {
            Random random = new();
            var randomInteger = random.Next();
            var c = randomInteger % 2 == 0;
            item.Add(new TaskEntity(c, Guid.NewGuid().ToString()));
        }
        return item;
    }

    [Theory]
    [MemberData(nameof(TestData))]
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

        expected.Should().BeEquivalentTo(actual);
    }
}
