using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedeLotteryConsoleApp.Models
{
    internal class Player
    {
        private int playerNumber;
        private decimal houseProfit;
        private decimal balance;
        private string? prize;
        private List<int> amountOfTickets = new List<int>();

        public int PlayerNumber
        {
            get { return playerNumber; }
            set { playerNumber = value; }
        }
        public decimal HouseProfit
        {
            get { return houseProfit; }
            set { houseProfit = value; }
        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public List<int> AmountOfTickets
        {
            get { return amountOfTickets; }
            set { amountOfTickets = value; }
        }
        public string Prize
        {
            get { return prize; }
            set { prize = value; }
        }
    }
}
