using Bogus;
using Xunit;

namespace DownMark.Tests.Units.Testdata.Gitlab;

public class ReferenceLinkTestdata : TheoryData<string>
{
    public ReferenceLinkTestdata()
    {
        var faker = new Faker();
        for (int i = 0; i < 50; i++)
        {
            var url = faker.Internet.UrlWithPath(protocol: "https", domain: "github.com");
            var path = url.Remove(0, "https://github.com".Length);
            Add(path);
        }
    }
}
public class GitlabReferenceTestdata : TheoryData<string>
{
    public GitlabReferenceTestdata(bool isUser)
    {

        Faker faker = new();
        for (int i = 0; i < 50; i++)
        {
            var name = isUser 
                ? faker.Name.FirstName() 
                : faker.Company.CompanyName();
            Add(name);
        }
    }

}
