using ECommerceProjectWithWebAPI.Core.Helpers.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceProjectWithWebAPI.Core.Utilities.Security.Token
{
    public interface ITokenService
    {
        AccessToken CreateToken(int userId, string userName);
    }
}
