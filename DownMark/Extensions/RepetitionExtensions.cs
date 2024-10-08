namespace DownMark.Extensions;

public static class RepetitionExtensions
{
    public static MarkdownBuilder Repetition(this MarkdownBuilder builder, string text, int count = 1)
    {
        builder.Entities.Add(text);
        return builder;
    }
    public static MarkdownBuilder Repetition(this MarkdownBuilder builder, char character, int count = 1)
    {
        builder.Entities.Add(character.ToString());
        return builder;
    }
}
