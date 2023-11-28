using System.Collections.Generic;
using System.Text;

namespace DownMark.Extensions;

public static class ListExtensions
{
    public static MarkdownBuilder List(this MarkdownBuilder builder, List<object> list,bool numberedList = false)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder = BuildList(stringBuilder, list, 0, numberedList);
        string markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }

    public static MarkdownBuilder UnorderedList(this MarkdownBuilder builder, List<object> list)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder = BuildList(stringBuilder, list, 0, false);
        string markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
    public static MarkdownBuilder OrderedList(this MarkdownBuilder builder, List<object> list)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder = BuildList(stringBuilder, list, 0, true);
        string markdownText = stringBuilder.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }

    private static StringBuilder BuildList(StringBuilder sb, List<object> list, int indentationLevel,bool numberedList)
    {
        for (int i1 = 0; i1 < list.Count; i1++)
        {
            object? item = list[i1];
            if (item is List<object> subList)
            {
                var currentIndentationLevel = indentationLevel + 1;
                BuildList(sb, subList, currentIndentationLevel,numberedList);
            }
            else
            {
                var indentSpace = new StringBuilder();
                if (indentationLevel > 0)
                {
                    for (int i = 0; i < indentationLevel; i++)
                    {
                        indentSpace.Append("  ");
                    }
                }

                sb.Append(indentSpace);

                var displayedNumber = i1+1;
                if (i1 > 0 && list[i1 - 1] is List<object>)
                {
                    displayedNumber = i1;
                }

                if (numberedList)
                {
                    sb.Append(displayedNumber).Append(". ");
                }
                else
                {
                    sb.Append("- ");
                }
                
                sb.Append(item).AppendLine();
            }
        }

        return sb;
    }
}
