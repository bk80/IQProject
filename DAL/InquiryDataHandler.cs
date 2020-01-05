using IQMVCProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMVCProject.DAL
{
    public class InquiryDataHandler
    {

        private InquiryDBContext db = new InquiryDBContext();


        public List<Inquiries> getInquiries(string searchString)
        {

            using (db)
            {
                return (from c in db.Inquiries
                        where c.CustomerName.Contains(searchString)
                        select c)
                .ToList();
            }
        }
        public List<Inquiries> getInquiries(int numb)
        {

            using (db)
            {
                return (from c in db.Inquiries
                        select c)
                        .OrderByDescending(x => x.UpdatedDate)
                        .Take(numb)
                        .ToList();
            }
        }

        public void addUpdateInquiry(Inquiries inquiry)
        {
            using (db)
            {
                var inquiryObj = (from c in db.Inquiries
                                  where c.InquiryId == inquiry.InquiryId
                                  select c);
                // if (inquiryObj != null && inquiryObj.ToList().Any()) //Modified the values into the DB
                // {
                //     db.Entry(inquiry).State = EntityState.Modified;
                //     db.SaveChanges();
                // }
                // else // Add the values into the DB
                {
                    db.Inquiries.Add(inquiry);
                    db.SaveChanges();
                }
            }
        }




    }
}