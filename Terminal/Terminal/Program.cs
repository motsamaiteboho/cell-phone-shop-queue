/*
 * Student Names: Motsamai Teboho
 * Student Number: 2016206381
 * */using System;
using System.Collections.Generic;
using System.Linq;
using libQueues;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Terminal
{
    class Program
    {
        static DynamicQueue<Ticket> qContracts = new DynamicQueue<Ticket>("Contract");
        static DynamicQueue<Ticket> qRepairs = new DynamicQueue<Ticket>("Repair");
        static DynamicQueue<Ticket> qOthers = new DynamicQueue<Ticket>("Other");
        static void Main()
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tCOUNTER TERMINAL");
            Console.WriteLine("\t==================");
            Console.WriteLine();
            Console.Write("\tNext Constomer, what queue do you serve ('C' / 'R' / 'O')?  ");
            char option = Console.ReadKey().KeyChar.ToString().ToUpper()[0];
            Console.WriteLine("\n");
            switch (option) //classroom examples
            {
                case 'C':
                    qContracts.Read();
                    Console.WriteLine("\tCategory: C");
                    Console.WriteLine("\tTicket Number: " + qContracts.Dequeue().TicketNumber);
                    Console.WriteLine("\tTimestamp: " + qContracts.Dequeue().Timestamp);
                    qContracts.Save();
                    break;
                case 'R':
                    qRepairs.Read();
                    Console.WriteLine("\tCategory: R");
                    Console.WriteLine("\tTicket Number: " + qRepairs.Dequeue().TicketNumber);
                    Console.WriteLine("\tTimestamp: " + qRepairs.Dequeue().Timestamp);
                    qRepairs.Save();
                    break;
                case 'O':
                    qOthers.Read();
                    Console.WriteLine("\tCategory: O");
                    Console.WriteLine("\tTicket Number: " + qOthers.Dequeue().TicketNumber);
                    Console.WriteLine("\tTimestamp: " + qOthers.Dequeue().Timestamp);
                    qOthers.Save();
                    break;
                default: break;
            }

            Console.Write("\t\n\nPress anykey for next xustomer or 'X' to go home....");
            if (Console.ReadKey().KeyChar.ToString().ToUpper()[0] == 'X')
                Main();
            else
            {
                Thread.Sleep(3000);
                Main();
            }
        }
    }
}
