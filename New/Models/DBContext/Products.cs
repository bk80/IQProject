using System;
using System.Collections.Generic;

namespace IQMVCProject.Models.DBContext
{
    public partial class Products
    {
        public Products()
        {
            Inquiries = new HashSet<Inquiries>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Features { get; set; }
        public string ProductDescription { get; set; }
        public int? Price { get; set; }
        public int? Qty { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Inquiries> Inquiries { get; set; }
    }
}
