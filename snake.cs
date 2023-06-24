using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    private static int width = 40;
    private static int height = 20;
    private static int score = 0;
    private static int sleepTime = 200; // milliseconds
    private static bool gameover = false;

    private static Direction direction = Direction.Right;
    private static Random random = new Random();

    private static List<int> snakeX = new List<int>();
    private static List<int> snakeY = new List<int>();
    private static int foodX;
    private static int foodY;

    static void Main()
    {
        Console.WindowHeight = height + 2;
        Console.WindowWidth = width + 2;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Console.Title = "Snake Game";

        InitializeSnake();
        PlaceFood();

        Thread inputThread = new Thread(ReadInput);
        inputThread.Start();

        while (!gameover)
        {
            Draw();
            Move();
            Thread.Sleep(sleepTime);
        }

        Console.SetCursorPosition(width / 2 - 4, height / 2);
        Console.WriteLine("Game Over! Score: " + score);
        Console.ReadLine();
    }

    static void InitializeSnake()
    {
        snakeX.Add(10);
        snakeY.Add(10);
    }

    static void PlaceFood()
    {
        foodX = random.Next(1, width);
        foodY = random.Next(1, height);
    }

    static void ReadInput()
    {
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
            }
        }
    }

    static void Move()
    {
        int newX = snakeX[0];
        int newY = snakeY[0];

        switch (direction)
        {
            case Direction.Up:
                newY--;
                break;
            case Direction.Down:
                newY++;
                break;
            case Direction.Left:
                newX--;
                break;
            case Direction.Right:
                newX++;
                break;
        }

        if (newX <= 0 || newX >= width || newY <= 0 || newY >= height)
        {
            gameover = true;
            return;
        }

        if (snakeX.Contains(newX) && snakeY.Contains(newY))
        {
            gameover = true;
            return;
        }

        snakeX.Insert(0, newX);
        snakeY.Insert(0, newY);

        if (newX == foodX && newY == foodY)
        {
            score++;
            PlaceFood();
        }
        else
        {
            snakeX.RemoveAt(snakeX.Count - 1);
            snakeY.RemoveAt(snakeY.Count - 1);
        }
    }

    static void Draw()
    {
        Console.Clear();

        Console.SetCursorPosition(foodX, foodY);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("o");

        for (int i = 0; i < snakeX.Count; i++)
        {
            Console.SetCursorPosition(snakeX[i], snakeY[i]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(i == 0 ? "@" : "*");
        }

        Console.SetCursorPosition(0, height);
        Console.WriteLine("Score: " + score);
    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}
