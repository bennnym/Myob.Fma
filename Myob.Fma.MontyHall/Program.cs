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
            
            var doors = new List<IDoor>
            {
                new Door(),
                new Door(),
                new Door(),
            };
            
            var gameshow = new SimulationEnvironment(doors);

            while (simulations <= 100000)
            {
                
                gameshow.EmptyDoors();
                
                gameshow.PlacePrizeBehindDoor();
                
                gameshow.SimulateUserDoorSelection();
                
                gameshow.EliminateAClosedDoor();
                
                stayStats += gameshow.Doors.Count(door => door.ContainsPrize && door.IsUsersSelection);

                gameshow.ResetDoors();

                simulations++;

            }

            var stayPercentage = Math.Round(stayStats / (decimal) simulations, 2);
            
            Console.WriteLine($"stay: {stayPercentage}");
            Console.WriteLine($"change: {1 - stayPercentage}");
        }
    }
}