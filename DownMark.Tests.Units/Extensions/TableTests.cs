using DownMark.Extensions;
using FluentAssertions;
using System.Data;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class TableTests
{

    [Fact]
    public void TableTestWithoutAlignment()
    {
        var expected = @"| Category | Description |
| --- | --- |
| Test | Those Tests |
| Hello | World |";
        expected += Environment.NewLine + Environment.NewLine + Environment.NewLine;
        var dataTable = new DataTable();
        dataTable.Columns.Add("Category");
        dataTable.Columns.Add("Description");
        dataTable.Rows.Add("Test", "Those Tests");
        dataTable.Rows.Add("Hello", "World");
        var actual = new MarkdownBuilder()
            .Table(dataTable)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void TableTestWithLeftAlignment()
    {
        var expected = @"| Category | Description |
| :--- | :--- |
| Test | Those Tests |
| Hello | World |";
        expected += Environment.NewLine + Environment.NewLine + Environment.NewLine;
        var dataTable = new DataTable();
        dataTable.Columns.Add("Category");
        dataTable.Columns.Add("Description");
        dataTable.Rows.Add("Test", "Those Tests");
        dataTable.Rows.Add("Hello", "World");
        var actual = new MarkdownBuilder()
            .Table(dataTable, RowAlignment.Left)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void TableTestWithCenterAlignment()
    {
        var expected = @"| Category | Description |
| :---: | :---: |
| Test | Those Tests |
| Hello | World |";
        expected += Environment.NewLine + Environment.NewLine + Environment.NewLine;
        var dataTable = new DataTable();
        dataTable.Columns.Add("Category");
        dataTable.Columns.Add("Description");
        dataTable.Rows.Add("Test", "Those Tests");
        dataTable.Rows.Add("Hello", "World");
        var actual = new MarkdownBuilder()
            .Table(dataTable, RowAlignment.Center)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void TableTestWithRightAlignment()
    {
        var expected = @"| Category | Description |
| ---: | ---: |
| Test | Those Tests |
| Hello | World |";
        expected += Environment.NewLine + Environment.NewLine + Environment.NewLine;
        var dataTable = new DataTable();
        dataTable.Columns.Add("Category");
        dataTable.Columns.Add("Description");
        dataTable.Rows.Add("Test", "Those Tests");
        dataTable.Rows.Add("Hello", "World");
        var actual = new MarkdownBuilder()
            .Table(dataTable, RowAlignment.Right)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

}
