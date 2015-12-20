using System;

namespace ShareIt.ReadCtx.Models
{
    public class Link : BaseDocument
    {
        public string Uri { get; set; }

        public Link(string uri)
            : base("link")
        {
            Uri = uri;
        }
    }
}