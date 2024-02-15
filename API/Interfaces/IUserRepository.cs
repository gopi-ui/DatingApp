using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);

    Task<bool> SaveAllAsync();

    Task<IEnumerable<AppUser>> GetUsersAsync();

    Task<AppUser> GetUserByIdAsync(int id);
    Task<AppUser> GetUserByUsernameAsync(string username);

    //here using member dto for querable 

    Task<IEnumerable<MemberDto>> GetMemebersAsync();
    Task<MemberDto> GetMemeberAsync(string username);
}
