using BedeLotteryConsoleApp;
using BedeLotteryConsoleApp.Models;

Player player = new Player();
LotteryGame prizes = new LotteryGame();
GeneratePlayers lottery = new GeneratePlayers();

//Initialise the players
var playerList = lottery.AddPlayers();

//Assign playerOne
var playerOne = playerList.First();

Console.WriteLine($"{Environment.NewLine}Welcome to the Bede Lottery Player {playerOne.PlayerNumber}!");

Console.WriteLine($"{Environment.NewLine}Your digital balance: ${playerOne.Balance}");
Console.WriteLine($"{Environment.NewLine}Ticket Price: $1.00 each");

Console.WriteLine($"{Environment.NewLine}How many tickets do you want to buy, Player {playerOne.PlayerNumber}?");
int ticketsRequested = Convert.ToInt32(Console.ReadLine());
TicketPurchases ticketPurchases = new TicketPurchases();
ticketPurchases.PlayerOneTicketPurchase(playerOne, ticketsRequested);

//amount of players:
var amountOfPlayers = playerList.Skip(1).Count(); //Skip player one
Console.WriteLine($"{Environment.NewLine}{amountOfPlayers} other CPU players have also purchased tickets"); 

//CPU ticket purchase
ticketPurchases.CPUTicketPurchase(playerList);

//A list of all players and the number of tickets each purchased printed to console:
foreach (var participant in playerList)
{
    Console.WriteLine($"Player {participant.PlayerNumber} purchased {participant.AmountOfTickets.Count}");
}

//Game:
Console.WriteLine($"{Environment.NewLine}Ticket draw results:");

prizes.GrandPrize(playerList);
prizes.SecondTierPrize(playerList);
prizes.ThirdTierPrize(playerList);

Console.WriteLine($"{Environment.NewLine}Congratulations to the winners!");
