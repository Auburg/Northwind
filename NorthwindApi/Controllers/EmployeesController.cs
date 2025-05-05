using Microsoft.AspNetCore.Mvc;
using NorthwindDAL.UnitOfWork;
using NorthwindApi.Dto;
using NorthwindApi.Extensions;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthwindApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController(INorthwindUnitOfWork northwindUnitOfWork, ILogger<EmployeesController> logger) : ControllerBase
    {      

        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get([FromBody] PageRequestDto pageRequest)
        {
            try
            {
                var g = Request.HttpContext.User.Claims;


                return new OkObjectResult(northwindUnitOfWork.EmployeeRepository.GetEmployees(
                    pageRequest.AfterId, 
                    pageRequest.NumberOfRecords)
                    .Select(e=>e.EmployeeModelToDto()));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Problem("An error occurred retrieving employees");
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
