using BedeLotteryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BedeLotteryConsoleApp.UnitTests
{
    public class GeneratePlayersUnitTests
    {

        [Fact]
        public void AddPlayers_ShouldAddBetween11And14Players_WithBalance10()
        {
            // Arrange
            GeneratePlayers generatePlayers = new GeneratePlayers();

            // Act
            var result = generatePlayers.AddPlayers();

            // Assert
            Assert.InRange(result.Count, 11, 14); // Check if the number of players is between 11 and 14
            foreach (var player in result)
            {
                Assert.Equal(10, player.Balance); // Check if each player's balance is set to 10
            }
        }

        [Fact]
        public void AmountOfPlayers_ShouldReturnValueBetween9And15()
        {
            // Arrange
            GeneratePlayers generatePlayers = new GeneratePlayers();

            // Act
            int result = generatePlayers.AmountOfPlayers();

            // Assert
            Assert.InRange(result, 9, 15); // Check if the number of players is between 9 and 15
        }
    }
}
