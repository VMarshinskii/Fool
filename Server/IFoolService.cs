using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    [ServiceContract]
    public interface IFoolService
    {
        [OperationContract]
        User Registration(string name);

        [OperationContract]
        Dictionary<int, int> GetCardsOnTable();

        [OperationContract]
        List<User> GetAllUsersOnTable();
    }
}
