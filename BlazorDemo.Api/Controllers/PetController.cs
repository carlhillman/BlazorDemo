using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BlazorDemo.DataAccess.Services;
using System;

using BlazorDemo.Models;

namespace BlazorDemo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetDataService _petDataService;
        public PetController(IPetDataService petDataService)
        {
            _petDataService = petDataService;
        }
        // GET: api/<UserController>
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _petDataService.GetPets();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await _petDataService.GetPet(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<int> GetLastInsertedPetIdAsync()
        {
            try
            {
                var id = await _petDataService.GetLastInsertedPetId();
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        // POST api/<UserController>
        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] Pet pet)
        {
            try
            {
                var response = await _petDataService.InsertPet(pet);
                if (response)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Pet pet)
        {
            try
            {
              //  var response = await _petDataService.up(id, person);
                //if (response)
                //{
                //    return Ok();
                //}
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _petDataService.DeletePet(id);
                if (response)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {   
                return BadRequest();
            }
        }
    }
}
