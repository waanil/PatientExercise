using System;
namespace Patient_Demographics_Domain.Models
{
    //List Genders option may vary as per the system setp
    //This should be read from some json Config file if it keeps growing  
    public enum GenderEnum
    {
        Male,
        Female,
        Other
    }
}
