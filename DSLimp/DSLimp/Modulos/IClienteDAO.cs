using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSLimp.Models;
using DSLimp.Modulos;

namespace DSLimp.Modulos
{
    interface IClienteDAO
    {
        void Adicionar(Cliente c);
        void Atualizar(Cliente c);
        void Remover(Cliente c);
        IList<Cliente> Clientes();
    }
}
