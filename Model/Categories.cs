using System;
using System.Collections.Generic;

namespace IQMVCProject.Model
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? FeatureId { get; set; }

        public Features Feature { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
