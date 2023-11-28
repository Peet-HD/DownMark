using System.Collections.Generic;
using System.Text;
using DownMark.Models;

namespace DownMark.Extensions;

public static class TasksExtensions
{
    public static MarkdownBuilder TaskList(this MarkdownBuilder builder, List<TaskEntity> tasks)
    {
        StringBuilder stringBuilder = new();
        foreach (TaskEntity task in tasks)
        {
            char checkedChar = task.Checked ? 'x' : ' ';
            stringBuilder
                .Append('-')
                .Append(' ')
                .Append('[')
                .Append(checkedChar)
                .Append(']')
                .Append(' ')
                .Append(task.Task)
                .AppendLine();
        }
        string markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}