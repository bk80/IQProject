using System;
using System.Collections.Generic;

namespace IQMVCProject.Models.DBContext
{
    public partial class Users
    {
        public Users()
        {
            Products = new HashSet<Products>();
        }

        public int UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
