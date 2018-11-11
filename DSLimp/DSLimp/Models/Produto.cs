﻿using System.ComponentModel.DataAnnotations;

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
