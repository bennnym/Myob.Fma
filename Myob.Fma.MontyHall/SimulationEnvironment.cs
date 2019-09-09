using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.MontyHall
{
    public static class SimulationEnvironment
    {
        public static IList<IDoor> EmptyDoors(IList<IDoor> doors)
        {
            foreach (var door in doors)
            {
                door.Prize = false;
            }

            return doors;
        }

        public static IList<IDoor> PlacePrizeBehindDoor(IList<IDoor> doors)
        {
            var randomDoorToPlacePrizeBehind = new Random().Next(0, doors.Count() - 1);

            doors[randomDoorToPlacePrizeBehind].Prize = true;

            return doors;
        }
        
        public static IList<IDoor> SimulateUserDoorSelection(IList<IDoor> doors)
        {
            var userSelectedDoor = new Random().Next(0, doors.Count() - 1);

            doors[userSelectedDoor].UserSelected = true;

            return doors;
        }

        public static IList<IDoor> EliminateAClosedDoor(IList<IDoor> doors)
        {
            var eliminatedDoor = doors.First(d => d.UserSelected == false);

            doors.Remove(eliminatedDoor);

            return doors;
        }
    }
}