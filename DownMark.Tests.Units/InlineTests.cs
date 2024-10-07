using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units
{
    public class InlineTests
    {
        [Fact]
        public void HeaderWithUrlAndImageAndInlineMode()
        {
            var link = "link";
            var linkName = "linkName";
            
            var picture = "pictureLink";
            var pictureName = "pictureName";

            var expected = $"## Hello, this is a markdown page and has a link [{linkName}]({link}) and also a picture of a cat ![{pictureName}]({picture})";

            var options = new MarkdownOptions(MarkdownMode.Inline);
            var markdownBuilder = new MarkdownBuilder(options);

            var actual = markdownBuilder
                .Header("Hello, this is a markdown page and has a link", Models.HeaderSize.H2)
                .Whitespace()
                .Link(link, linkName)
                .Space()
                .Text("and also a picture of a cat ")
                .Image(picture, pictureName)
                .Build();

            actual.Should().Be(expected);
        }
    }
}
