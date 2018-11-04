using DSLimp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSLimp.Modulos
{
    interface IUsuarioDAO
    {
        void Adicionar(LoginViewModel u);
        void Atualizar(LoginViewModel u);
        void Remover(LoginViewModel u);
        IList<LoginViewModel> usuarios();
    }
}
