using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Entities
{
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            this.Warranties = new HashSet<Warranty>();
        }
        [Key]
        public string PhoneNumber { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public virtual ICollection<Warranty> Warranties { get; set; }
    }
}
