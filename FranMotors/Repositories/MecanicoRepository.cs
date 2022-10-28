using FranMotors.DB;
using FranMotors.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Repositories
{
    public interface IMecanicoRepository
    {
        void RegistrarCliente(Cliente cliente, List<IFormFile> img);
        List<Cliente> GetAllClientes(string buscarClientes);
        void RegisterMoto(int id, Motocicleta moto, List<IFormFile> imagesMoto, List<IFormFile> imagesTarjeta);
        void RegistrarHistoria(int id, Historial history, int idcliente);
        List<Historial> LisHistorialForMoto(int id, int idcliente);
        List<Motocicleta> ListMotoForClient(int id);
        void EditarMoto(Motocicleta moto, int idcliente);
        Account LoggedUser();
    }
    public class MecanicoRepository : IMecanicoRepository
    {
        private readonly FranMotorsContext context;
        private readonly IHttpContextAccessor _context;
        private readonly IWebHostEnvironment hosting;
        public MecanicoRepository(FranMotorsContext context, IHttpContextAccessor _context, IWebHostEnvironment hosting)
        {
            this.context = context;
            this._context = _context;
            this.hosting = hosting;
        }

        public List<Cliente> GetAllClientes(string buscarClientes)
        {
            var user = LoggedUser();

            if (!string.IsNullOrEmpty(buscarClientes))
            {
                return context.Clientes.Where(o => o.IdMecanico == user.Id && o.Nombre.Contains(buscarClientes) || o.Apellido.Contains(buscarClientes)).ToList();
            }
            return context.Clientes.Where(o => o.IdMecanico == user.Id).ToList();
        }

        public List<Motocicleta> ListMotoForClient(int id)
        {            
            return context.Motocicletas.Where(o => o.IdCliente == id).ToList();
        }

        public void RegisterMoto(int id, Motocicleta moto, List<IFormFile> imagesMoto, List<IFormFile> imagesTarjeta)
        {
            context.Motocicletas.Add(new Motocicleta
            {
                Placa = moto.Placa.ToUpper(),
                Marca = moto.Marca.ToUpper(),
                NumSerie = moto.NumSerie.ToUpper(),
                Cilindrada = moto.Cilindrada.ToUpper(),
                Año = moto.Año,
                IdCliente = id,
                EstadoMoto = moto.EstadoMoto.ToUpper(),
                ImgMoto = SaveFile(imagesMoto[0]),
                ImgTarjeta = SaveFile(imagesTarjeta[0])
            });
            context.SaveChanges();
        }

        public void RegistrarCliente(Cliente cliente, List<IFormFile> images)
        {
            var user = LoggedUser();
            cliente.IdMecanico = user.Id;
            cliente.ImageDni = SaveFile(images[0]);            
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }
        public Account LoggedUser()
        {
            var claim = _context.HttpContext.User.Claims.First();
            string username = claim.Value;
            var user = context.Accounts.First(o => o.Username == username);


            return user;
        }

        public void RegistrarHistoria(int id, Historial history, int idcliente)
        {
            var fecha = DateTime.Now;
            context.Historials.Add(new Historial
            {
                Detalle = history.Detalle,
                Precio = history.Precio,
                Tipo = history.Tipo,
                Fecha = fecha,
                IdMoto = id
            });
            context.SaveChanges();
        }

        public List<Historial> LisHistorialForMoto(int id, int idcliente)
        {
            return context.Historials.Where(o => o.IdMoto == id).ToList();
        }

        public void EditarMoto(Motocicleta moto, int idcliente)
        {
            var editmoto = context.Motocicletas.Find(moto.Id);
            editmoto.Placa = moto.Placa.ToUpper();
            editmoto.Marca = moto.Marca.ToUpper();
            editmoto.NumSerie = moto.NumSerie.ToUpper();
            editmoto.Cilindrada = moto.Cilindrada.ToUpper();
            editmoto.EstadoMoto = moto.EstadoMoto.ToUpper();
            context.SaveChanges();
        }
        private string SaveFile(IFormFile item)
        {
            string relativePath = "";
            if (item.Length > 0)
            {
                relativePath = Path.Combine("files", item.FileName);
                var filePath = Path.Combine(hosting.WebRootPath, relativePath);
                var stream = new FileStream(filePath, FileMode.Create);
                item.CopyTo(stream);
                stream.Close();
            }
            return "/" + relativePath.Replace('\\', '/');
        }        
    }
}
