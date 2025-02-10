using BedeLotteryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BedeLotteryConsoleApp
{
    internal class LotteryGame
    {
        HouseProfit houseProfit = new HouseProfit();

        public int GrandPrize(List<Player> playerList)
        {
            //Get the amount of tickets
            int totalTickets = AmountOfTickets(playerList);

            //50 % of revenue
            decimal fiftyPercent = 50m;
            var grandPrize = SplitRevenue((decimal)totalTickets, fiftyPercent);

            string tierNo = "Grand Prize";
            var winnersList = GenerateWinners(playerList, 1, tierNo, grandPrize);

            AddToHouseProfit(1, grandPrize, houseProfit);

            Console.WriteLine($"Grand Prize: Player {winnersList.First()} wins ${grandPrize}!");

            return winnersList.First();
        }

        public List<int> SecondTierPrize(List<Player> playerList)
        {
            int totalTickets = AmountOfTickets(playerList);

            //Second Tier: 10% of the total number of tickets (rounded)
            decimal tenPercent = 10m;
            int amountOfTicketWinners = PercentOfWinners((decimal)totalTickets, tenPercent);

            //Will share 30% of revenue
            decimal thirtyPercent = 30m;
            decimal secondTierPrize = SplitRevenue((decimal)totalTickets, thirtyPercent);

            string tierNo = "Tier 2";
            var winnersList = GenerateWinners(playerList, amountOfTicketWinners, tierNo, secondTierPrize);

            AddToHouseProfit(amountOfTicketWinners, secondTierPrize, houseProfit);

            foreach (var playerNo in winnersList)
            {
                Console.WriteLine($"Second Tier: Player {playerNo} win ${secondTierPrize} each!");
            }

            return winnersList;
        }

        public List<int> ThirdTierPrize(List<Player> playerList)
        {
            int amountOfTickets = AmountOfTickets(playerList);

            //Third Tier: 20% of the total number of tickets (rounded)
            var twentyPercent = 20m;
            int amountOfTicketWinners = PercentOfWinners((decimal)amountOfTickets, twentyPercent);

            //Will share 10% of revenue
            var tenPercent = 10m;
            decimal thirdTierPrize = SplitRevenue((decimal)amountOfTickets, tenPercent);

            string tierNo = "Tier 3";
            var winnersList = GenerateWinners(playerList, amountOfTicketWinners, tierNo, thirdTierPrize);

            decimal houseProfitBalance = AddToHouseProfit(amountOfTicketWinners, thirdTierPrize, houseProfit);
            
            foreach (var playerNo in winnersList)
            {
                Console.WriteLine($"Third Tier: Player {playerNo} win ${thirdTierPrize} each!");
            }

            Console.WriteLine($"{Environment.NewLine}House revenue: ${houseProfitBalance}");

            return winnersList;
        }

        private static List<int> GenerateWinners(List<Player> playerList, int amountOfTicketWinners, string tierNumber, decimal tierPrize)
        {
            var winnersList = new List<int>();

            switch (tierNumber)
            {
                case "Grand Prize":
                    winnersList = AwardPrize(tierNumber, tierPrize, playerList, amountOfTicketWinners, winnersList);
                    break;
                case "Tier 2":
                    winnersList = AwardPrize(tierNumber, tierPrize, playerList, amountOfTicketWinners, winnersList);
                    break;
                case "Tier 3":
                    winnersList = AwardPrize(tierNumber, tierPrize, playerList, amountOfTicketWinners, winnersList);
                    break;
            }
            return winnersList;
        }

        private static List<int> AwardPrize(string tierNumber, decimal tierPrize, List<Player> playerList, int amountOfTicketWinners, List<int> winnersList)
        {
            Random rnd = new Random();

            //To generate a random number inbetween the number of the list of players
            var firstPlayerNo = playerList.Select(x => x.PlayerNumber).FirstOrDefault();
            var lastPlayerNo = playerList.Select(x => x.PlayerNumber).Last();

            for (int i = 0; i < amountOfTicketWinners; i++)
            {
                var randomNumber = rnd.Next(firstPlayerNo, lastPlayerNo);
                foreach (var player in playerList)
                {
                    //If the player no matches the random number generated, and they dont have a prize
                    //award them a prize
                    if (player.PlayerNumber == randomNumber && string.IsNullOrWhiteSpace(player.Prize))
                    {
                        player.Prize = tierNumber;
                        player.Balance += tierPrize;
                        winnersList.Add(player.PlayerNumber);
                        break;
                    }
                }
            }
            return winnersList;
        }

        private static int PercentOfWinners(decimal amountOfTickets, decimal percent)
        {
            //Calculate the percent of winners
            //10% for second tier, 20% for 3rd tier, etc
            decimal ticketWinners = amountOfTickets / 100 * percent;
            int amountOfTicketWinners = (int)Math.Round(ticketWinners);

            return amountOfTicketWinners;
        }

        private static int AmountOfTickets(List<Player> playerList)
        {
            List<int> amountOfTickets = new List<int>();

            foreach (var item in playerList)
            {
                amountOfTickets.Add(item.AmountOfTickets.Count());
            }
            return amountOfTickets.Sum();
        }

        private static decimal SplitRevenue(decimal totalTickets, decimal percentage)
        {
            //Split the revenue
            //Grand Prize = 50% of revenue
            //2nd Tier = share 30% of revenue
            //3rd Tier = share 10% of revenue
            return totalTickets / 100 * percentage;
        }

        private static decimal AddToHouseProfit(decimal ticketWinners, decimal tierPrize, HouseProfit houseProfit)
        {
            //If the amount for a prize tier is not exactly divisible
            //by the number of winners of that tier, the closest equal split should be
            //calculated, and any remaining amount should be added to the house profit

            if (tierPrize % ticketWinners != 0)
            {
                decimal remainder = tierPrize % ticketWinners;
                houseProfit.Balance += remainder;
            }
            return houseProfit.Balance;
        }
    }
}
