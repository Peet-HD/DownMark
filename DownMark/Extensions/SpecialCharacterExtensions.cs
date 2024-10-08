using OperatingSystem = DownMark.Models.OperatingSystem;

namespace DownMark.Extensions;

public static class SpecialCharacterExtensions
{
    public static MarkdownBuilder Whitespace(this MarkdownBuilder builder)
    {
        builder.Entities.Add(" ");
        return builder;
    }
    public static MarkdownBuilder Space(this MarkdownBuilder builder) => builder.Whitespace();
    public static MarkdownBuilder Newline(this MarkdownBuilder builder, OperatingSystem operatingSystem = OperatingSystem.Linux)
    {
        builder.Entities.Add(operatingSystem switch
        {
            OperatingSystem.Linux => "\n",
            OperatingSystem.Windows => "\r\n",
            OperatingSystem.Mac => "\r",
            _ => "\n"
        });
        return builder;
    }
    public static MarkdownBuilder Character(this MarkdownBuilder builder, char character)
    {

        builder.Entities.Add(character.ToString());
        return builder;
    }
}

