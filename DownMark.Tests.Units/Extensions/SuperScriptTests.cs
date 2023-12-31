﻿using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public class SuperScriptTests {
    [Fact]
    public void SuperScriptTest()
    {
        var sub = Guid.NewGuid().ToString();
        var expected = $"<sup>{sub}</sup>" + Environment.NewLine + Environment.NewLine;

        var actual = new MarkdownBuilder()
            .SuperScript(sub)
            .Build();

        actual.Should().BeEquivalentTo(expected);
    }
}
