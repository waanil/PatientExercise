using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Demographics.Controllers;
using Patient_Demographics_Domain.Interfaces;
using Patient_Demographics_Domain.Models;
using Patient_Demographics_Service.Interfaces;
using Patient_Demographics_Services;

namespace Patient_Demographics_Test
{
    [TestClass]
    public class PatientControllerTest
    {
        private IPatientRepository testPatientRepo;
        IPatientService testPatientService;
        PatientController controller; 
        public PatientControllerTest()
        {
           testPatientRepo = new TestRepo();
           
            controller = new PatientController(testPatientRepo);
        }
        [TestMethod]
        public void PatientControllerTestCreatePatientOKResult()
        {

            var result = controller.Post(GetDummyPatient());
            // Assert for OK result
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void PatientControllerTestCreatePatientGUID()
        {
            try
            {
                var result = controller.Post(GetDummyPatient());
                // Assert
                var okObjectResult = result as OkObjectResult;
                //Assert.IsNotNull(okObjectResult);

                var model = okObjectResult.Value as PatientModel;
                //Assert.IsNotNull(model);

                var newGUID = model.PatientGUIID;
                Assert.IsNotNull(newGUID);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void PatientControllerTestGetPatientGUID()
        {
            try
            {
                var result = controller.Post(GetDummyPatient());
                // Assert
                var okObjectResult1 = result as OkObjectResult;
                //Assert.IsNotNull(okObjectResult);

                var model1 = okObjectResult1.Value as PatientModel;
                //Assert.IsNotNull(model);

                var setGUID = model1.PatientGUIID;
                var tempPatient  = controller.Get(setGUID);
                // Assert
                var okObjectResult2 = tempPatient as OkObjectResult;
                //Assert.IsNotNull(okObjectResult);

                var model2 = okObjectResult2.Value as PatientModel;
                //Assert.IsNotNull(model);

                var receivedGUID = model2.PatientGUIID;
                Assert.AreEqual(setGUID,receivedGUID);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }




        //private method to test prep
       
        private PatientModel GetDummyPatient()
        {
             return new PatientModel { ForeName = "Anil", SurName = "Kumar", DateOfBirth = DateTime.Parse("05/02/1984"), Gender = GenderEnum.Male };
        }
    }

   


}
