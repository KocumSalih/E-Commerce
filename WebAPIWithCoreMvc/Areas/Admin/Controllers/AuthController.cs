using ECommerceProjectWithWebAPI.Entities.Dtos.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private IAuthApiService _authApiService;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _authApiService.LoginAsync(loginDto);
            if (user.Success)
            {
                _httpContextAccessor.HttpContext.Session.SetString("token",user.Data.Token);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Data.UserId.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name,user.Data.UserId.ToString()));
                var claimPrincipal = new ClaimsPrincipal(userClaims);
                var authProperties = new AuthenticationProperties() {  IsPersistent= loginDto.IsRememberMe };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authProperties);
                return RedirectToAction("Index","User",new { area="Admin"});
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı!");
            }
            return View();
        }
    }
}
