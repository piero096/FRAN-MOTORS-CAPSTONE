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
        public AdminRepository(FranMotorsContext context)
        {
            this.context = context;
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
            accounts.Password = GetSHA256(account.Password);
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
            account.Password = GetSHA256(account.Password);
            context.Accounts.Add(account);
            context.SaveChanges();
        }
        public string GetSHA256(string str)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(str);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        public string Desencriptar(string pass)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(pass);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
