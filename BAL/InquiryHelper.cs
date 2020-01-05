using IQMVCProject.DAL;
using IQMVCProject.Model;

using System.Collections.Generic;

namespace IQMVCProject.BAL
{
    public class InquiryHelper
    {
        public List<Inquiries> getInquiries(string searchString) => new InquiryDataHandler().getInquiries(searchString);
        public List<Inquiries> getInquiries(int numb) => new InquiryDataHandler().getInquiries(numb);
        public void addUpdateInquiry(Inquiries inquiry) => new InquiryDataHandler().addUpdateInquiry(inquiry);
    }
}