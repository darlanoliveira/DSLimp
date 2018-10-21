using DSLimp.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSLimp.Models
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
    }
}
