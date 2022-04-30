using ECommerceProjectWithWebAPI.Business.Abstract;
using ECommerceProjectWithWebAPI.DAL.Abstract;
using ECommerceProjectWithWebAPI.Entities.Concrete;
using ECommerceProjectWithWebAPI.Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.Business.Concrete
{

    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> usersDetail = new List<UserDetailDto>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response)
            {
                usersDetail.Add(new UserDetailDto()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    DateOfBirth = item.DateOfBirth,
                    UserName = item.UserName,
                    Address = item.Address,
                    Email = item.Email,
                    UserId = item.Id
                });
            }

            return usersDetail;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user!=null)
            {
                UserDto userDto = new UserDto()
                {
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Gender = user.Gender,
                    UserId = user.Id
                };
                return userDto; 
            }
            return null;
        }

        public async Task<UserDto> AddAsync(UserAddDto entity)
        {
            User user = new User()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                //Todo:CreatedDate ve CreatedUSerId düzenlenecek..
                Gender = entity.Gender,
                DateOfBirth = entity.DateOfBirth,
                UserName = entity.UserName,
                Address = entity.Address,
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                Email = entity.Email,
                Password = entity.Password
            };

            var userAdd = await _userDal.AddAsync(user);

            UserDto userDto = new UserDto()
            {
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
                Gender = userAdd.Gender,
                DateOfBirth = userAdd.DateOfBirth,
                UserName = userAdd.UserName,
                Address = userAdd.Address,
                Email = userAdd.Email,
                UserId = userAdd.Id
            };

            return userDto;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto entity)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == entity.UserId);
            User user = new User()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                DateOfBirth = entity.DateOfBirth,
                UserName = entity.UserName,
                Address = entity.Address,
                Email = entity.Email,
                Id = entity.UserId,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                Password = getUser.Password,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = 1
            };
            var userUpdated = await _userDal.UpdateAsync(user);

            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                FirstName = userUpdated.FirstName,
                LastName = userUpdated.LastName,
                Gender = userUpdated.Gender,
                DateOfBirth = userUpdated.DateOfBirth,
                UserName = userUpdated.UserName,
                Address = userUpdated.Address,
                Email = userUpdated.Email,
                Password = userUpdated.Password,
                UserId = userUpdated.Id
            };
            return userUpdateDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }
    }
}
