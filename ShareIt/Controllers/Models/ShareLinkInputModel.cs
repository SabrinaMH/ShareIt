using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareIt.Controllers.Models
{
    public class ShareLinkInputModel
    {
        [Required]
        public string EmailOfSharer { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public List<string> EmailsOfReceivers { get; set; }
    }
}