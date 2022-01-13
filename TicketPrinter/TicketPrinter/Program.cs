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

namespace TicketPrinter
{
    class Program
    {
        static DynamicQueue<Ticket> qContracts = new DynamicQueue<Ticket>("Contract");
        static DynamicQueue<Ticket> qRepairs = new DynamicQueue<Ticket>("Repair");
        static DynamicQueue<Ticket> qOthers = new DynamicQueue<Ticket>("Other");
        static void Main()
        {
            Menu();
        }
        private static void Menu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tTICKET PRINTER");
            Console.WriteLine("\t==================");
            Console.WriteLine();
            Console.WriteLine("\tWhat is the nature of your query? ");
            Console.WriteLine();
            Console.WriteLine("\tC. Contracts");
            Console.WriteLine("\tR. Repairs");
            Console.WriteLine("\tO. Other");
            Console.WriteLine();
            Console.Write("\tEnter option: ");
            char option = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

            switch (option) //classroom examples
            {
                case 'C': Contracts();  Main(); break;
                case 'R': Repairs();  Main(); break;
                case 'O': Others();  Main(); break;
                default:; break;
            }
        }
        static int CTicketNumber = 0;
        static int RTicketNumber = 0;
        static int OTicketNumber = 0;
        public static void Contracts()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tAre you over 60? ");
            Console.WriteLine("\tY. Yes");
            Console.WriteLine("\tN. No");
            Console.Write("\tEnter option: ");
            char option = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

            Ticket ticket;
            switch (option) //classroom examples
            {
                
                case 'Y':
                    Console.WriteLine();
                    CTicketNumber += 1;
                    Console.Write("\tID number please: ");
                    string iID = Console.ReadLine();
                    if (int.Parse(iID.Substring(0, 2)) > 55)
                    {
                        ticket = new Ticket(CTicketNumber, DateTime.Now, false);
                        qContracts.Enqueue(ticket, 1);
                    }
                    else
                    {
                        ticket = new Ticket(CTicketNumber, DateTime.Now, true);
                        qContracts.Enqueue(ticket, 0);
                    }
                    qContracts.Save();
                    Console.WriteLine("\n");
                    Console.WriteLine("\tYour ticket number: " + CTicketNumber);
                    break; 

                case 'N':
                    CTicketNumber += 1;
                    ticket = new Ticket(CTicketNumber, DateTime.Now, false);
                    qContracts.Enqueue(ticket, 1);
                    qContracts.Save();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("\tYour ticket number: " + CTicketNumber);
                    break;
            }
            Thread.Sleep(3000);
        }
        public static void Repairs()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tAre you over 60? ");
            Console.WriteLine("\tY. Yes");
            Console.WriteLine("\tN. No");
            Console.Write("\tEnter option: ");
            char option = Console.ReadKey().KeyChar.ToString().ToUpper()[0];
            Ticket ticket;
            switch (option) //classroom examples
            {
                case 'Y':
                    Console.WriteLine();
                    RTicketNumber += 1;
                    ticket = new Ticket(RTicketNumber, DateTime.Now, true);
                    Console.Write("\tID number please: ");
                    string iID = Console.ReadLine();
                    if (int.Parse(iID.Substring(0, 2)) > 55)
                    {
                        ticket = new Ticket(RTicketNumber, DateTime.Now, false);
                        qRepairs.Enqueue(ticket, 1);
                    }
                    else
                    {
                        ticket = new Ticket(RTicketNumber, DateTime.Now, true);
                        qRepairs.Enqueue(ticket, 0);
                    }
                    qRepairs.Save();
                    Console.WriteLine("\n");
                    Console.WriteLine("\tYour ticket number: " + RTicketNumber);
                    break;

                case 'N':
                    RTicketNumber += 1;
                    ticket = new Ticket(RTicketNumber, DateTime.Now, false);
                    qRepairs.Enqueue(ticket, 1);
                    qRepairs.Save();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("\tYour ticket number: " + RTicketNumber);
                    break;
            }
            Thread.Sleep(3000);
        }
        public static void Others()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tAre you over 60? ");
            Console.WriteLine("\tY. Yes");
            Console.WriteLine("\tN. No");
            Console.Write("\tEnter option: ");
            char option = Console.ReadKey().KeyChar.ToString().ToUpper()[0];
            Ticket ticket;
            switch (option) //classroom examples
            {
                case 'Y':
                    Console.WriteLine();
                    OTicketNumber += 1;
                    Console.Write("\tID number please: ");
                    string iID = Console.ReadLine();
                    if (int.Parse(iID.Substring(0, 2)) > 55)
                    {
                        ticket = new Ticket(OTicketNumber, DateTime.Now, false);
                        qOthers.Enqueue(ticket, 1);
                    }
                    else
                    {
                        ticket = new Ticket(OTicketNumber, DateTime.Now, true);
                        qOthers.Enqueue(ticket, 0);
                    }
                    qOthers.Save();
                    Console.WriteLine("\n");
                    Console.WriteLine("\tYour ticket number: " + OTicketNumber);
                    break;

                case 'N':
                    OTicketNumber += 1;
                    ticket = new Ticket(OTicketNumber, DateTime.Now, false);
                    qOthers.Enqueue(ticket, 1);
                    qOthers.Save();
                    Console.WriteLine("\n\n");
                    Console.WriteLine("\tYour ticket number: " + OTicketNumber);
                    break;
            }
            Thread.Sleep(3000);
        }
    }
}
