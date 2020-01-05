using System;
using System.Collections.Generic;

namespace IQMVCProject.Model
{
    public partial class Products
    {
        public Products()
        {
            Inquiries = new HashSet<Inquiries>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }

        public Categories Category { get; set; }
        public ICollection<Inquiries> Inquiries { get; set; }
    }
}
