using FranMotors.DB;
using FranMotors.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Repositories
{

    public interface IHomeRepository
    {
        List<Motocicleta> GetAllMotocicleta(Motocicleta moto);
    }
    public class HomeRepository : IHomeRepository
    {
        private readonly FranMotorsContext context;
        public HomeRepository(FranMotorsContext context)
        {
            this.context = context;
        }
        public List<Motocicleta> GetAllMotocicleta(Motocicleta moto)
        {
            return context.Motocicletas.Where(o => o.Placa.Equals(moto.Placa)).ToList(); ;

        }
    }
}
