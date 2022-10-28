using FranMotors.DB;
using FranMotors.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FranMotors.Repositories
{

    public interface IAdminRepository
    {
        void Registrar(Account account);
        void Edit(Account account, string estado);
        List<Account> GetAllMecanicos(string buscarmeca);
    }
    public class AdminRepository : IAdminRepository
    {
        private readonly FranMotorsContext context;
        private IConfiguration configuration;
        public AdminRepository(FranMotorsContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public void Edit(Account account, string estado)
        {
            var accounts = context.Accounts.Find(account.Id);
            accounts.Nombre = account.Nombre;
            accounts.Apellidos = account.Apellidos;
            accounts.Dni = account.Dni;
            accounts.Correo = account.Correo;
            accounts.Telefono = account.Telefono;
            accounts.Username = account.Username.ToLower();
            if (estado == "Activo")
            {
                accounts.Estado = true;
            }
            else
            {
                accounts.Estado = false;
            }

            context.SaveChanges();
        }

        public List<Account> GetAllMecanicos(string buscarmeca)
        {
            if (!string.IsNullOrEmpty(buscarmeca))
            {
                return context.Accounts.Where(o => o.Nombre.Contains(buscarmeca) || o.Apellidos.Contains(buscarmeca)).ToList();
            }
            return context.Accounts.ToList();
        }

        public void Registrar(Account account)
        {
            account.Tipo = "Mecanico";
            account.Estado = true;
            account.Username = account.Username.ToLower();
            account.Password = CreateHash(account.Password);
            context.Accounts.Add(account);
            context.SaveChanges();
        }
        private string CreateHash(string input)
        {
            var sha = SHA512.Create();
            input += configuration.GetValue<string>("Key");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}
