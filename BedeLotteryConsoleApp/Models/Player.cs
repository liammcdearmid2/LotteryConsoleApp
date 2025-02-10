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
        //private List<Player> playerList = new List<Player>(); //cld pass this to methods?
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
        //public List<Player> PlayerList
        //{
        //    get { return playerList; }
        //    set { playerList = value; }
        //}
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
        //public Ticket Tickets
        //{
        //    get { return tickets; }
        //    set { tickets = value; }
        //}
        public string Prize
        {
            get { return prize; }
            set { prize = value; }
        }
        //public enum GameResult
        //{
        //    0       --could add this back in will see.
        //    GrandPrize,
        //    SecondTier,
        //    ThirdTier
        //}
    }
}
