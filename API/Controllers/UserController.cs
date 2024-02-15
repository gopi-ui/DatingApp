using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]

//  /api/users
public class UserController : BaseApiController
{
    private readonly IMapper _mapper;

    // private readonly DataContext _context;   // create and assign feild 'constext"
    private readonly IUserRepository _userRepository;

    // public UserController(DataContext context)  // constructor
    // {
    //     _context = context;
    // }

    //section 8 commented users above and written new belo

    // public UserController(IUserRepository userRepository)
    // {
    //     _userRepository = userRepository;
    // }
    // [AllowAnonymous]

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    // {
    //     //var users = await _context.Users.ToListAsync();
    //   return Ok(await _userRepository.GetUsersAsync());
    //   
    // return users;
    //     //return Ok;  u can return Ok 
    // }
    //[AllowAnonymous]
    // [HttpGet("{id}")] // api/users/2
    // public async Task<ActionResult<AppUser>> GetUser(int id)
    // {
    //     return await _context.Users.FindAsync(id);
    // }


    // [HttpGet("{username}")]
    //     public async Task<ActionResult<AppUser>> GetUser(string username)
    //     {
    //         return await _userRepository.GetUserByUsernameAsync(username);
    //     }


    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
     {
    //     var users = await _userRepository.GetUsersAsync();
    //     var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
  var users = await _userRepository.GetMemebersAsync();
          return Ok(users);
    }
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemeberAsync(username);
       // return _mapper.Map<MemberDto>(user);
    }

}
