using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    public class FoolService : IFoolService
    {
        public User Registration(string name)
        {
            User user = new User(name);
            user.status = 0;

            TableStatic.users.Add(user);

            return user;
        }

        public Dictionary<int, int> GetCardsOnTable()
        {
            return TableStatic.CartOnTable;
        }

        public List<User> GetAllUsersOnTable()
        {
            return TableStatic.users;
        }
    }
}
