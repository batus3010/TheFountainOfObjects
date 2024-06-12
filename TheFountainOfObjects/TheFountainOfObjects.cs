using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TheFountainOfObjects
{
    internal class TheFountainOfObjects
    {

        private Dictionary<string, string> messages = new();
        private readonly int _size;
        private readonly Player player;
        private readonly Map _map;

        private bool isFountainActive = false;

        // define 3 methods for small, medium, and large worlds, and Pick an appropriate location for the Fountain Room
        public TheFountainOfObjects(int size = 4)
        {
            InitializeMessages();

            _size = size;
            if (size == 4)
            {
                _map = new Map(4, 4);
                _map.SetRoomType(new Coordinate(0, 0), RoomType.Entrance);
                _map.SetRoomType(new Coordinate(0, 2), RoomType.Fountain);
                player = new Player(new Coordinate(0, 0));
            }
            else if (size == 6)
            {
                _map = new Map(6, 6);
                _map.SetRoomType(new Coordinate(0, 0), RoomType.Entrance);
                _map.SetRoomType(new Coordinate(0, 4), RoomType.Fountain);
                player = new Player(new Coordinate(0, 0));
            }
            else if (size == 8)
            {
                _map = new Map(8, 8);
                _map.SetRoomType(new Coordinate(0, 0), RoomType.Entrance);
                _map.SetRoomType(new Coordinate(0, 6), RoomType.Fountain);
                player = new Player(new Coordinate(0, 0));
            }
            else
            {
                Console.WriteLine("Invalid choice, defaulting to small world.");
                _map = new Map(4, 4);
                _map.SetRoomType(new Coordinate(0, 0), RoomType.Entrance);
                _map.SetRoomType(new Coordinate(0, 2), RoomType.Fountain);
                player = new Player(new Coordinate(0, 0));
            }
            // add pit room to the game
            _map.SetRoomType(new Coordinate(1, 2), RoomType.Pit);
            _map.SetRoomType(new Coordinate(2, 3), RoomType.Maelstorm);

        }

        private void InitializeMessages()
        {
            messages["entrance"] = "You see light coming from the cavern entrance.";
            messages["fountainFound"] = "You hear water dripping in this room. The Fountain of Objects is here!";
            messages["fountainFound_Active"] = "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
            messages["win"] = "The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!";
            messages["pitSense"] = "You feel a draft. There is a pit in a nearby room";
            messages["pitDeath"] = "You have fallen into a pit and died. Game over!";
            messages["maelStormSense"] = "You hear the growling and groaning of a maelstrom nearby";
            messages["invalid"] = "Invalid input. Please try again.";
        }

        /// <summary>
        /// The main game loop, keep running until the player wins or loses
        /// </summary>
        public void Run()
        {
            DateTime beginTime = DateTime.Now;
            // welcome message and display the rules of the game
            Console.WriteLine("Welcome to The Fountain of Objects!");
            while (true)
            {
                DisplayStatus();
                Action playerAction = GetPlayerAction();
                ResolvePlayerAction(playerAction);
                // if the player makes it back to entrance and have activated fountain, they win
                if (player.Location.Row == 0 && player.Location.Column == 0 && isFountainActive)
                {
                    Console.WriteLine(messages["win"]);
                    // display the total time player spent to complete the game, round to 2 decimal places
                    Console.WriteLine($"Total time spent: {Math.Round((DateTime.Now - beginTime).TotalSeconds, 2)} seconds.");
                    break;
                }
                else if (_map.GetRoomType(player.Location) == RoomType.Pit)
                {
                    Console.WriteLine(messages["pitDeath"]);
                    break;
                }
                // if player get into the Maelstorm room, they move one space north and two spaces west, make sure to clamp them on the map
                else if (_map.GetRoomType(player.Location) == RoomType.Maelstorm)
                {
                    Coordinate newPlayerLocation = new Coordinate(player.Location.Row - 1, player.Location.Column - 2);
                    // when player is moved, tell them so
                    Console.WriteLine("You have been sucked into the Maelstorm and moved one space north and two spaces west.");
                    // clamp the player location to the map
                    player.Location = new Coordinate(Math.Max(0, newPlayerLocation.Row), Math.Max(0, newPlayerLocation.Column));

                }

            }
        }

        public void DisplayStatus()
        {
            // display the current location of the player
            Console.WriteLine($"\nYou are in room (Row={player.Location.Row}, Column={player.Location.Column}).");
            // check if the player is in the room with the fountain
            if (_map.GetRoomType(player.Location) == RoomType.Fountain)
            {
                if (isFountainActive)
                {
                    Console.WriteLine(messages["fountainFound_Active"]);
                }
                else
                {
                    Console.WriteLine(messages["fountainFound"]);
                }
            }
            else if (_map.GetRoomType(player.Location) == RoomType.Entrance)
            {
                Console.WriteLine(messages["entrance"]);
            }

            //if (player.SensePitRoom(_map))
            //{
            //    Console.WriteLine(messages["pitSense"]);
            //}

            // sensing for pit and maelstorm
            if (player.SensePitRoom(_map))
            {
                Console.WriteLine(messages["pitSense"]);
            }
            if (player.SenseMaelstormRoom(_map))
            {
                Console.WriteLine(messages["maelStormSense"]);
            }

        }

        static private Action GetPlayerAction()
        {
            Console.Write("What do you want to do? ");
            string? input = Console.ReadLine();
            switch (input)
            {
                case "move north":
                    return Action.MoveNorth;
                case "move south":
                    return Action.MoveSouth;
                case "move east":
                    return Action.MoveEast;
                case "move west":
                    return Action.MoveWest;
                case "activate fountain":
                    return Action.ActivateFountain;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    return GetPlayerAction();
            }
        }

        // method to resolve player action
        private void ResolvePlayerAction(Action action)
        {
            switch (action)
            {
                case Action.MoveNorth:
                    if (player.Location.Row > 0)
                    {
                        player.Location = new Coordinate(player.Location.Row - 1, player.Location.Column);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move further North.");
                    }
                    break;
                case Action.MoveSouth:
                    if (player.Location.Row < _size - 1)
                    {
                        player.Location = new Coordinate(player.Location.Row + 1, player.Location.Column);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move further South.");
                    }
                    break;
                case Action.MoveEast:
                    if (player.Location.Column < _size - 1)
                    {
                        player.Location = new Coordinate(player.Location.Row, player.Location.Column + 1);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move further East.");
                    }
                    break;
                case Action.MoveWest:
                    if (player.Location.Column > 0)
                    {
                        player.Location = new Coordinate(player.Location.Row, player.Location.Column - 1);
                    }
                    else
                    {
                        Console.WriteLine("You cannot move further West.");
                    }
                    break;
                case Action.ActivateFountain:
                    if (_map.GetRoomType(player.Location) == RoomType.Fountain)
                    {
                        isFountainActive = true;
                        Console.WriteLine("You have activated the Fountain of Objects!");
                    }
                    else
                    {
                        Console.WriteLine("There is no Fountain of Objects in this room.");
                    }
                    break;
            }
        }

    }
        
    public enum RoomType { Normal, Entrance,Fountain, Pit, Maelstorm }

    public enum Action { MoveNorth, MoveSouth, MoveEast, MoveWest , ActivateFountain }
    public enum WorldSize { Small = 4, Medium = 6, Large = 8 }



}
