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



    }
}
