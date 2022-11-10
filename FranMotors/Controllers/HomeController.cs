using FranMotors.DB;
using FranMotors.Manager;
using FranMotors.Models;
using FranMotors.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FranMotors.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository homeRepository;
        private readonly IAccountViewBagManager accountViewBagManager;

        public HomeController(IHomeRepository homeRepository, IAccountViewBagManager accountViewBagManager)
        {
            this.homeRepository = homeRepository;
            this.accountViewBagManager = accountViewBagManager;
        }

        public IActionResult Index()
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
           
            return View();
        }

        public IActionResult Privacy(Motocicleta moto)
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            if (IsReCaptchValid() == false)
            {
                ViewBag.Captcha = "Captcha Invalido";
                return View("Index");
            }

            var bmoto = homeRepository.GetAllMotocicleta(moto);
            foreach (var item in bmoto)
            {
                if (moto.Placa == item.Placa)
                {
                    return View("Privacy", bmoto);
                }
            }

            accountViewBagManager.ConfiguraViewBagError(ViewBag);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
