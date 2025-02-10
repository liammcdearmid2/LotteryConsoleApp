using BedeLotteryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Xunit;

namespace BedeLotteryConsoleApp.UnitTests
{
    public class LotteryGameUnitTests
    {
        [Fact]
        public void GrandPrize_ShouldReturnWinnerId()
        {
            // Arrange
            var tickets = new List<int>();
            var fixture = new Fixture();

            // Generate a list of players with a list of tickets
            List<int> amountOfTickets = new List<int> { 3, 5, 8 };

            var playerList = new List<Player>
        {
            new Player { PlayerNumber = 1, AmountOfTickets = amountOfTickets },
            new Player { PlayerNumber = 2, AmountOfTickets = amountOfTickets },
            new Player { PlayerNumber = 3, AmountOfTickets = amountOfTickets }
        };

            var game = new LotteryGame();
            var expectedWinner = playerList.First().PlayerNumber; 

            // Act
            int winnerId = game.GrandPrize(playerList);

            // Assert
            Assert.Contains(winnerId, playerList.Select(p => p.PlayerNumber));
        }
        [Fact]
        public void SecondTierPrize_ShouldReturnWinnersList()
        {
            // Arrange
            List<int> amountOfTickets = new List<int> { 3, 5, 8 };
            List<int> expected = new List<int> { 3, 5, 8 };
            var playerList = new List<Player>
        {
            new Player { PlayerNumber = 1, AmountOfTickets = amountOfTickets },
            new Player { PlayerNumber = 2, AmountOfTickets = amountOfTickets },
            new Player { PlayerNumber = 3, AmountOfTickets = amountOfTickets }
        };

            foreach (var winner in playerList)
            {
                expected.Add(winner.PlayerNumber);
            }

            // Act
            var game = new LotteryGame();
            var actual = game.SecondTierPrize(playerList);

            // Assert
            Assert.All(actual, item => Assert.Contains(item, expected));
            //Check that both actual and expected lists contains values
        }

        [Fact]
        public void ThirdTierPrize_ShouldReturnWinnersList()
        {
            // Arrange
            List<int> amountOfTickets = new List<int> { 3, 5, 8 };
            List<int> expected = new List<int> { 3, 5, 8 };
            var playerList = new List<Player>
        {
            new Player { PlayerNumber = 1, AmountOfTickets = amountOfTickets },
            new Player { PlayerNumber = 2, AmountOfTickets = amountOfTickets },
            new Player { PlayerNumber = 3, AmountOfTickets = amountOfTickets }
        };

            foreach (var winner in playerList)
            {
                expected.Add(winner.PlayerNumber);
            }

            // Act
            var game = new LotteryGame();
            var actual = game.ThirdTierPrize(playerList);

            // Assert
            Assert.All(actual, item => Assert.Contains(item, expected));
            //Check that both actual and expected lists contains values
            //Can't compare actual values as the method randomly generates winners each time
        }
    }
}
