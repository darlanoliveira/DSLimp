using DSLimp.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DSLimp.Models
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
                contexto.clientes.Add(c);
                contexto.SaveChanges();
        }

        public void Atualizar(Cliente c)
        {
            contexto.clientes.Update(c);

            contexto.SaveChanges();
        }

        public IList<Cliente> clientes()
        {
            return contexto.clientes.ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Remover(Cliente c)
        {
            contexto.clientes.Remove(c);
            contexto.SaveChanges();
        }
    }
}
