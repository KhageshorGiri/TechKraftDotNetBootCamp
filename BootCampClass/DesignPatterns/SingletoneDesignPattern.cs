using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // let us consider we have a hote
    // consider waiter as a table servers

    public class TableServers
    {
        private static TableServers? _instance;
        private List<string> servers = new List<string>();
        int nextServer = 0;
        private TableServers() 
        {
            servers.Add("Ram");
            servers.Add("Shiva");
            servers.Add("Hari");
            servers.Add("Krishna");
        }

        public static TableServers GetTableServers()
        {
            if(_instance == null)
            {
                _instance =  new TableServers();
            }
            return _instance;
        }

        public string GetNextServer()
        {
            string outPut = servers[nextServer];
            nextServer++;

            if (nextServer >= servers.Count)
            {
                nextServer = 0;
            }
            return outPut;
        }
    }

    public class Customer
    {
        private static TableServers servers1 = TableServers.GetTableServers();
        private static TableServers servers2 = TableServers.GetTableServers();
        /*public static void Main(string[] args)
        {
           // TableServers servers = new TableServers();

            for(int i = 0; i<= 5; i++)
            {
                FirstCustomer();
                SecondCustomer();
                //Console.WriteLine("The server is: " + servers.GetNextServer());
            }

            Console.ReadLine();
        }*/

        private static void FirstCustomer()
        {
            Console.WriteLine("The server1 is: " + servers1.GetNextServer());
        }

        private static void SecondCustomer()
        {
            Console.WriteLine("The server2 is: " + servers2.GetNextServer());
        }
    }
}
