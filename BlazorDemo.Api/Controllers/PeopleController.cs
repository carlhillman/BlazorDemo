using System;
using System.Threading.Tasks;
using BlazorDemo.DataAccess.Models;
using BlazorDemo.DataAccess.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorDemo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleDataService _peopleDataService;
        public PeopleController(IPeopleDataService peopleDataService)
        {
            _peopleDataService = peopleDataService;
        }
        // GET: api/<PersonController>
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _peopleDataService.GetPeople();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonAsync(int id)
        {
            try
            {
                var result = await _peopleDataService.GetPerson(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<int> GetLastInsertedPersonIdAsync()
        {
            try
            {
                var id = await _peopleDataService.GetLastInsertedPersonId();
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        // POST api/<PersonController>
        [HttpPost()]
        public async Task PostAsync([FromBody] Person person)
        {
            try
            {
                await _peopleDataService.InsertPerson(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Person person)
        {
            try
            {
                await _peopleDataService.UpdatePerson(id, person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            try
            {
                await _peopleDataService.DeletePerson(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
