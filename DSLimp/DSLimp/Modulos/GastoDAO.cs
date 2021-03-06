﻿using DSLimp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSLimp.Modulos
{
    public class GastoDAO : IGastoDAO, IDisposable
    {
        private LojaContext contexto;

        public GastoDAO()
        {
            this.contexto = new LojaContext();
        }

        public void Adicionar(Gasto g)
        {
            contexto.gastos.Add(g);
            contexto.SaveChanges();
        }

        public void Atualizar(Gasto g)
        {
            contexto.gastos.Update(g);

            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Gasto> gastos()
        {
            return contexto.gastos.ToList();
        }

        public void Remover(Gasto g)
        {
            contexto.gastos.Remove(g);
            contexto.SaveChanges();
        }
    }
}
