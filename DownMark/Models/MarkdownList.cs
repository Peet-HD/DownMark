using System.Collections.Generic;

namespace DownMark.Models
{
    public class MarkdownList
    {
        internal List<object> list;
        public MarkdownList()
        {
            list = new List<object>();
        }
        public void Add(string entry) => list.Add(entry);
        public void Add(List<object> subList) => list.Add(subList);
    }
}
