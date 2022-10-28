using FranMotors.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranMotors.Manager
{
    public interface IAccountViewBagManager
    {
        void ConfiguraViewBagForVirwAccount(dynamic viewBag);
        void ConfiguraViewBagForViewListHistory(dynamic viewBag, int idcliente);
        void ConfiguraViewBagError(dynamic viewBag);
        void ConfiguraViewBagListMoto(dynamic viewBag, int id);
    }
    public class AccountViewBagManager : IAccountViewBagManager
    {
        private readonly FranMotorsContext context;

        public AccountViewBagManager(FranMotorsContext context)
        {
            this.context = context;
        }

        public void ConfiguraViewBagError(dynamic viewBag)
        {
            viewBag.Error = "Placa no encontrada";
        }

        public void ConfiguraViewBagForViewListHistory(dynamic viewBag, int idcliente)
        {
            viewBag.moto = context.Motocicletas.FirstOrDefault(o => o.IdCliente == idcliente);
        }

        public void ConfiguraViewBagForVirwAccount(dynamic viewBag)
        {
            viewBag.account = context.Accounts.ToList();
        }

        public void ConfiguraViewBagListMoto(dynamic viewBag, int id)
        {
            viewBag.Cliente = context.Clientes.Where(o => o.Id == id).FirstOrDefault();
        }
    }
}
