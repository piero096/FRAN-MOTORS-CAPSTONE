using FranMotors.DB;
using FranMotors.Models;
using FranMotors.Repositories;
using FranMotors.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            if (IsReCaptchValid() == false)
            {
                ViewBag.Captcha = "Captcha Invalido";
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
        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LfQzkAiAAAAAMTQxR1LbSNV7K8twMUFjMbojKK4";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}
