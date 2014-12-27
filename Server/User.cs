using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [DataContractAttribute]
    public class User
    {
        [DataMemberAttribute]
        public int id;
        [DataMemberAttribute]
        public string name;

        [DataMemberAttribute]
        public int status;
        [DataMemberAttribute]
        public List<int> cards = new List<int>();

        public User(string name)
        {
            this.name = name;
            this.id = TableStatic.users.Count;
        }

    }
}
