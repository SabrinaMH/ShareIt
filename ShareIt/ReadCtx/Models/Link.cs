using System;

namespace ShareIt.ReadCtx.Models
{
    public class Link : BaseDocument
    {
        public string Url { get; set; }

        public Link(string url)
            : base("link")
        {
            Url = url;
        }
    }
}