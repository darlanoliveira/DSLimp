
using DSLimp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static dynamic BuscaUsuario (LoginViewModel vm)
        {
            

            return null;
        }

      /*  public static dynamic SalvaGastos(string desc, double valor,IFormfile notafiscal, IFormfile recibo)
        {
            byte[] nfbytes = notafiscal.ToArray();
            MemoryStream nb = new MemoryStream(nfbytes);

            byte[] recibobytes = notafiscal.ToArray();
            MemoryStream rb = new MemoryStream(nfbytes);

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
        }*/
    }
}
