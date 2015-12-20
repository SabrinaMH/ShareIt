using System;
using System.Collections.Generic;

namespace ShareIt.ReadCtx.Models
{
    public class Discussion : BaseDocument
    {
        public string Topic { get; set; }
        public string NameOfInitiator { get; set; }
        public List<string> NamesOfTheOtherParticipants { get; set; }
        public string Link { get; set; }
        public List<Post> Posts { get; set; }

        public Discussion(string topic, string nameOfInitiator, List<string> namesOfTheOtherParticipants, string link)
            : base("document")
        {
            Topic = topic;
            NameOfInitiator = nameOfInitiator;
            NamesOfTheOtherParticipants = namesOfTheOtherParticipants;
            Link = link;
            Posts = new List<Post>();
        }
    }
}