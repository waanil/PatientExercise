using System;
using System.Collections.Generic;
using Patient_Demographics_Domain.Models;
using Patient_Demographics_Domain.Interfaces;
using System.Xml.Serialization;
using System.IO;
using Patient_Demographics_Infrastructure.Entities;
using System.Linq;

namespace Patient_Demographics_Test
{
    public class TestRepo : IPatientRepository
    {
        private static List<Patients> patients = new List<Patients>();
         
        public string CreatePatrients(PatientModel patient)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(patient.GetType());
            serializer.Serialize(stringwriter, patient);
            patients.Add(new Patients { ID = patients.Count+1, PersonXML= stringwriter.ToString() });
            return stringwriter.ToString();
        }

        public bool DeletePatientByID(string patientGUIID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientModel> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public PatientModel GetPatientByID(string patientGUID)
        {
            
            PatientModel patient = null;
            for (int i = 0; i <= patients.Count - 1; i++)
            {
                StringReader stringReader = new StringReader(patients[i].PersonXML.ToString());
                XmlSerializer serializer = new XmlSerializer(typeof(PatientModel), new XmlRootAttribute("PatientModel"));
                patient = (PatientModel)serializer.Deserialize(stringReader);
                if(patient.PatientGUIID == patientGUID)
                break;

            }
            return patient;

        }

        public PatientModel UpdatePatient(PatientModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
