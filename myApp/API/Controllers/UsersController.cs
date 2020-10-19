using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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
        // Instead of IEnumerable we can use List
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            //var users = _context.Users.ToList();
            //return users;
            return _context.Users.ToList();
        }
        // 2 - to get a specific user of db
        //api/users/3
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            //var user = _context.Users.Find(id);
            //return user;
            return _context.Users.Find(id);
        }
    }
}