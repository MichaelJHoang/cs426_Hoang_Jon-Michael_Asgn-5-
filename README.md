# WHEN BUILDING, MAKE SURE TO BUILD AS x86_64

# Assignment 2 - Networking and Serious Games

Group 2  - Red Sparrow Interactive

Members:

* Ronny Recinos
* Jon-Michael Hoang
* Jim Li


# Documentation

### Game Idea
The idea of the game incorporates loosely computer architecture and birds in that the players have to collect
birds and escape the map by solving puzzles involving logic gates - through which some puzzles requires other birds
to solve the puzzle as well. The players play as those who are trapped in a lucid dream and must escape.


###Unusual procedure/rule
The unusual/procedure rule that this game has is that the players can only interact with their corresponding birds.
In this case, Player1 can only interact with red birds whereas Player2 can only interact with blue/purplish birds.
This is to allow cooperation between players to complete the game's puzzles and reach the end. 

This is also mentioned under the Formal Elements section below.

### Assets Used
* Characters designed by Jon-Michael Hoang
* Environment - level design by Ronny Recinos
  * Rocks - Flatkit
  * Trees - Flatkit
  * Foliage - Flatkit
  * Bird - Modeled by Ronny Recinos
  * Pedestal - Modeled by Ronny Recinos
  * Logic Gates - Modeled by Ronny Recinos
  * Wires - Spline Mesh
  * Exit Gate - Modeled by Ronny Recinos
* Shaders
  * Xiexes Unity Shaders
  * Flatkit Shaders
  * Cubed's Unity Shaders
* Audio from Epic Stock Media
* Character movement and animations from Unity Standard Assets
* TextMesh Pro
* Cinemachine
* Dynamic Bones
* Post Processing from Unity



### Formal Elements

###Players
The game is a cooperative, two-player game requiring networked connections to communicate with one another.


###Objectives
This is a Solution/Exploration based game in that the players have to explore the game area to collect
birds and their pieces in addition to solving logic-gate puzzles along the way to obtain said birds and
unlock the exit to win the game.


###Procedures
* WASD to control the movement of the characters
* Hold Left Shift to enable running
* E to interact
* P to pick up birds

###Rules
Both players can collect and interact with specific birds based on color.
To finish the game, the player has to do logic-gate puzzles along the way.


###Resources
Birds and bird pieces used to solve certain puzzles within the game.


###Conflict
Physical obstacle: The birds and logic gates that are necessary for the completion of the game as mentioned
above.


###Boundaries:
Physical: Edges of the map itself - players are not allowed to go out of bounds.


###Outcome:
The game is a non-zero sum game in that both players either win or lose and that there is no competition in this
game - only cooperation.
