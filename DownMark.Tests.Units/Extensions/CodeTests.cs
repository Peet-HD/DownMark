using DownMark.Extensions;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions;

public partial class CodeTests
{
    #region Test data
    public static IEnumerable<object[]> TestData()
    {
        List<object[]> data =
        [
            [CsharpTestData().Key, CsharpTestData().Value],
            [JsonTestData().Key, JsonTestData().Value],
            [XmlTestData().Key, XmlTestData().Value],
            [DockerTestData().Key, DockerTestData().Value]
        ];

        return data;
    }

    public static KeyValuePair<string, string> CsharpTestData()
    {
        var code = @"
 public static IEnumerable<object[]> TestData()
{
    for (int i = 0; i < 50; i++)
    {
        yield return new object[] { Guid.NewGuid().ToString() };
    }
}
";
        return new KeyValuePair<string, string>("csharp", code);
    }

    public static KeyValuePair<string, string> JsonTestData()
    {
        var code = @"{
    ""glossary"": {
        ""title"": ""example glossary"",
		""GlossDiv"": {
            ""title"": ""S"",
			""GlossList"": {
                ""GlossEntry"": {
                    ""ID"": ""SGML"",
					""SortAs"": ""SGML"",
					""GlossTerm"": ""Standard Generalized Markup Language"",
					""Acronym"": ""SGML"",
					""Abbrev"": ""ISO 8879:1986"",
					""GlossDef"": {
                        ""para"": ""A meta-markup language, used to create markup languages such as DocBook."",
						""GlossSeeAlso"": [""GML"", ""XML""]
                    },
					""GlossSee"": ""markup""
                }
            }
        }
    }
}";
        return new KeyValuePair<string, string>("json", code);
    }

    public static KeyValuePair<string, string> XmlTestData()
    {
        var code = @"<!DOCTYPE glossary PUBLIC ""-//OASIS//DTD DocBook V3.1//EN"">
 <glossary><title>example glossary</title>
  <GlossDiv><title>S</title>
   <GlossList>
    <GlossEntry ID=""SGML"" SortAs=""SGML"">
     <GlossTerm>Standard Generalized Markup Language</GlossTerm>
     <Acronym>SGML</Acronym>
     <Abbrev>ISO 8879:1986</Abbrev>
     <GlossDef>
      <para>A meta-markup language, used to create markup
languages such as DocBook.</para>
      <GlossSeeAlso OtherTerm=""GML"">
      <GlossSeeAlso OtherTerm=""XML"">
     </GlossDef>
     <GlossSee OtherTerm=""markup"">
    </GlossEntry>
   </GlossList>
  </GlossDiv>
 </glossary>";
        return new KeyValuePair<string, string>("xml", code);
    }

    public static KeyValuePair<string, string> DockerTestData()
    {
        var code = @"
FROM docker:23.0.1-cli-alpine3.17 as dockerImage
FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine as dotnetImage
COPY --from=dockerImage / /";
        return new KeyValuePair<string, string>("docker", code);
    }

    #endregion
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestCodeBlock(string format, string code)
    {
        var expected = $"```{format}{Environment.NewLine}{code}{Environment.NewLine}```{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}";
        var actual = new MarkdownBuilder()
            .Code(code, format)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
}
