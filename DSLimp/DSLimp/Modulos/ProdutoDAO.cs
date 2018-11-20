using DSLimp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSLimp.Modulos
{
    public class ProdutoDAO : IProdutoDAO,IDisposable
    {
        private LojaContext contexto;

        public ProdutoDAO()
        {
            this.contexto = new LojaContext();
        }

        public void Adicionar(Produto p)
        {
            contexto.produtos.Add(p);
            contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            contexto.produtos.Update(p);

            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Produto> produtos()
        {
            return contexto.produtos.ToList();
        }

        public void Remover(Produto p)
        {
            contexto.produtos.Remove(p);
            contexto.SaveChanges();
        }
    }
}
