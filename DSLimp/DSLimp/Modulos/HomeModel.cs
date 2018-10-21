
using DSLimp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public static dynamic SalvaProduto(string descricaoproduto, double valorcusto, double valorvenda, string telefone, string cnpj, string endereco, string pontoreferencia)
        {
            Produto p = new Produto();
            p.Prod_Desc = descricaoproduto;
            p.Prod_Val_Cus = valorcusto;
            p.Prod_Val_Ven = valorvenda;
            p.Prod_Tel = telefone;
            p.Prod_Cnpj = cnpj;
            p.Prod_End = endereco;
            p.Prod_Ref = pontoreferencia;

            using(var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }

            return null;
        }
    }
}
