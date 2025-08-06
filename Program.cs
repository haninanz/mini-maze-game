using System;
using System.Security.Principal;

Random random = new();
int height = Console.WindowHeight - 3;
int width = Console.WindowWidth - 5;

// Available player and food strings
string[] states = ["('-')", "(^-^)", "(X_X)"];
string[] foods = ["@@@@@", "$$$$$", "#####"];

// Console position of the player
int playerX = 1;
int playerY = 1;

// Console positions of all items
int[] obstaclesX = [10, 25, 42];
int[] obstaclesY = [5, 4, 7];
int foodX = random.Next(2, width - 1);
int foodY = random.Next(2, height - 1);

Console.Clear();
DrawFullMap(height, width);

void DrawHorizontalWall(int width)
{
    for (int i = 0; i < width; i++)
        Console.Write("-");
    Console.WriteLine();
}

void DrawVerticalWall(int height, int x)
{
    for (int y = 1; y < height; y++)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine("|");
    }
}

void DrawPlayer(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.Write(states[random.Next(0, states.Length)]);
}

void DrawObstacles(int x)
{
    int y = obstaclesY[Array.IndexOf(obstaclesX, x)];
    Console.SetCursorPosition(x, y);
    Console.Write("//");
}

void DrawFood(int x, int y)
{
    Console.SetCursorPosition(x, y);
    Console.Write(foods[random.Next(0, foods.Length)]);
}

void DrawFullMap(int height, int width)
{
    DrawHorizontalWall(width);
    for (int i = 0; i < width; i++)
    {
        if (i == 0 || i == width - 1)
            DrawVerticalWall(height, i);
        else if (i == playerX)
            DrawPlayer(i, playerY);
        else if (obstaclesX.Contains(i))
            DrawObstacles(i);
        else if (i == foodX)
            DrawFood(i, foodY);
    }
    DrawHorizontalWall(width);
}

// Console.CursorVisible = false;
// bool shouldExit = false;

// // Current player string displayed in the Console
// string player = states[0];

// // Index of the current food
// int food = 0;

// InitializeGame();
// while (!shouldExit) 
// {
//     Move();
// }

// // Returns true if the Terminal was resized 
// bool TerminalResized() 
// {
//     return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
// }

// // Displays random food at a random location
// void ShowFood() 
// {
//     // Update food to a random index
//     food = random.Next(0, foods.Length);

//     // Update food position to a random location
//     foodX = random.Next(0, width - player.Length);
//     foodY = random.Next(0, height - 1);

//     // Display the food at the location
//     Console.SetCursorPosition(foodX, foodY);
//     Console.Write(foods[food]);
// }

// // Changes the player to match the food consumed
// void ChangePlayer() 
// {
//     player = states[food];
//     Console.SetCursorPosition(playerX, playerY);
//     Console.Write(player);
// }

// // Temporarily stops the player from moving
// void FreezePlayer() 
// {
//     System.Threading.Thread.Sleep(1000);
//     player = states[0];
// }

// // Reads directional input from the Console and moves the player
// void Move() 
// {
//     int lastX = playerX;
//     int lastY = playerY;
    
//     switch (Console.ReadKey(true).Key) 
//     {
//         case ConsoleKey.UpArrow:
//             playerY--; 
//             break;
// 		case ConsoleKey.DownArrow: 
//             playerY++; 
//             break;
// 		case ConsoleKey.LeftArrow:  
//             playerX--; 
//             break;
// 		case ConsoleKey.RightArrow: 
//             playerX++; 
//             break;
// 		case ConsoleKey.Escape:     
//             shouldExit = true; 
//             break;
//     }

//     // Clear the characters at the previous position
//     Console.SetCursorPosition(lastX, lastY);
//     for (int i = 0; i < player.Length; i++) 
//     {
//         Console.Write(" ");
//     }

//     // Keep player position within the bounds of the Terminal window
//     playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
//     playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

//     // Draw the player at the new location
//     Console.SetCursorPosition(playerX, playerY);
//     Console.Write(player);
// }

// // Clears the console, displays the food and player
// void InitializeGame() 
// {
//     Console.Clear();
//     ShowFood();
//     Console.SetCursorPosition(0, 0);
//     Console.Write(player);
// }