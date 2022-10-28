using FranMotors.DB;
using FranMotors.Manager;
using FranMotors.Models;
using FranMotors.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Controllers
{
    public class AdminController : Controller
    {
        private readonly FranMotorsContext context;
        private readonly IAdminRepository adminRepository;
        private readonly IAccountViewBagManager accountViewBagManager;

        public AdminController(FranMotorsContext context, IAdminRepository adminRepository, IAccountViewBagManager accountViewBagManager)
        {
            this.context = context;
            this.adminRepository = adminRepository;
            this.accountViewBagManager = accountViewBagManager;
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View(new Account());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Mecanico()
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View();
        }
        [HttpGet]
        public IActionResult ListMeca(string buscarmeca)
        {
            return View(adminRepository.GetAllMecanicos(buscarmeca));
        }
        public IActionResult EditMecanico(int id)
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            var meca = context.Accounts.Where(o => o.Id == id).FirstOrDefault();
            return View(meca);
        }
        [HttpPost]
        public IActionResult Registrar(Account account)
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            if (ModelState.IsValid && account != null)
            {
                adminRepository.Registrar(account);
                return RedirectToAction("Mecanico", new Account());
            }

            return View(new Account());
        }
        [HttpPost]
        public IActionResult Edit(Account account, string estado)
        {

            adminRepository.Edit(account,estado);

            return RedirectToAction("Mecanico");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var account = context.Accounts.Find(id);
            context.Accounts.Remove(account);
            context.SaveChanges();

            return RedirectToAction("Mecanico");
        }

    }
}
