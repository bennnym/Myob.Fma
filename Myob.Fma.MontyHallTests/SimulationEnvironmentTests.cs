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
                new Door() {Prize = true},
                new Door() {Prize = true},
                new Door() {Prize = true},
                new Door() {Prize = true},
                new Door() {Prize = true}
            };
            
            // Act
            var emptiedDoors = SimulationEnvironment.EmptyDoors(doors);
            
            var result = emptiedDoors.All(d => d.Prize == false);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Should_Place_A_Prize_Behind_A_Door()
        {
            // Arrange
            var doors = new List<IDoor>
            {
                new Door() {Prize = false},
                new Door() {Prize = false},
                new Door() {Prize = false},
                new Door() {Prize = false},
                new Door() {Prize = false}
            };
            
            //Act
            var withPrizePlaced = SimulationEnvironment.PlacePrizeBehindDoor(doors);
            var result = withPrizePlaced.Count(d => d.Prize);

            //Assert
            Assert.Equal(1, result);
        }
        
        [Fact]
        public void Should_Simulate_A_User_Selecting_A_Random_Door()
        {
            // Arrange
            var doors = new List<IDoor>
            {
                new Door() {Prize = false},
                new Door() {Prize = false},
                new Door() {Prize = false},
            };
            
            //Act
            var withUserDoorSelected = SimulationEnvironment.SimulateUserDoorSelection(doors);
            var result = withUserDoorSelected.Count(d => d.UserSelected);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_Remove_A_Door_From_The_List_That_The_User_Didnt_Select()
        {
            // Arrange
            var doors = new List<IDoor>
            {
                new Door() {Prize = false, UserSelected = true},
                new Door() {Prize = true, UserSelected = true},
                new Door() {Prize = false},
            };

            // Act
            var doorsWithOneRemoved = SimulationEnvironment.EliminateAClosedDoor(doors);
            var numberOfDoors = doorsWithOneRemoved.Count();
            var removedTheNonUserSelectedDoor = doorsWithOneRemoved.All(d => d.UserSelected);
            
            // Assert
            Assert.Equal(2,numberOfDoors);
            Assert.True(removedTheNonUserSelectedDoor);
        }
    }
}