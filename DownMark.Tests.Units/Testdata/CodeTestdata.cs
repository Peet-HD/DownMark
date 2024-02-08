using Xunit;

namespace DownMark.Tests.Units.Testdata;
public class CodeTestdata : TheoryData<string, string>
{
    public CodeTestdata()
    {
        Add("charp", csharpCode);
        Add("json", jsonCode);
        Add("xml", xmlCode);
        Add("docker", dockerCode);
    }

    private const string csharpCode = @"
 public static IEnumerable<object[]> TestData()
{
    for (int i = 0; i < 50; i++)
    {
        yield return new object[] { Guid.NewGuid().ToString() };
    }
}
";

    private const string jsonCode = @"{
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

    private const string xmlCode = @"<!DOCTYPE glossary PUBLIC ""-//OASIS//DTD DocBook V3.1//EN"">
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

    private const string dockerCode = @"
FROM docker:23.0.1-cli-alpine3.17 as dockerImage
FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine as dotnetImage
COPY --from=dockerImage / /";
}
