using System;
using System.ComponentModel.DataAnnotations;

namespace Patient_Demographics_Domain.Models
{
    public class ContactDetail
    {
        [Required(ErrorMessage = "ContactType is required")]
        public string ContactType { get; set; }

        public int ContactNumber { get; set; }
    }
}