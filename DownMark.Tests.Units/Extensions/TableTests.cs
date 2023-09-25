using DownMark.Extensions;
using System.Data;

namespace DownMark.Tests.Units.Extensions
{
    public class TableTests {

        [Fact]
        public void TableTest()
        {
            var expected = @"|Category|Description|
|---|---|
|Test|Those Tests|
|Hello|World|";
            expected += Environment.NewLine + Environment.NewLine + Environment.NewLine;
            var dataTable = new DataTable();
            dataTable.Columns.Add("Category");
            dataTable.Columns.Add("Description");
            dataTable.Rows.Add("Test", "Those Tests");
            dataTable.Rows.Add("Hello", "World");
            var actual = new MarkdownBuilder()
                .Table(dataTable)
                .Build();

            Assert.Equal(expected, actual);
        }
    }
}
