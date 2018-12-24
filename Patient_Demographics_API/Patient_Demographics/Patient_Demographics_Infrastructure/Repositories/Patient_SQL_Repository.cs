using System;
using System.Collections.Generic;
using Patient_Demographics_Domain.Models;
using Patient_Demographics_Domain.Interfaces;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using Patient_Demographics_Infrastructure.Repositories;
using Patient_Demographics_Infrastructure.Entities;
using Patient_Demographics_Infrastructure.Mappers;

namespace Patient_Demographics_Infrastructure
{
    /// <summary>
    /// Claas if fully repossobilbe to SQL DB related operations and communication
    /// </summary>
    public class Patient_SQL_Repository : IPatientRepository
    {

        private readonly PatientEFContext _context;
        public Patient_SQL_Repository(PatientEFContext context)
        {
            _context = context;
        }

        public string CreatePatrients(PatientModel patient)
        {
            
            _context.Patients.Add(patient.TOPatients());
            _context.SaveChanges();

            return patient.PatientGUIID;
        }

        public bool DeletePatientByID(string patientGUIID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            var patients = _context.Patients.Select(x => x.ToPatientModel());
            return patients;
        }

        public PatientModel GetPatientByID(string patientGUID)
        {
            var patient = _context.Patients.Where(p => p.GUIID == patientGUID).First();
            return patient.ToPatientModel();
        }

        public PatientModel UpdatePatient(PatientModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
