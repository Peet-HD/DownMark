using DownMark.Models;

namespace DownMark.Extensions;

public static class ImageOptionsExtensions
{
    public static ImageOptions WithTitle(this ImageOptions options, string title) => options with { title = title };
    public static ImageOptions WithUrl(this ImageOptions options, string title) => options with { url = title };
    public static ImageOptions WithAltText(this ImageOptions options, string title) => options with { altText = title };
    public static ImageOptions WithWidth(this ImageOptions options, int width, string unit = "px") => options with { width = width, widthUnit = unit };
    public static ImageOptions WithHeight(this ImageOptions options, int height, string unit = "px") => options with { height = height, heightUnit = unit };
}