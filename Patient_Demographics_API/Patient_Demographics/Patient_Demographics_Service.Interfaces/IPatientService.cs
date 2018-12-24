using System;
using System.Collections.Generic;
using Patient_Demographics_Domain.Models;


namespace Patient_Demographics_Service.Interfaces
{
    /// <summary>
    /// Service layer do all the Data Verification and enrichment
    /// </summary>
    public interface IPatientService
    {
        //this method will return the GUID string on succefull creation of Patien
        PatientModel CreatePatrients(PatientModel patient);
        IEnumerable<PatientModel> GetAllPatients();
        PatientModel GetPatientByID(string patientGUIID);
        Boolean DeletePatientByID(string patientGUIID);
        PatientModel UpdatePatient(PatientModel patient);
    }
}
