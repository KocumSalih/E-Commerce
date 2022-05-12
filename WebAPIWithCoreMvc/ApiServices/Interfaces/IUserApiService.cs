﻿using ECommerceProjectWithWebAPI.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<List<UserDetailDto>> GetListAsync();
    }
}
