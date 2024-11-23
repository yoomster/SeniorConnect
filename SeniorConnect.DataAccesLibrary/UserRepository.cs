using CoreDomain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.DataAccesLibrary
{
    public class UserRepository : DataAccess
    {
        public List<User> GetAllUsersFromDB()
        {
            return base.GetAllUsers(); 
        }

        public void SaveUserToDB(User user)
        {
            base.SaveUser(user); 
        }
    }
}
