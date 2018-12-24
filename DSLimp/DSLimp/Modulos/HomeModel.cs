
using DSLimp.Models;
using System;
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

 
        /*  public static dynamic RecuperarUsuario(string email,string senha)
          {

              using (var repo = new LojaContext())
              {

                  IList<LoginViewModel> usuarios = repo.usuarios
                                                   .Where(u => u.Email == email && u.Senha == senha)
                                                   .ToList();
                  usuarios = usuarios;
                  return usuarios;
              }
          }*/

        public static dynamic RecuperarClientes()
        {
            var lista = new List<dynamic>();
            using (var repo = new LojaContext())
            {
                IList<Cliente> clientes = repo.clientes.ToList();

                

                return clientes;
            }


        }

        public static dynamic BuscaCliente(string cliente)
        {
            var lista = new List<dynamic>();
            using (var repo = new LojaContext())
            {
                IList<Cliente> clientes = repo.clientes.Where(c => c.Cli_Nome.Contains(cliente)).ToList();
                return clientes;
            }


        }

        public static dynamic BuscaProduto(string codigo)
        {
            
            using (var repo = new LojaContext())
            {
                IList<Produto> lista_prod = repo.produtos.Where(c => c.Prod_Cod.Contains(codigo)).ToList();
                return lista_prod;
            }


        }

        public static dynamic BuscaProduto(int codigo)
        {

            using (var repo = new LojaContext())
            {
                IList<Produto> lista_prod = repo.produtos.Where(c => c.Id_Pro == codigo).ToList();
                return lista_prod;
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

        public static dynamic GastoData(DateTime inicial, DateTime final)
        {
            var lista = new List<dynamic>();
            using (var repo = new LojaContext())
            {
                IList<Gasto> gastos = repo.gastos.Where(d => d.Gas_data >= inicial & d.Gas_data <= final).ToList();

                return gastos;
            }


        }

        public static dynamic SalvaGastos(string desc, double valor,byte[] notafiscal, byte[] recibo,DateTime datagasto)
        {
        

            Gasto g = new Gasto();
            g.Gas_desc = desc;
            g.Gas_valortotal = valor;
            g.Gas_ftnf = notafiscal;
            g.Gas_ftrec = recibo;
            g.Gas_data = datagasto;

            using (var repo = new GastoDAO())
            {
                repo.Adicionar(g);
            }

            return null;
        }

        public static dynamic AtualizaProdutoQtd(int qtd,int codigo)
        {
            using (var repo = new LojaContext())
            {
                Produto p = repo.produtos.First(q => q.Id_Pro == codigo);
                p.Prod_Qtd = qtd;
                repo.SaveChanges();
            }
            return null;

        }
    }
}
