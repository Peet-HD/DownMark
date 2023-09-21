using System.Data;
using System.Text;

namespace DownMark.Extensions
{
    public static class TableExtensions
    {
        public static MarkdownBuilder Table(this MarkdownBuilder builder, DataTable table)
        {
            StringBuilder sb = new();

            sb.Append('|');
            foreach (DataColumn column in table.Columns)
            {
                sb.Append(column.ColumnName).Append('|');
            }
            sb.AppendLine().Append('|');
            foreach (DataColumn column in table.Columns)
            {
                sb.Append("---").Append('|');
            }
            sb.AppendLine();

            foreach (DataRow row in table.Rows)
            {
                sb.Append('|');
                foreach (object? cell in row.ItemArray)
                {
                    sb.Append(cell).Append('|');
                }
                sb.AppendLine();
            }
            var markdownText = sb.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }

    }
}