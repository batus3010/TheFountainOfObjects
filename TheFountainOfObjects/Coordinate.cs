using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    internal record Coordinate
    {
        public int Row { get; init; }
        public int Column { get; init; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
