using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Entities
{
    public partial class Bill
    {
        public Bill()
        {
            this.BillDetails = new HashSet<BillDetail>();
        }
        [Key]
        public int Id { get; set; }
        public System.DateTime BillDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
