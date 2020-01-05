using IQMVCProject.DAL;
using IQMVCProject.Model;

using System.Collections.Generic;

namespace IQMVCProject.BAL
{
    public class LoginHelper
    {
        public Logins isValidUser(string userID, string password) => new LoginDataHelper().isValidUser(userID, password);
    }
}