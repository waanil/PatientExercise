using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Patient_Demographics_Domain.Models
{
    public class PatientModel
    {



        //This is the unique Identification Number, System Generated 
        public string PatientGUIID{ get; set; }
        [Required(ErrorMessage = "ForeName is required")]
        [MaxLength(50)]
        [MinLength(3)]
        public string ForeName { get; set; }

        [Required(ErrorMessage = "SurName is required")]
        [MaxLength(50)]
        [MinLength(2)]
        public string SurName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender should be specified")]
        public GenderEnum Gender { get; set; }

        public List<ContactDetail> TelephoneNumbers { get; set; }

    }
}
