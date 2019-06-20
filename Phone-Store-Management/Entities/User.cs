using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Entities

{
    public partial class User
    {
        public User()
        {
            this.Bills = new HashSet<Bill>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required, MinLength(5), MaxLength(20), Index(IsUnique = true)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string IdentityID { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual Role Role { get; set; }
    }
}
