using System;
using System.Threading.Tasks;

using BlazorDemo.DataAccess.Services;
using BlazorDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorDemo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataService _userDataService;
        public UserController(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }
        // GET: api/<UserController>
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _userDataService.GetUsers();
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
                var result = await _userDataService.GetUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<int> GetLastInsertedUserIdAsync()
        {
            try
            {
                var id = await _userDataService.GetLastInsertedUserId();
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        // POST api/<UserController>
        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] User person)
        {
            try
            {
                var response = await _userDataService.InsertUser(person);
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
        public async Task<IActionResult> PutAsync(int id, [FromBody] User person)
        {
            try
            {
                var response = await _userDataService.UpdateUser(id, person);
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
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _userDataService.DeleteUser(id);
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
