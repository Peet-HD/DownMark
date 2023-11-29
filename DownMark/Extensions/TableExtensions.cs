using System.Data;
using System.Text;

namespace DownMark.Extensions;

public static class TableExtensions
{
    public static MarkdownBuilder Table(this MarkdownBuilder builder, DataTable table, RowAlignment alignment)
    {
        StringBuilder sb = new();

        sb.Append("| ");
        for (int i = 0; i < table.Columns.Count; i++)
        {
            var column = table.Columns[i];
            sb.Append(column.ColumnName);
            if (i == table.Columns.Count - 1)
            {
                sb.Append(" |");
            }
            else
            {
                sb.Append(" | ");
            }
        }
        sb.AppendLine().Append("| ");
        for (int i = 0; i < table.Columns.Count; i++)
        {
            var seperatorString = alignment switch
            {
                RowAlignment.Left => ":---",
                RowAlignment.Center => ":---:",
                RowAlignment.Right => "---:",
                _ => "---",
            };
            sb.Append(seperatorString);

            if (i == table.Columns.Count - 1)
            {
                sb.Append(" |");
            }
            else
            {
                sb.Append(" | ");
            }
        }
        sb.AppendLine();

        sb = FillWithDataRows(table, sb);
        var markdownText = sb.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
    public static MarkdownBuilder Table(this MarkdownBuilder builder, DataTable table)
    {
        StringBuilder sb = new();

        sb.Append("| ");
        for (int i = 0; i < table.Columns.Count; i++)
        {
            var column = table.Columns[i];
            sb.Append(column.ColumnName);
            if (i == table.Columns.Count - 1)
            {
                sb.Append(" |");
            }
            else
            {
                sb.Append(" | ");
            }
        }
        sb.AppendLine().Append("| ");
        for (int i = 0; i < table.Columns.Count; i++)
        {
            sb.Append("---");

            if (i == table.Columns.Count - 1)
            {
                sb.Append(" |");
            }
            else
            {
                sb.Append(" | ");
            }
        }
        sb.AppendLine();

        sb = FillWithDataRows(table, sb);
        var markdownText = sb.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
    private static StringBuilder FillWithDataRows(DataTable table, StringBuilder sb)
    {
        foreach (DataRow row in table.Rows)
        {
            sb.Append("| ");
            //foreach (object? cell in row.ItemArray)
            for (int i = 0; i < row.ItemArray.Length; i++)
            {
                var cell = row.ItemArray[i];
                sb.Append(cell);
                if (i == row.ItemArray.Length - 1)
                {
                    sb.Append(" |");
                }
                else
                {
                    sb.Append(" | ");
                }

            }
            sb.AppendLine();
        }
        return sb;
    }
}

public enum RowAlignment
{
    Left,
    Center,
    Right
}