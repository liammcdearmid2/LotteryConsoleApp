using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BedeLotteryConsoleApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BedeLotteryConsoleApp
{
    internal class GeneratePlayers
    {
        List<Player> playerList = new List<Player>(); 

        public List<Player> AddPlayers()
        {
            //Add a loop to add a random amount of players between 11 and 14
            //Set all their balances to 10
            Random rnd = new Random();
            var amountOfPlayers = rnd.Next(11, 14);

            for (int i = 1; i <= amountOfPlayers; i++)
            {
                playerList.Add(new Player { PlayerNumber = i, Balance = 10});
            }
            return playerList;
        }

        public int AmountOfPlayers()
        {
            Random rnd = new Random();
            int players = rnd.Next(9, 16); 

            return players;
        }
    }
}
