﻿using ECommerceProjectWithWebAPI.Core.Entity.Abstract;
using System;

namespace ECommerceProjectWithWebAPI.Entities.Dtos.User
{
    public class UserDto:IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}