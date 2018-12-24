using Patient_Demographics_Domain.Models;
using Patient_Demographics_Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Patient_Demographics_Infrastructure.Mappers
{
   /// <summary>
   /// From Model to DB Object and vis-versa
   /// </summary>
    public static class PatientMapper
    {
        public static Patients TOPatients(this PatientModel obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);

            stringwriter.ToString();
            Patients dbModel = new Patients() { GUIID = obj.PatientGUIID, PersonXML = stringwriter.ToString() };

            return dbModel;
        }
        public static PatientModel ToPatientModel(this Patients obj)
        {
            StringReader stringReader = new StringReader(obj.PersonXML.ToString());
            XmlSerializer serializer = new XmlSerializer(typeof(PatientModel), new XmlRootAttribute("PatientModel"));
            PatientModel model  = (PatientModel)serializer.Deserialize(stringReader);
            return model;
        }

    }
}
