using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    internal class Map
    {
        // The map is a 2D array of RoomType
        private readonly RoomType[,] _roomTypes;

        /// <summary>
        /// Initialize the map with the given number of rows and columns
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Map(int rows, int columns)
        {
            _roomTypes = new RoomType[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _roomTypes[i, j] = RoomType.Normal;
                }
            }
        }

        public RoomType GetRoomType(Coordinate coordinate)
        {
            return _roomTypes[coordinate.Row, coordinate.Column];
        }

        public void SetRoomType(Coordinate coordinate, RoomType roomType)
        {
            _roomTypes[coordinate.Row, coordinate.Column] = roomType;
        }


    }
}
