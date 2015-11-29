using System.Collections.Generic;

namespace ShareIt.API.Models
{
    public class ShareLinkInputModel
    {
        //[Required]
        public string NameOfSender { get; set; }

        //[Required]
        public string EmailOfSender { get; set; }

        //[Required]
        public string Link { get; set; }

        //[Required]
        public string Subject { get; set; }

        //[Required]
        public List<string> EmailsOfReceivers { get; set; }
    }
}