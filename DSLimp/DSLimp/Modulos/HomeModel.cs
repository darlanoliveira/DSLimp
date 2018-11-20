﻿
using DSLimp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSLimp.Modulos
{
    public class HomeModel
    {
        public static dynamic SalvaCliente(string nomecli, string contatocli, string bairro, string cidade, string telefone,
            string cnpj, string endereco, string pontoreferencia)
        {
            Cliente c = new Cliente();
            c.Cli_Nome = nomecli;
            c.Cli_Contato = contatocli;
            c.Cli_Bairro = bairro;
            c.Cli_Cidade = cidade;
            c.Cli_Telefone = telefone;
            c.Cli_Cnpj = cnpj;
            c.Cli_End = endereco;
            c.Cli_Ref = pontoreferencia;


            using (var repo = new ClienteDAO())
            {
                repo.Adicionar(c);
            }

                return null;
        }

        public static dynamic SalvaProduto(string descricaoproduto, double valorcusto, double valorvenda, string linha,byte[] foto)
        {
            Produto p = new Produto();
            p.Prod_Desc = descricaoproduto;
            p.Prod_Val_Cus = valorcusto;
            p.Prod_Val_Ven = valorvenda;
            p.Prod_Tipo = linha;
            p.Prod_Ft = foto;
           

            using(var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }

            return null;
        }

        public static dynamic RecuperarProdutos()
        {
            var lista = new List<dynamic>();
            using (var repo = new LojaContext())
            {
                 IList<Produto> produtos = repo.produtos.ToList();
               // IList<Produto> produtos = repo.produtos.Where(p => p.Id_Pro == 8).ToList();
                //lista.Add(produtos);

                return produtos;
            }
            
            
        }

        public static dynamic RecuperarUsuario(string email,string senha)
        {
            
            using (var repo = new LojaContext())
            {

                IList<LoginViewModel> usuarios = repo.usuarios
                                                 .Where(u => u.Email == email && u.Senha == senha)
                                                 .ToList();
                usuarios = usuarios;
                return usuarios;
            }
        }

        public static dynamic RecuperarClientes()
        {
            var lista = new List<dynamic>();
            using (var repo = new LojaContext())
            {
                IList<Cliente> clientes = repo.clientes.ToList();

                

                return clientes;
            }


        }

        public static dynamic RecuperarGastos()
        {
            var lista = new List<dynamic>();
            using (var repo = new LojaContext())
            {
                IList<Gasto> gastos = repo.gastos.ToList();

                return gastos;
            }


        }

       public static dynamic SalvaGastos(string desc, double valor,byte[] notafiscal, byte[] recibo)
        {
        

            Gasto g = new Gasto();
            g.Gas_desc = desc;
            g.Gas_valortotal = valor;
            g.Gas_ftnf = notafiscal;
            g.Gas_ftrec = recibo;

            using (var repo = new GastoDAO())
            {
                repo.Adicionar(g);
            }

            return null;
        }
    }
}
