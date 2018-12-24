using System.ComponentModel.DataAnnotations;

namespace DSLimp.Models
{
    public class Produto
    {
        [Key]
        public int Id_Pro { get; internal set; }
        public string Prod_Desc { get; internal set; }
        public double Prod_Val_Cus { get; internal set; }
        public double Prod_Val_Ven { get; internal set; }
        public string Prod_Tipo { get; internal set; }
        public int Prod_Qtd { get; internal set; }
        public byte[] Prod_Ft { get; internal set; }
        public string Prod_Cod { get; internal set; }


    }
}
