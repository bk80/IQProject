using System;
using System.Collections.Generic;

namespace IQMVCProject.Model
{
    public partial class Features
    {
        public Features()
        {
            Categories = new HashSet<Categories>();
        }

        public int FeatureId { get; set; }
        public string FeatureName { get; set; }

        public ICollection<Categories> Categories { get; set; }
    }
}
