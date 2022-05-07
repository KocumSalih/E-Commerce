using ECommerceProjectWithWebAPI.Core.Helpers.JWT;
using ECommerceProjectWithWebAPI.Core.Utilities.Responses;
using ECommerceProjectWithWebAPI.Entities.Dtos.UserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.Business.Abstract
{
    public interface IUserService
    {
        Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync();
        Task<ApiDataResponse<UserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto entity);
        Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto entity);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
        //Task<ApiDataResponse<AccessToken>> Authenticate(UserForLoginDto userForLoginDto);
    }
}
