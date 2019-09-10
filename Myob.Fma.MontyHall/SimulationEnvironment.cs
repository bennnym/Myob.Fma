using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.MontyHall
{
    public class SimulationEnvironment
    {
        public SimulationEnvironment(List<IDoor> doors)
        {
            Doors = doors;
        }

        public List<IDoor> Doors { get; private set; }

        public void EmptyDoors()
        {
            foreach (var door in Doors)
            {
                door.ContainsPrize = false;
            }
        }

        public void PlacePrizeBehindDoor()
        {
            var randomIndex = new Random().Next(0, Doors.Count());

            Doors[randomIndex].ContainsPrize = true;
        }

        public void SimulateUserDoorSelection()
        {
            var randomIndex = new Random().Next(0, Doors.Count());

            Doors[randomIndex].IsUsersSelection = true;
        }

        public void EliminateAClosedDoor()
        {
            var doorToEliminate = Doors.First(d => d.IsUsersSelection == false);

            Doors.Remove(doorToEliminate);
        }

        public void ResetDoors()
        {
            Doors = new List<IDoor>()
            {
                new Door(),
                new Door(),
                new Door()
            };
        }
    }
}