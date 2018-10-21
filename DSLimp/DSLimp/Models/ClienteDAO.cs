using DSLimp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSLimp.Dao
{
    class ClienteDAO : IClienteDAO, IDisposable
    {
        private LojaContext contexto;

        public ClienteDAO()
        {
            this.contexto = new LojaContext();
        }
        public void Adicionar(Cliente c)
        {            
                contexto.Clientes.Add(c);
                contexto.SaveChanges();
        }

        public void Atualizar(Cliente c)
        {
            contexto.Clientes.Update(c);

            contexto.SaveChanges();
        }

        public IList<Cliente> Clientes()
        {
            return contexto.Clientes.ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Remover(Cliente c)
        {
            contexto.Clientes.Remove(c);
            contexto.SaveChanges();
        }
    }
}
