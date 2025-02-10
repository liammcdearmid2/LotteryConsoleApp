using BedeLotteryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BedeLotteryConsoleApp
{
    internal class TicketPurchases
    {
        public Player PlayerOneTicketPurchase(Player playerOne, int ticketsRequested)
        {
            //The user (Player 1) will be prompted via the console to purchase their
            //desired number of tickets. The remaining participants are computer-generated
            //players (CPU), labelled sequentially as Player 2, Player 3, etc.
            //Their ticket purchases are determined randomly by the system. 

            for (int i = 1; i <= ticketsRequested; i++)
            {
                if (ticketsRequested < 10)
                {
                    if (playerOne.AmountOfTickets == null || playerOne.AmountOfTickets.Count < 10)
                    {

                        if (playerOne.Balance > 0.99m)
                        {
                            playerOne.AmountOfTickets?.Add(i); //add one ticket
                            playerOne.Balance--; //remove 1 from balance
                        }
                        else { break; }
                    }
                }
            }
            return playerOne;
        }

        public List<Player> CPUTicketPurchase(List<Player> playerList)
        {
            //The user (Player 1) will be prompted via the console to purchase their
            //desired number of tickets. The remaining participants are computer-generated
            //players (CPU), labelled sequentially as Player 2, Player 3, etc.
            //Their ticket purchases are determined randomly by the system. 

            Random rnd = new Random();
            foreach (var cpuPlayer in playerList.Skip(1))
            {
                var randomiseCPUTicketPurchase = rnd.Next(1, 10);

                for (int i = 0; i < randomiseCPUTicketPurchase; i++)
                {
                    if (cpuPlayer.Balance > 0.99m & cpuPlayer.AmountOfTickets.Count < 11)
                    {
                        cpuPlayer.AmountOfTickets.Add(1);
                        cpuPlayer.Balance--;
                    }
                }
            }
            return playerList;
        }       
    }
}
