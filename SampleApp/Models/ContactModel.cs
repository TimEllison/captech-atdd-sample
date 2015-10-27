using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models
{
    public class ContactModel
    {
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Range(21, 100)]
        public int Age { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string County { get; set; }

        public List<KeyValuePair<string, string>> States => new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("","--Select" ),
            new KeyValuePair<string, string>("NC", "Nawth Carolina"),
            new KeyValuePair<string, string>("VA", "Old Dominion"),
        };
    }
}
