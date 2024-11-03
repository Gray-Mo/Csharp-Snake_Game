using SnakeGame;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

Random rand = new Random();
int frameDelay = 100;
int tailLength = 0;
int score = 0;

Coord gridDimensions = new Coord(75,30);
Coord snakePosition = new Coord(10,2);
Coord baitPosition = new Coord(rand.Next(1,gridDimensions.X-1), rand.Next(1,gridDimensions.Y-1));
Directions movementDirection = Directions.start;
List<Coord> snakeTail = new List<Coord>();


while (true)
{
    Console.Clear();
    Console.WriteLine("Score: " + score);
    snakePosition.ApplyMovementDirections(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentPosition = new Coord(x, y);

            // if (snakePosition.X == currentPosition.X && snakePosition.Y == currentPosition.Y)
            // we will use the override of the Equals Method
            if (snakePosition.Equals(currentPosition) || snakeTail.Contains(currentPosition))
                Console.Write("■");
            else if (baitPosition.Equals(currentPosition))
                Console.Write("O");
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }

    if(snakePosition.Equals(baitPosition))
    {
        tailLength++;
        score++;
        baitPosition = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
    }
    else if(snakePosition.X == 0 || snakePosition.Y == 0 || snakePosition.X == gridDimensions.X - 1 ||
        snakePosition.Y == gridDimensions.Y - 1 || snakeTail.Contains(snakePosition))
    {
        snakeTail.Clear();
        tailLength = 0;
        score = 0;
        snakePosition = new Coord(10, 2);
        movementDirection = Directions.start;
        continue;
    }

    snakeTail.Add(new Coord(snakePosition.X, snakePosition.Y));
    if (snakeTail.Count > tailLength)
        snakeTail.RemoveAt(0);

    DateTime time = DateTime.Now;

    while((DateTime.Now-time).Milliseconds < frameDelay)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch(key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Directions.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Directions.Right;
                    break;
                case ConsoleKey.UpArrow:
                    movementDirection = Directions.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Directions.Down;
                    break;
            }
        }
    }
}

Console.ReadLine();