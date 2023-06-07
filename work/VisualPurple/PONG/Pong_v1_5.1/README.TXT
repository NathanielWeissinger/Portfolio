TITLE: Unreal Engine 5 PONG
Author: Nathaniel Weissinger


TO START:
After opening the project in UE5, in the Content Drawer, navigate to:
All -> Content -> Pong -> Maps
Double click on Main_Menu_Level, then click the green Play button on the upper
navigation bar.

TO PLAY:
The left-hand side of the screen is Player 1, and the right side of the screen
is Player 2. Player 1 uses the W and S keys to go up and down respectively.
If the Two Player game mode is selected, the second player will use the
Up and Down arrow keys to play. Otherwise, if the Player vs. CPU option is
selected, a rudimentary AI was built as a CPU player to go against.


REQUIREMENTS:
Due to time constraints, no sound effects were added. However, all requirements
were satisfied:

1. The game is playable as:
-Single player against an AI
-Two players against each other

2. Two paddles can be:
-Controlled along the X-Axis
-Can redirect the ball during collisions

3. Has a playable area that:
-Is fixed to be no larger than the screen
-Has reflective bounds both along the top and bottom
-Allows the ball to pass through the bounds along the left and right

4. Has a scoring system that:
-Is tracked and visible for both players
-Scores 1 point to the player that successfully gets the ball past the other player's paddle.
-Has a max score of 11
-Indicates when the game is won once the first player to reach 11 points

5. Has both:
-A main menu screen for selecting game modes
-An end game screen, with New Game, Retry, and Quit buttons


ADDITIONAL NOTES:
The ball respawns in the middle of the PONG board, shooting at the last person who
lost a point. The ball is nudged slightly in a random direction within the
receiving player's vicinity, and as the rounds increase, the ball increases in speed.
The AI does not increase in difficulty.

Some features were not included due to time constraints, but it is worth noting:
-There are no sound effects
-The background and logo were all stolen from the internet somewhere
-There could have been difficulty levels for the AI, since there were only two
variables that specified its difficulty, but the level of difficulty was chosen
as it stands so that points could be won relatively easily and quickly without
volleying for hours
-Although there could have been several other improvements, time constraints
dictate that this is a relatively functional piece, despite being built in
two days.


Thank you for reviewing this README file!
