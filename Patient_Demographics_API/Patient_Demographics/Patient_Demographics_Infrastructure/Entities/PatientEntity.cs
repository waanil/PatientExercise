using System;
namespace Patient_Demographics_Infrastructure.Entities
{
    /// <summary>
    /// Data Model Entity to persists Patient Information
    /// </summary>
    public class Patients
    {
       public int ID { get; set; }
        public string GUIID { get; set; }
        public string PersonXML { get; set; }
    }
}
