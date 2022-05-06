﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIWithCoreMvc.ViewModels
{
    public class UserUpdateViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}