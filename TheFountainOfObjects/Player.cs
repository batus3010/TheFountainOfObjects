using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    internal class Player
    {
        // current location of the player
        public Coordinate Location { get; set; }

        public Player(Coordinate position)
        {
            Location = position;
        }

        public bool SensePitRoom(Map map)
        {
            // Directions to check: north, south, east, west
            var directions = new List<Coordinate>
            {
                new Coordinate(Location.Row - 1, Location.Column), // North
                new Coordinate(Location.Row + 1, Location.Column), // South
                new Coordinate(Location.Row, Location.Column - 1), // West
                new Coordinate(Location.Row, Location.Column + 1)  // East
            };

            foreach (var direction in directions)
            {
                if (map.IsRoomOnMap(direction) && map.GetRoomType(direction) == RoomType.Pit)
                {
                    return true;
                }
            }
            return false;
        }

        // method for sensing Maelstorm room
        public bool SenseMaelstormRoom(Map map)
        {
            // Directions to check: north, south, east, west
            var directions = new List<Coordinate>
            {
                new Coordinate(Location.Row - 1, Location.Column), // North
                new Coordinate(Location.Row + 1, Location.Column), // South
                new Coordinate(Location.Row, Location.Column - 1), // West
                new Coordinate(Location.Row, Location.Column + 1)  // East
            };

            foreach (var direction in directions)
            {
                if (map.IsRoomOnMap(direction) && map.GetRoomType(direction) == RoomType.Maelstorm)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
