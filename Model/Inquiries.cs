using System;
using System.Collections.Generic;

namespace IQMVCProject.Model
{
    public partial class Inquiries
    {
        public int InquiryId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CustomerNotes { get; set; }
        public byte[] Attchments { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? ProductId { get; set; }

        public Products Product { get; set; }
    }
}
