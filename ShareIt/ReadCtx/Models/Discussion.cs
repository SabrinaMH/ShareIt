using System;
using System.Collections.Generic;

namespace ShareIt.ReadCtx.Models
{
    public class Discussion : BaseDocument
    {
        public string Topic { get; set; }
        public string NameOfInitiator { get; set; }
        public List<string> NamesOfParticipants { get; set; }
        public string Link { get; set; }
        public List<Post> Posts { get; set; }

        public Discussion(string topic, string nameOfInitiator, List<string> namesOfParticipants, string link)
            : base("discussion")
        {
            Topic = topic;
            NameOfInitiator = nameOfInitiator;
            NamesOfParticipants = namesOfParticipants;
            Link = link;
            Posts = new List<Post>();
        }
    }
}