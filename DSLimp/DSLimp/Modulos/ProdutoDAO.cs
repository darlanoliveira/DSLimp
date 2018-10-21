using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSLimp.Models;
using DSLimp.Modulos;

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
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            contexto.Produtos.Update(p);

            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return contexto.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            contexto.Produtos.Remove(p);
            contexto.SaveChanges();
        }
    }
}
