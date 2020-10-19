using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        // Add to endpoints in the database 
        // 1 to get all users of the db 
        [HttpGet]
        // SYNCHRONOUS VERSION
        // Instead of IEnumerable we can use List
        /*  public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            //var users = _context.Users.ToList();
            //return users;
            return _context.Users.ToList();
        } */

        // ASYNCHRONOUS VERSION - all the code accessing of the db should be async
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        // 2 - to get a specific user of db
        //api/users/3
        [HttpGet("{id}")]
        // SYNCHRONOUS VERSION
        /* public ActionResult<AppUser> GetUser(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;
            return _context.Users.Find(id); // synchronous 
        } */
        
        // ASYNCHRONOUS VERSION - all the code accessing of the db should be async
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}