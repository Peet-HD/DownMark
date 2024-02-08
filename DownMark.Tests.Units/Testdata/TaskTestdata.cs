using DownMark.Models;
using Xunit;

namespace DownMark.Tests.Units.Testdata;

public class TaskTestdata : TheoryData<List<TaskEntity>>
{
    public TaskTestdata()
    {
        for (int i = 0; i < 50; i++)
        {
            var item = new List<TaskEntity>();
            for (int j = 0; j < 10; j++)
            {
                Random random = new();
                var randomInteger = random.Next();
                var c = randomInteger % 2 == 0;
                item.Add(new TaskEntity(c, Guid.NewGuid().ToString()));
            }
            Add(item);
        }
    }
}
