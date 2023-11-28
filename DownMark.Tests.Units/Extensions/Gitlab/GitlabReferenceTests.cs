﻿using DownMark.Extensions;
using DownMark.Extensions.Gitlab;
using FluentAssertions;
using Xunit;

namespace DownMark.Tests.Units.Extensions.Gitlab;

public class GitlabReferenceTests
{
    private readonly Bogus.Faker _faker;
    public GitlabReferenceTests()
    {
        _faker = new Bogus.Faker();
    }
    #region Users and Groups
    public static IEnumerable<object[]> UserData(bool user)
    {
        Bogus.Faker faker = new();
        for (int i = 0; i < 50; i++)
        {
            var name = user ? faker.Name.FirstName() : faker.Company.CompanyName();
            yield return new object[] { name };
        }
    }

    [Theory]
    [MemberData(nameof(UserData), true)]
    public void UserTest(string user)
    {
        var expected = $"@{user}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .User(user)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory()]
    [MemberData(nameof(UserData), false)]
    public void GroupTest(string group)
    {
        var expected = $"@{group}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Group(group)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    public void AllUsersTest()
    {
        var expected = $"@all" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Everybody()
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    #endregion
    #region Reference Links
    public static IEnumerable<object[]> ReferenceLinkTestdata()
    {
        var faker = new Bogus.Faker();
        for (int i = 0; i < 50; i++)
        {
            var url = faker.Internet.UrlWithPath(protocol: "https", domain: "github.com");
            var path = url.Remove(0, "https://github.com".Length);
            yield return new object[] { path };
        }
    }

    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void ProjectReferenceLinkTest(string path)
    {
        var expected = $"{path}>" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Project(path)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void IssueReferenceLinkTest(string path)
    {
        _ = path;
        var id = _faker.Random.Number();
        var seperatorChar = "#";
        var expected = seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Issue(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void IssueWithPathReferenceLinkTest(string path)
    {
        var id = _faker.Random.Number();
        var seperatorChar = "#";
        var expected = path
            + seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Issue(id, path)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void MergeRequestReferenceLinkTest(string path)
    {
        _ = path;
        var id = _faker.Random.Number();
        var seperatorChar = "!";
        var expected = seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .MergeRequest(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void MergeRequestWithPathReferenceLinkTest(string path)
    {
        var id = _faker.Random.Number();
        var seperatorChar = "!";
        var expected = path
            + seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .MergeRequest(id, path)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void SnippetReferenceLinkTest(string path)
    {
        _ = path;
        var id = _faker.Random.Number();
        var seperatorChar = "$";
        var expected = seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Snippet(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void SnippetWithPathReferenceLinkTest(string path)
    {
        var id = _faker.Random.Number();
        var seperatorChar = "$";
        var expected = path
            + seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Snippet(id, path)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }

    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void EpicReferenceLinkTest(string path)
    {
        _ = path;
        var id = _faker.Random.Number();
        var seperatorChar = "&";
        var expected = seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Epic(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void EpicWithPathReferenceLinkTest(string path)
    {
        var id = _faker.Random.Number();
        var seperatorChar = "&";
        var expected = path
            + seperatorChar
            + id
            + Environment.NewLine
            + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Epic(id, path)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    #endregion
    [Fact]
    public void IterationTest()
    {
        var semVer = $"v{_faker.Random.Int(min: 0)}.{_faker.Random.Int(min: 0)}.{_faker.Random.Int(min: 0)}";

        var expected = $"*iteration:\"{semVer}\"" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Iteration(semVer)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Fact]
    public void VulnerabilityTest()
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"[vulnerability:{id}]" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Vulnerability(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void VulnerabilityWithProjectPathTest(string projectPath)
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"[vulnerability:{projectPath}/{id}]" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Vulnerability(id, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Fact]
    public void FeatureFlagTest()
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"[feature_flag:{id}]" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .FeatureFlag(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void FeatureFlagWithProjectPathTest(string projectPath)
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"[feature_flag:{projectPath}/{id}]" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .FeatureFlag(id, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    #region Labels
    [Fact]
    public void LabelByIdTest()
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"~{id}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Label(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void LabelByIdWithProjectPathTest(string projectPath)
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"{projectPath}~{id}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Label(id, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Fact]
    public void LabelByNameTest()
    {
        var name = _faker.Random.Words(2);
        var expected = $"~\"{name}\"" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Label(name)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void LabelByNameWithProjectPathTest(string projectPath)
    {
        var name = _faker.Random.Words(2);
        var expected = $"{projectPath}~\"{name}\"" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Label(name, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    #endregion
    #region Milestones
    [Fact]
    public void MilestoneByIdTest()
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"%{id}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Milestone(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void MilestoneByIdWithProjectPathTest(string projectPath)
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"{projectPath}%{id}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Milestone(id, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Fact]
    public void MilestoneByNameTest()
    {
        var name = _faker.Random.Words(2);
        var expected = $"%\"{name}\"" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Milestone(name)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void MilestoneByNameWithProjectPathTest(string projectPath)
    {
        var name = _faker.Random.Words(2);
        var expected = $"{projectPath}%\"{name}\"" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Milestone(name, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    #endregion
    #region Commits
    [Fact]
    public void CommitTest()
    {
        var commit = _faker.Internet.Random.Hash(8);
        var expected = commit + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Commit(commit)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void CommitWithProjectPathTest(string projectPath)
    {
        var commit = _faker.Internet.Random.Hash(8);
        var expected = $"{projectPath}@{commit}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Commit(commit, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Fact]
    public void CommitRangeTest()
    {
        var commitA = _faker.Internet.Random.Hash(8);
        var commitB = _faker.Internet.Random.Hash(8);
        var expected = commitA + "..." + commitB + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .CommitRange(commitA, commitB)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void CommitRangeWithProjectPathTest(string projectPath)
    {
        var commitA = _faker.Internet.Random.Hash(8);
        var commitB = _faker.Internet.Random.Hash(8);
        var expected = projectPath + "@" + commitA + "..." + commitB + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .CommitRange(commitA, commitB, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    #endregion
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void FileReferenceTest(string filePath)
    {
        var title = _faker.Lorem.Word();
        var expected = $"[{title}]({filePath}.md)" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .FileReference(title, filePath + ".md")
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void FileReferenceWithLineTest(string filePath)
    {
        var line = _faker.Random.Int(min: 1);
        var title = _faker.Lorem.Word();
        var expected = $"[{title}]({filePath}.md#L{line})" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .FileReference(title, filePath + ".md", line)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Fact]
    public void AlertTest()
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"^alert#{id}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Alert(id)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Theory]
    [MemberData(nameof(ReferenceLinkTestdata))]
    public void AlertWithProjectPathTest(string projectPath)
    {
        var id = _faker.Random.Int(min: 1);
        var expected = $"{projectPath}^alert#{id}" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Alert(id, projectPath)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
    [Fact]
    public void ContactTest()
    {
        var email = _faker.Internet.Email();
        var expected = $"[contact:{email}]" + Environment.NewLine + Environment.NewLine;
        var actual = new MarkdownBuilder()
            .Contact(email)
            .Build();

        expected.Should().BeEquivalentTo(actual);
    }
}
