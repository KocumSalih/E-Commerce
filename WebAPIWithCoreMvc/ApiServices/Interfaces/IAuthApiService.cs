using ECommerceProjectWithWebAPI.Core.Utilities.Responses;
using ECommerceProjectWithWebAPI.Entities.Dtos.Auth;
using ECommerceProjectWithWebAPI.Entities.Dtos.User;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto); 
    }
}
