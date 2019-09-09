using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulations = 0;
            var stayStats = 0;
            var changeStats = 0;
            
            var doors = new List<IDoor>
            {
                new Door() {Prize = false},
                new Door() {Prize = false},
                new Door() {Prize = false},
            };

            while (simulations <= 1000)
            {
                var emptiedDoors = SimulationEnvironment.EmptyDoors(doors);

                var doorsWithPrizePlaced = SimulationEnvironment.PlacePrizeBehindDoor(emptiedDoors);

                var simulateUserDoorSelection = SimulationEnvironment.SimulateUserDoorSelection(doorsWithPrizePlaced);

                var removeNonPrizeDoor = SimulationEnvironment.EliminateAClosedDoor(simulateUserDoorSelection);

                simulations++;

                foreach (var door in removeNonPrizeDoor)
                {
                    if (door.Prize && door.UserSelected)
                    {
                        stayStats++;
                    }
                    else
                    {
                        changeStats++;
                    }
                }
            }
        }
    }
}