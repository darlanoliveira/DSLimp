using DSLimp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSLimp.Modulos
{
    interface IGastoDAO
    {
        void Adicionar(Gasto g);
        void Atualizar(Gasto g);
        void Remover(Gasto g);
        IList<Gasto> produtos();
    }
}
