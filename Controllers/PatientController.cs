using Microsoft.AspNetCore.Mvc;
using Patients.Data;
using Patients.Model;


namespace Patients.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PatientController : ControllerBase
    {
        [HttpGet("patients")]
        public async Task<ActionResult<List<PatientPerson>>> GetPatients()
        {
            var function = new PeopleData();
            return await function.GetPatients();
        }
        [HttpGet("doctors")]
        public async Task<ActionResult<List<Person>>> GetDoctors()
        {
            var function = new PeopleData();
            return await function.GetDoctors();
        }

        [HttpPost("patients")]
        public async Task<ActionResult> CreatePatient([FromBody] PatientDTO parameters)
        {
            var function = new PeopleData();
            await function.InsertPatient(parameters);
            return NoContent();
        }

        [HttpPost("doctors")]
        public async Task<ActionResult> CreateDoctor([FromBody] Person parameters)
        {
            var function = new PeopleData();
            await function.InsertDoctor(parameters);
            return NoContent();

        }

        [HttpDelete("patients/{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var function = new PeopleData();
            await function.DeletePatient(id);
            return NoContent();

        }

        [HttpDelete("doctors/{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var function = new PeopleData();
            await function.DeleteDoctor(id);
            return NoContent();

        }

    }
}
