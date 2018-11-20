using DSLimp.Models;
using System.Collections.Generic;

namespace DSLimp.Modulos
{
    interface IGastoDAO
    {
        void Adicionar(Gasto g);
        void Atualizar(Gasto g);
        void Remover(Gasto g);
        IList<Gasto> gastos();
    }
}
