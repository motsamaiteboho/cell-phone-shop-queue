/*
 * Student Names: Motsamai Teboho
 * Student Number: 2016206381
 * */using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libQueues
{
    [Serializable]
    public class Ticket
    {
        public int TicketNumber { get; set; }
        public DateTime Timestamp { get; set; }
        public bool isPensioner { get; set; }
        public Ticket(int TicketNumber,DateTime Timestamp, bool isPensioner)
        {
            this.TicketNumber = TicketNumber;
            this.Timestamp = Timestamp;
            this.isPensioner = isPensioner;
        }
    } //class Ticket
}
