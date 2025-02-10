using BedeLotteryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BedeLotteryConsoleApp.UnitTests
{
    public class TicketPurchaseUnitTests
    {
        [Fact]
        public void PlayerOneTicketPurchase_ShouldAddTickets_AndReduceBalance()
        {
            // Arrange
            var playerOne = new Player
            {
                Balance = 5.00m, // Enough balance for 5 tickets
                AmountOfTickets = new List<int>()
            };
            int ticketsRequested = 5;

            var game = new TicketPurchases();

            // Act
            var result = game.PlayerOneTicketPurchase(playerOne, ticketsRequested);

            // Assert
            Assert.Equal(5, result.AmountOfTickets.Count); // Should have 5 tickets
            Assert.Equal(0.00m, result.Balance); // Balance should be 0 after buying 5 tickets
        }

        [Fact]
        public void PlayerOneTicketPurchase_ShouldNotExceedTicketLimit()
        {
            // Arrange
            var playerOne = new Player
            {
                Balance = 20.00m, // More than enough balance
                AmountOfTickets = new List<int> { 1, 2, 3, 4, 5 } // Already has 5 tickets
            };
            int ticketsRequested = 6;

            var game = new TicketPurchases();

            // Act
            var result = game.PlayerOneTicketPurchase(playerOne, ticketsRequested);

            // Assert
            Assert.Equal(10, result.AmountOfTickets.Count); // Max limit of 10 tickets
        }

        [Fact]
        public void PlayerOneTicketPurchase_ShouldStopIfInsufficientBalance()
        {
            // Arrange
            var playerOne = new Player
            {
                Balance = 2.00m, // Only enough for 2 tickets
                AmountOfTickets = new List<int>()
            };
            int ticketsRequested = 5;

            var game = new TicketPurchases();

            // Act
            var result = game.PlayerOneTicketPurchase(playerOne, ticketsRequested);

            // Assert
            Assert.Equal(2, result.AmountOfTickets.Count); // Should stop at 2 tickets
            Assert.Equal(0.00m, result.Balance); // Balance should be 0 after purchase
        }

        [Fact]
        public void CPUTicketPurchase_ShouldIncreaseTickets_AndDecreaseBalance()
        {
            // Arrange
            var player1 = new Player
            {
                PlayerNumber = 1,
                Balance = 10.00m,
                AmountOfTickets = new List<int>() // Player 1
            };

            var cpuPlayers = new List<Player>
        {
            new Player { PlayerNumber = 2, Balance = 10.00m, AmountOfTickets = new List<int>() }, // CPU 1
            new Player { PlayerNumber = 3, Balance = 10.00m, AmountOfTickets = new List<int>() }  // CPU 2
        };

            var playerList = new List<Player> { player1 }.Concat(cpuPlayers).ToList();
            var game = new TicketPurchases();

            // Act
            var result = game.CPUTicketPurchase(playerList);

            // Assert
            Assert.Equal(0, result[0].AmountOfTickets.Count); // Player 1 should NOT be affected

            foreach (var cpu in result.Skip(1)) // Check CPU players
            {
                Assert.InRange(cpu.AmountOfTickets.Count, 1, 11); // Each CPU should have 1-11 tickets
                Assert.InRange(cpu.Balance, -1.00m, 10.00m); // Balance should be deducted
            }
        }
    }
}
