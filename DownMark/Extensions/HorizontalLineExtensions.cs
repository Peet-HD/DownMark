namespace DownMark.Extensions;

public static class HorizontalLineExtensions
{
    public static MarkdownBuilder HorizontalLine(this MarkdownBuilder builder)
    {
        builder.Entities.Add("***");
        return builder;
    }
    public static MarkdownBuilder HorizontalLine(this MarkdownBuilder builder, string text, int length = 10)
    {
        for (int i = 0; i < length; i++)
        {
            builder.Entities.Add(text);
        }
        return builder;
    }
    public static MarkdownBuilder HorizontalLine(this MarkdownBuilder builder, char character, int length = 10)
    {
        for (int i = 0; i < length; i++)
        {
            builder.Entities.Add(character.ToString());
        }
        return builder;
    }
}