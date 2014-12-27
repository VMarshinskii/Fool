using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHos = new ServiceHost(typeof(FoolService));
            serviceHos.Open();
            Console.WriteLine("Service is running...");

            foreach (System.Net.IPAddress ip in System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList) 
            {
                Console.WriteLine("IP: {0}", ip.ToString());
            }
            
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
            serviceHos.Close();
            Console.WriteLine("Service was stopped");
        }
    }
}
