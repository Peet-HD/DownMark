using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DownMark.Models;

namespace DownMark.Extensions
{
    public static class SuperScriptExtensions
    {
        public static MarkdownBuilder SuperScript(this MarkdownBuilder builder, string text)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<sup>").Append(text).Append("</sup>");

            string markdownText = stringBuilder.ToString();
            builder.Entities.Add(markdownText);
            return builder;
        }
    }
}
