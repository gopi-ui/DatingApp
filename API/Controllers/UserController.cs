using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]

//  /api/users
public class UserController : BaseApiController
{
    private readonly DataContext _context;   // create and assign feild 'constext"
    public UserController(DataContext context)  // constructor
    {
        _context = context;
    }
    [AllowAnonymous]

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
        //return Ok;  u can return Ok 
    }
    //[AllowAnonymous]
    [HttpGet("{id}")] // api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

}
