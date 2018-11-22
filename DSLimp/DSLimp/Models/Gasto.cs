using System;
using System.ComponentModel.DataAnnotations;

namespace DSLimp.Models
{
    public class Gasto
    {
        [Key]
        public int Gas_id { get; internal set; }
        public string Gas_desc { get; internal set; }
        public byte[] Gas_ftnf { get; internal set; }
        public byte[] Gas_ftrec { get; internal set; }
        public double Gas_valortotal { get; internal set; }
        public DateTime Gas_data { get; internal set; }
    }
}
