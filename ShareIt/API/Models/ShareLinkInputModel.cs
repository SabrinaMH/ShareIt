using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareIt.API.Models
{
    public class ShareLinkInputModel
    {
        [Required]
        public string NameOfSharer { get; set; }

        [Required]
        public string EmailOfSharer { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public List<string> EmailsOfReceivers { get; set; }
    }
}