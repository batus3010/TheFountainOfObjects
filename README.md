# TheFountainOfObjects
# The Fountain of Objects Game
1. [Overview](#overview)
2. [Objectives](#objectives)
3. [Example Gameplay](#example-gameplay)
4. [Code Structure](#code-structure)
## Overview

**The Fountain of Objects** is a 2D grid-based adventure game where players navigate through a dark cavern to find and activate the mystical Fountain of Objects. The objective is to activate the fountain and return to the entrance without falling into any pits, relying on senses such as hearing and smell due to the pervasive unnatural darkness.

## Objectives

1. **Grid-Based World**: The world is a grid of rooms, referenced by their row and column. Directions are:
   - **North**: Up
   - **East**: Right
   - **South**: Down
   - **West**: Left

2. **Game Flow**:
   - The player is informed of their surroundings based on senses.
   - The player types an action to perform.
   - The game processes the action and updates the state.
   - The loop repeats until the game is won or lost.

3. **Room Types**:
   - **Empty Rooms**: Nothing to sense.
   - **Entrance** (Row=0, Column=0): The starting point. The player senses light from outside.
   - **Fountain Room** (Row=0, Column=2): Contains the Fountain of Objects, which can be enabled or disabled.

4. **Player Actions**:
   - Movement: `move north`, `move south`, `move east`, `move west`. The player can't move outside the map boundaries.
   - Enable Fountain: `activate fountain`. Only works in the Fountain Room.

5. **Winning Condition**:
   - Activate the fountain.
   - Return to the entrance with the fountain activated.

6. **Console Text Colors**:
   - **Narrative**: Magenta
   - **Descriptive Text**: White
   - **User Input**: Cyan
   - **Entrance Light Description**: Yellow
   - **Fountain Messages**: Blue

## Example Gameplay

```plaintext
----------------------------------------------------------------------------------
You are in the room at (Row=0, Column=0).
You see light coming from the cavern entrance.
What do you want to do? move east
----------------------------------------------------------------------------------
You are in the room at (Row=0, Column=1).
What do you want to do? move east
----------------------------------------------------------------------------------
You are in the room at (Row=0, Column=2).
You hear water dripping in this room. The Fountain of Objects is here!
What do you want to do? enable fountain
----------------------------------------------------------------------------------
You are in the room at (Row=0, Column=2).
You hear the rushing waters from the Fountain of Objects. It has been reactivated!
What do you want to do? move west
----------------------------------------------------------------------------------
You are in the room at (Row=0, Column=1).
What do you want to do? move west
----------------------------------------------------------------------------------
You are in the room at (Row=0, Column=0).
The Fountain of Objects has been reactivated, and you have escaped with your life!
You win!
```

## Code Structure
1. **TheFountainOfObjects**: Main class that initializes the game, runs the main loop, and processes player actions.
2. **Map**: Represents the grid of rooms, manages room types.
3. **Player**: Represents the player, tracks their current location.
4. **Coordinate**: Represents a grid coordinate (row and column).
5. **Enums**:
- RoomType: Enum for different room types (Normal, Entrance, Fountain, Pit).
- Action: Enum for player actions (MoveNorth, MoveSouth, MoveEast, MoveWest, ActivateFountain).
- RoomSize: Enum for different map sizes (Small, Medium, Large).

## How to run
1. Clone The repository 
```
git clone https://github.com/yourusername/TheFountainOfObjects.git
cd TheFountainOfObjects
```
2. Open the project in your preferred C# IDE (e.g., Visual Studio).

3. Run the project.

4. Follow the prompts in the console to play the game.
