using System;
using System.Collections.Generic;

namespace IQMVCProject.Models.DBContext
{
    public partial class Inquiries
    {
        public int InquiryId { get; set; }
        public string CustomerNotes { get; set; }
        public byte[] Attchments { get; set; }
        public DateTime? NextfllowupDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
