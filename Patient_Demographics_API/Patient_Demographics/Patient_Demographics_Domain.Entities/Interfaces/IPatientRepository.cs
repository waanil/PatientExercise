using System;
using System.Collections.Generic;
using Patient_Demographics_Domain.Models;

namespace Patient_Demographics_Domain.Interfaces
{

    /// <summary>
    /// Domain Level Interface, any custome Repos has to implement
    /// 
    /// </summary>
    public interface IPatientRepository
    {
        //this method will return the GUID string on succefull creation of Patien
        string CreatePatrients(PatientModel patient);
        IEnumerable<PatientModel> GetAllPatients();
        PatientModel GetPatientByID(string patientGUID);
        Boolean DeletePatientByID(string patientGUID);
        PatientModel UpdatePatient(PatientModel patient);
    }
}
