using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DSLimp.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cli { get; internal set; }
        public string Cli_Nome { get; internal set; }
        public string Cli_Contato { get; internal set; }
        public string Cli_Bairro { get; internal set; }
        public string Cli_Cidade { get; internal set; }
        public string Cli_Telefone { get; internal set; }
        public string Cli_Cnpj { get; internal set; }
        public string Cli_End { get; internal set; }
        public string Cli_Ref { get; internal set; }
    }
}

