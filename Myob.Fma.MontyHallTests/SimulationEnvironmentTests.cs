using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.MontyHall;
using Xunit;

namespace Myob.Fma.MontyHallTests
{
    public class SimulationEnvironmentTests
    {
        [Fact]
        public void Should_Initialize_Empty_Doors_With_No_Prizes_Even_With_Some_Doors_With_Prizes()
        {
            // Arrange
            var doors = new List<IDoor>
            {
                new Door() {ContainsPrize = true},
                new Door() {ContainsPrize = true},
                new Door() {ContainsPrize = true},
                new Door() {ContainsPrize = true},
                new Door() {ContainsPrize = true}
            };
            
            var gameshow = new SimulationEnvironment(doors);
            
            // Act
            gameshow.RemovePrizesFromAllDoors();
            
            var result = gameshow.Doors.All(d => d.ContainsPrize == false);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Should_Place_A_Prize_Behind_A_Door()
        {
            // Arrange
            var doors = new List<IDoor>
            {
                new Door() {ContainsPrize = false},
                new Door() {ContainsPrize = false},
                new Door() {ContainsPrize = false}
            };
            
            var gameshow = new SimulationEnvironment(doors);

            //Act
            gameshow.PlacePrizeBehindRandomDoor();
            var result = gameshow.Doors.Count(d => d.ContainsPrize);

            //Assert
            Assert.Equal(1, result);
        }
        
        [Fact]
        public void Should_Simulate_A_User_Selecting_A_Random_Door()
        {
            // Arrange
            var doors = new List<IDoor>
            {
                new Door() {ContainsPrize = false},
                new Door() {ContainsPrize = false},
                new Door() {ContainsPrize = false},
            };
            
            var gameshow = new SimulationEnvironment(doors);

            //Act
            gameshow.ChooseARandomDoorForTheUser();
            var result = gameshow.Doors.Count(d => d.IsUsersSelection);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_Remove_A_Door_From_The_List_That_The_User_Didnt_Select()
        {
            // Arrange
            var doors = new List<IDoor>
            {
                new Door() {ContainsPrize = false, IsUsersSelection = true},
                new Door() {ContainsPrize = true, IsUsersSelection = true},
                new Door() {ContainsPrize = false},
            };
            
            var gameshow = new SimulationEnvironment(doors);

            // Act
            gameshow.EliminateAClosedDoor();
            var numberOfDoors = gameshow.Doors.Count();
            var removedTheNonUserSelectedDoor = gameshow.Doors.All(d => d.IsUsersSelection);
            
            // Assert
            Assert.Equal(2,numberOfDoors);
            Assert.True(removedTheNonUserSelectedDoor);
        }
        
    }
}