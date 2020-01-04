using System;
using System.Collections.Generic;

namespace IQMVCProject.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerNotes { get; set; }
    }
}
