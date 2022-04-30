using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.Business.Abstract
{
    using ECommerceProjectWithWebAPI.Entities.Dtos.UserDtos;

    public interface IUserService
    {
        Task<IEnumerable<UserDetailDto>> GetListAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> AddAsync(UserAddDto entity);
        Task<UserUpdateDto> UpdateAsync(UserUpdateDto entity);
        Task<bool> DeleteAsync(int id);
    }
}
