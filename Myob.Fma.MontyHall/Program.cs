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
            var successfulStayCount = 0;
            
            var doors = new List<IDoor>
            {
                new Door(),
                new Door(),
                new Door(),
            };
            
            var montyHall = new SimulationEnvironment(doors);

            while (simulations <= 100000)
            {
                
                montyHall.RemovePrizesFromAllDoors();
                
                montyHall.PlacePrizeBehindRandomDoor();
                
                montyHall.ChooseARandomDoorForTheUser();
                
                montyHall.EliminateAClosedDoor();

                successfulStayCount += montyHall.CountOfPrizesBehindUserSelectedDoors();

                montyHall.ResetDoorsToHaveNoPrizesOrUserChoices();

                simulations++;

            }

            var stayPercentage = Math.Round(successfulStayCount / (decimal) simulations, 4);
            var changePercentage = 1 - stayPercentage;
            
            Console.WriteLine($"stay: {stayPercentage * 100}%");
            Console.WriteLine($"change: {changePercentage * 100}%");
        }
    }
}