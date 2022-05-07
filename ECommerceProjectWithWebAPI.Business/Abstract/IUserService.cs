using ECommerceProjectWithWebAPI.Core.Utilities.Responses;
using ECommerceProjectWithWebAPI.Entities.Concrete;
using ECommerceProjectWithWebAPI.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.Business.Abstract
{
    public interface IUserService
    {
        Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null);
        Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<User, bool>> filter);
        Task<ApiDataResponse<UserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto entity);
        Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto entity);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
        //Task<ApiDataResponse<AccessToken>> Authenticate(UserForLoginDto userForLoginDto);
    }
}
