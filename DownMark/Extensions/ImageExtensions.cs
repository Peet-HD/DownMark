using System;
using System.Text;
using DownMark.Models;

namespace DownMark.Extensions;

public static class ImageExtensions
{
    public static MarkdownBuilder Image(this MarkdownBuilder builder, string url, string title, string altText = "") 
        => builder.Image(options => options.WithUrl(url).WithTitle(title).WithAltText(altText));
    public static MarkdownBuilder Image(this MarkdownBuilder builder, Func<ImageOptions, ImageOptions> configure)
    {
        ImageOptions imageOptions = configure(new ImageOptions());
        StringBuilder sb = new();
        if (imageOptions.width is null && imageOptions.height is null)
        {

            sb.Append("![").Append(imageOptions.title).Append("](").Append(imageOptions.url);

            if (!string.IsNullOrWhiteSpace(imageOptions.altText))
            {
                sb.Append(' ').Append('"').Append(imageOptions.altText).Append('"');
            }
            sb.Append(')');
        }
        else
        {
            sb.Append("<img");
            if (imageOptions.url is not null)
            {
                sb.Append(" src=\"").Append(imageOptions.url).Append('"');
            }
            if (imageOptions.altText is not null)
            {
                sb.Append(" alt=\"").Append(imageOptions.altText).Append('"');
            }
            if (imageOptions.width is not null)
            {
                sb.Append(" width=\"").Append(imageOptions.width);
                if (imageOptions.widthUnit is not null)
                {
                    sb.Append(imageOptions.widthUnit);
                }
                sb.Append('"');
            }
            if (imageOptions.height is not null)
            {
                sb.Append(" height=\"").Append(imageOptions.height);
                if (imageOptions.heightUnit is not null)
                {
                    sb.Append(imageOptions.heightUnit);
                }
                sb.Append('"');
            }
            sb.Append("/>");
        }
        var markdownText = sb.ToString();
        builder.Entities.Add(markdownText);
        return builder;
    }
}
