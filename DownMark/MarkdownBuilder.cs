using System.Collections.Generic;

namespace DownMark;

public class MarkdownBuilder
{
    public MarkdownOptions Options { get; set; }
    private readonly List<string> entities;
    internal List<string> Entities => entities;
    public MarkdownBuilder()
    {
        entities = [];
        Options = new MarkdownOptions(MarkdownMode.Block);
    }
    public MarkdownBuilder(MarkdownOptions options)
    {
        entities = [];
        Options = options;
    }
}
