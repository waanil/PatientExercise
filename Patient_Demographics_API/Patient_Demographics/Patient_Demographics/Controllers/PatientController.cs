using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Patient_Demographics_Domain.Interfaces;
using Patient_Demographics_Domain.Models;
using Patient_Demographics_Service.Interfaces;
using Patient_Demographics_Services;

namespace Patient_Demographics.Controllers
{
    [Route("api/[controller]")]

    //[EnableCors("AllowSpecificOrigin")]
    [EnableCors("MyPolicy")]
    public class PatientController : Controller
    {
        IPatientService _patientService;
        public PatientController(IPatientRepository patientRepo)
        {
            _patientService = new PatientService(patientRepo);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<PatientModel>  Get()
        {
            var patients = _patientService.GetAllPatients();
            return patients;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            var patient = _patientService.GetPatientByID(id);

            if (patient != null)
            {
                return Ok(patient);
            }

            else
            {
                return NotFound(id);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                var result = _patientService.CreatePatrients(patient);

                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
           throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
