using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class ListTests
{
    [Fact]
    public void ListOrderedTest()
    {
        var data = new List<object>
        {
            "ValueA",
            "ValueB",
            new List<object>
        {
            { "SubValueA" },
            { "SubValueB" },
            { new List<object>
            {
                { "SubSubValueA" },
                { "SubSubValueB" },
                { "SubSubValueC" }
            } },
            { "SubValueC" },
        },
            "ValueC"
        };

        var expected = @"1. ValueA
2. ValueB
  1. SubValueA
  2. SubValueB
    1. SubSubValueA
    2. SubSubValueB
    3. SubSubValueC
  3. SubValueC
3. ValueC


";
        var actual = new MarkdownBuilder()
            .List(data,true)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ListUnorderedTest()
    {
        var data = new List<object>
        {
            "ValueA",
            "ValueB",
            new List<object>
        {
            { "SubValueA" },
            { "SubValueB" },
            { new List<object>
            {
                { "SubSubValueA" },
                { "SubSubValueB" },
                { "SubSubValueC" }
            } },
            { "SubValueC" },
        },
            "ValueC"
        };

        var expected = @"- ValueA
- ValueB
  - SubValueA
  - SubValueB
    - SubSubValueA
    - SubSubValueB
    - SubSubValueC
  - SubValueC
- ValueC


";
        var actual = new MarkdownBuilder()
            .List(data)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void OrderedListTest()
    {
        var data = new List<object>
        {
            "ValueA",
            "ValueB",
            new List<object>
        {
            { "SubValueA" },
            { "SubValueB" },
            { new List<object>
            {
                { "SubSubValueA" },
                { "SubSubValueB" },
                { "SubSubValueC" }
            } },
            { "SubValueC" },
        },
            "ValueC"
        };

        var expected = @"1. ValueA
2. ValueB
  1. SubValueA
  2. SubValueB
    1. SubSubValueA
    2. SubSubValueB
    3. SubSubValueC
  3. SubValueC
3. ValueC


";
        var actual = new MarkdownBuilder()
            .OrderedList(data)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void UnorderedListTest()
    {
        var data = new List<object>
        {
            "ValueA",
            "ValueB",
            new List<object>
        {
            { "SubValueA" },
            { "SubValueB" },
            { new List<object>
            {
                { "SubSubValueA" },
                { "SubSubValueB" },
                { "SubSubValueC" }
            } },
            { "SubValueC" },
        },
            "ValueC"
        };

        var expected = @"- ValueA
- ValueB
  - SubValueA
  - SubValueB
    - SubSubValueA
    - SubSubValueB
    - SubSubValueC
  - SubValueC
- ValueC


";
        var actual = new MarkdownBuilder()
            .UnorderedList(data)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
