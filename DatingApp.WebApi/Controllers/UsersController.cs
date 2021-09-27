using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.WebApi.Data;
using DatingApp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<ApplicationUser>))]
        public async Task<OkObjectResult> All()
            => Ok(await _context.Users
                            .AsNoTracking()
                            .ToListAsync());


        // users/3
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ById([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user is null) 
            {
                return NotFound();
            }


            return Ok(user);
        }
    }
}