
using ECommerceProjectWithWebAPI.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ViewModels;

namespace WebAPIWithCoreMvc.Controllers
{
    public class UsersController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private readonly string url = "http://localhost:62853/api/";
        #endregion

        #region Constructor
        public UsersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        } 
        #endregion

        public async Task<IActionResult> Index()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserDetailDto>>(url+"Users/GetList");
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.GenderList = GenderFill();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddViewModel userAddViewModel)
        {
            UserAddDto userAddDto = new UserAddDto()
            {
                FirstName = userAddViewModel.FirstName,
                LastName = userAddViewModel.LastName,
                Gender = userAddViewModel.GenderId == 1 ? true : false,
                Address=userAddViewModel.Address,
                DateOfBirth=userAddViewModel.DateOfBirth,
                Email=userAddViewModel.Email,
                Password=userAddViewModel.Password,
                UserName=userAddViewModel.UserName,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url+"Users/Add",userAddDto);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        private List<Gender> GenderFill()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender(){Id=1,GenderName="Erkek"});
            genders.Add(new Gender(){Id=2,GenderName="Kadın"});
            return genders;
        }

        private class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }
    }
}
