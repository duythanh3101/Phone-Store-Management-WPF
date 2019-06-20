using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        public Product()
        {
            this.BillDetails = new HashSet<BillDetail>();
            this.Warranties = new HashSet<Warranty>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Brand { get; set; }
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string ImageURL { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Warranty> Warranties { get; set; }
    }
}
