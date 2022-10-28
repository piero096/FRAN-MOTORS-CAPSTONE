﻿using FranMotors.DB;
using FranMotors.Manager;
using FranMotors.Models;
using FranMotors.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FranMotors.Controllers
{
    public class MecanicoController : Controller
    {
        private FranMotorsContext context;
        private readonly IMecanicoRepository mecanicoRepository;
        private readonly IAccountViewBagManager accountViewBagManager;

        public MecanicoController(FranMotorsContext context, IMecanicoRepository mecanicoRepository, IAccountViewBagManager accountViewBagManager)
        {
            this.context = context;
            this.mecanicoRepository = mecanicoRepository;
            this.accountViewBagManager = accountViewBagManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View();
        }
        public IActionResult ListMoto(int id)
        {
            var moto = mecanicoRepository.ListMotoForClient(id);
            accountViewBagManager.ConfiguraViewBagListMoto(ViewBag, id);
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View(moto);
        }
        [HttpGet]
        public IActionResult ListCliente()
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View();

        }
        [HttpGet]
        public IActionResult AllClientes(string buscarClientes)
        {

            return View(mecanicoRepository.GetAllClientes(buscarClientes));
        }
        [HttpGet]
        public IActionResult EditCliente(int id)
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            var clie = context.Clientes.Where(o => o.Id == id).FirstOrDefault();

            return View(clie);
        }
        [HttpGet]
        public IActionResult RegisterMoto(int id)
        {
            var clie = context.Clientes.FirstOrDefault(o => o.Id == id);
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View(clie);
        }
        [HttpGet]
        public IActionResult RegHistory(int id)
        {
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            var moto = context.Motocicletas.FirstOrDefault(o => o.Id == id);
            return View(moto);
        }
        [HttpGet]
        public IActionResult VerHistoria(int id, int idcliente)
        {
            var hist = mecanicoRepository.LisHistorialForMoto(id, idcliente);
            accountViewBagManager.ConfiguraViewBagForViewListHistory(ViewBag, idcliente);
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View(hist);
        }
        [HttpGet]
        public IActionResult EditMoto(int id)
        {
            var edmoto = context.Motocicletas.Where(o => o.Id == id).FirstOrDefault();
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            return View(edmoto);
        }
        [HttpPost]
        public IActionResult RegHistory(int id, Historial historial, int idcliente)
        {
            mecanicoRepository.RegistrarHistoria(id, historial, idcliente);
            return RedirectToAction("ListMoto", new { Id = idcliente });
        }
        [HttpPost]
        public IActionResult RegisterMoto(int id, Motocicleta moto, List<IFormFile> imagesMoto, List<IFormFile> imagesTarjeta)
        {
            mecanicoRepository.RegisterMoto(id, moto, imagesMoto, imagesTarjeta);

            return RedirectToAction("ListCliente");
        }
        [HttpPost]
        public IActionResult Register(Cliente cliente, List<IFormFile> images)
        { 
            accountViewBagManager.ConfiguraViewBagForVirwAccount(ViewBag);
            if (ModelState.IsValid && cliente != null)
            {
                mecanicoRepository.RegistrarCliente(cliente, images);
                return RedirectToAction("ListCliente");
            }

            return View();
        }
        [HttpPost]
        public IActionResult EditCliente(Cliente cliente)
        {
            var cli = context.Clientes.Find(cliente.Id);
            cli.Nombre = cliente.Nombre;
            cli.Apellido = cliente.Apellido;
            cli.Dni = cliente.Dni;
            cli.Correo = cliente.Correo;
            cli.Telefono = cliente.Telefono;
            context.SaveChanges();
            return RedirectToAction("ListCliente");
        }
        [HttpPost]
        public IActionResult EditMoto(Motocicleta moto, int idcliente)
        {
            mecanicoRepository.EditarMoto(moto, idcliente);

            return RedirectToAction("ListMoto", new { Id = idcliente });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = context.Clientes.Find(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();

            return RedirectToAction("ListCliente");
        }
        [HttpPost]
        public IActionResult sendEmail(Motocicleta moto, int idcliente)
        {
            EnviarCorreo(moto.Id, idcliente);
            return RedirectToAction("ListMoto", new { Id = idcliente });
        }
        public void EnviarCorreo(int motoid, int idcliente)
        {
            MailMessage correo = new MailMessage();
            var correoCliente = context.Clientes.Where(o => o.Id == idcliente).FirstOrDefault();
            var motoclie = context.Motocicletas.Find(motoid);
            correo.From = new MailAddress("riosan375@gmail.com");
            correo.To.Add(correoCliente.Correo);
            correo.Subject = "Estado de motocicleta";
            correo.Body = "ESTADO EN EL QUE SE ENCUENTRA LA MOTO: " + motoclie.EstadoMoto + motoclie.Placa + motoclie.Marca;
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            var credentials = new System.Net.NetworkCredential("riosan375@gmail.com", "vzkxdsgpoimkuxim");
            client.Credentials = credentials;
            client.Send(correo);
        }
    }
}