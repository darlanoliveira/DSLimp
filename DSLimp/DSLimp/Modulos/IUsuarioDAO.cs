using DSLimp.Models;
using System.Collections.Generic;

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
