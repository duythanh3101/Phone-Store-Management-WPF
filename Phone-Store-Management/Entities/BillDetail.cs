using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Entities
{
    public partial class BillDetail
    {
        public BillDetail()
        {

        }
        [Key, Column(Order = 1), ForeignKey("Bill")]
        public int BillId { get; set; }
        [Key, Column(Order = 2), ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
