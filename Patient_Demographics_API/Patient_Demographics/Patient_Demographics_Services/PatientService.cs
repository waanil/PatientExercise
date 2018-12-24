using System;
using System.Collections.Generic;
using Patient_Demographics_Domain.Models;
using Patient_Demographics_Domain.Interfaces;
using Patient_Demographics_Service.Interfaces;

namespace Patient_Demographics_Services
{
    public class PatientService : IPatientService
    {
        IPatientRepository _patientRepo;
        public PatientService(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }
        public PatientModel CreatePatrients(PatientModel patient)
        {

            string tempGUID =  Guid.NewGuid().ToString();
            try
            {
                patient.PatientGUIID = tempGUID;
                _patientRepo.CreatePatrients(patient);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return patient;
        }

        public bool DeletePatientByID(string patientGUID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            var patient = _patientRepo.GetAllPatients();
            return patient;
        }

        public PatientModel GetPatientByID(string patientGUID)
        {
            PatientModel patient = _patientRepo.GetPatientByID(patientGUID);
            return patient;
        }

        public PatientModel UpdatePatient(PatientModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
