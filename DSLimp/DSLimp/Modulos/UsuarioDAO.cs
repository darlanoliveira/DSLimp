using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSLimp.Models;

namespace DSLimp.Modulos
{
    public class UsuarioDAO /*: IUsuarioDAO, IDisposable*/
    {
        private LojaContext contexto;

       /* public UsuarioDAO()
        {
            this.contexto = new LojaContext();
        }

        public void Adicionar(LoginViewModel u)
        {
            contexto.usuarios.Add(u);
            contexto.SaveChanges();
        }

        public void Atualizar(LoginViewModel u)
        {
            contexto.usuarios.Update(u);

            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Remover(LoginViewModel u)
        {
            contexto.usuarios.Remove(u);
            contexto.SaveChanges();
        }

        public IList<LoginViewModel> usuarios()
        { 
           
            return contexto.usuarios.ToList();
        }
        */



    }
}
