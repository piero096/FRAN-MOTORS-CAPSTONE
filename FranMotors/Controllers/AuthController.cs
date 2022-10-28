using FranMotors.DB;
using FranMotors.Models;
using FranMotors.Repositories;
using FranMotors.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FranMotors.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly IAuthRepository authRepository;        
        public AuthController(IAuthService authService, IAuthRepository authRepository)
        {
            this.authService = authService;
            this.authRepository = authRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var user = authRepository.Login(Username.ToLower(), Password);
            if (user == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View("Login");
            }
            if (user.Estado == false)
            {
                ViewBag.Estado = "Su usuario se encuentra inactivo contacte con el administrador.";
                return View("Login");
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, Username),
            };


            authService.Login(claims);


            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            authService.Logout();
            return RedirectToAction("Login");
        }
    }
}
