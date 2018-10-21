using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSLimp.Models
{
    public class Produto
    {
        [Key]
        public int Id_Pro { get; internal set; }
        public string Prod_Desc { get; internal set; }
        public double Prod_Val_Cus { get; internal set; }
        public double Prod_Val_Ven { get; internal set; }
        public string Prod_Tel { get; internal set; }
        public string Prod_Cnpj { get; internal set; }
        public string Prod_Ref { get; internal set; }
        public string Prod_End { get; internal set; }

    }
}
