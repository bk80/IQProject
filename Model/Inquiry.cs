using System;
using System.Collections.Generic;

namespace IQMVCProject.Model
{
    public partial class Inquiry
    {
        public short Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public DateTime? Date { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerNotes { get; set; }
        public string InterstedProduct { get; set; }
        public string AdditionalAttachment { get; set; }
        public DateTime NextFollowUp { get; set; }
    }
}
