using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BedeLotteryConsoleApp.Models.Player;

namespace BedeLotteryConsoleApp.Models
{
    internal class Ticket
    {
        private int amountOfTickets;
        private double prize;

        public int AmountOfTickets
        {
            get { return amountOfTickets; }
            set { amountOfTickets = value; }
        }
        public double Prize
        {
            get { return prize; }
            set { prize = value; }
        }
    }
}
