using System;
using System.Collections.Generic;
using Patient_Demographics_Domain.Interfaces;
using Patient_Demographics_Domain.Models;
using Patient_Demographics_Service.Interfaces;

namespace Patient_Demographics_Test
{
    public class TestPatientService:IPatientService
    {
        IPatientRepository _patientRepo;
        public TestPatientService(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }
        public string CreatePatrients(Patient patient)
        {
            _patientRepo.CreatePatrients(patient);
            return patient.PatientGUIID;
        }

        public bool DeletePatientByID(string patientGUIID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientByID(string patientGUIID)
        {
            Patient patient = _patientRepo.GetPatientByID(0);
            return patient;
        }

        public Patient UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
