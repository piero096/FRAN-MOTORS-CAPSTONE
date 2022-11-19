using FranMotors.DB;
using FranMotors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FranMotors.Repositories
{

    public interface IAuthRepository
    {
        Account Login(string Username, string Password);
    }
    public class AuthRepository : IAuthRepository
    {
        private FranMotorsContext context;
        private IConfiguration configuration;
        public AuthRepository(FranMotorsContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public Account Login(string Username, string Password)
        {
            return context.Accounts
                .Where(o => o.Username.ToLower() == Username.ToLower() && o.Password == GetSHA256(Password)).FirstOrDefault();
        }
        [HttpGet]
        public string GetSHA256(string str)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(str);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }
}
