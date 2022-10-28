using FranMotors.DB;
using FranMotors.Manager;
using FranMotors.Models;
using FranMotors.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    }
}
