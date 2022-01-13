using System;
using System.Collections.Generic;
using System.Linq;
using libQueues;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TVScreen
{
    class Program
    {
        static DynamicQueue<Ticket> qContracts = new DynamicQueue<Ticket>("Contract");
        static DynamicQueue<Ticket> qRepairs = new DynamicQueue<Ticket>("Repair");
        static DynamicQueue<Ticket> qOthers = new DynamicQueue<Ticket>("Other");
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("\tTICKET PRIORUTY");
            Console.WriteLine("\t======= =========");
            Console.WriteLine("\n");
            //Queue for Contracts
            Console.WriteLine("\tContracts: " + qContracts.Count);
            int iC = 0;
            qContracts.Read();
            foreach (Ticket item in qContracts)
            {
                Console.WriteLine("\t" + item.TicketNumber.ToString().PadRight(15) + 
                    item.isPensioner.ToString().PadLeft(15));
                iC++;
                if (iC == 5)
                    break;
            }

            //Queue for Repairs
            Console.WriteLine("\n");
            Console.WriteLine("\tRepairs: " + qRepairs.Count);
            int iR = 0;
            qRepairs.Read();
            foreach(Ticket item in qRepairs)
            {
                Console.WriteLine("\t" + item.TicketNumber.ToString().PadRight(15) +
                    item.isPensioner.ToString().PadLeft(15));
                iR++;
                if (iR == 5)
                    break;
            }

            //Queue for Others
            Console.WriteLine("\n");
            Console.WriteLine("\tContracts: " + qOthers.Count);
            int iO = 0;
            qOthers.Read();
            foreach (Ticket item in qOthers)
            {
                Console.WriteLine("\t" + item.TicketNumber.ToString().PadRight(15) +
                    item.isPensioner.ToString().PadLeft(15));
                iO++;
                if (iO == 5)
                    break;
            }
            Thread.Sleep(3000);
            Main();
        }
    }
}
