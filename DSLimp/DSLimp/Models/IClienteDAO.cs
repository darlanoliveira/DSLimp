using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSLimp.Models
{
    interface IClienteDAO
    {
        void Adicionar(Cliente c);
        void Atualizar(Cliente c);
        void Remover(Cliente c);
        IList<Cliente> Clientes();
    }
}
