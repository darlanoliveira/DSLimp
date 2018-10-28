using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSLimp.Models
{
    public class Gasto
    {
        [Key]
        public int Gas_id { get; internal set; }
        public string Gas_desc { get; internal set; }
        public IFormfile Gas_ftnf { get; internal set; }
        public IFormfile Gas_ftrec { get; internal set; }
        public double Gas_valortotal { get; internal set; }
    }
}
