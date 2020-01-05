using IQMVCProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMVCProject.DAL
{
    public class LoginDataHelper
    {

        private InquiryDBContext db = new InquiryDBContext();

        public Logins isValidUser(string userID, string password)
        {
            using (db)
            {
                var validUser = db.Logins.Where(x => x.UserId == userID
                && x.Password == password
                && x.IsActive == 1)
                .FirstOrDefault();
                return validUser;

            }
        }






    }
}