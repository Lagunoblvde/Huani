using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_practos_zmeuka
{
    class Zmeuka
    {
        public void Zmeuki()
        {
            int boardWidth = 40;
            int boardHeight = 20;
            int snakeX = boardWidth / 2;
            int snakeY = boardHeight / 2;
            int foodX = 0;
            int foodY = 0;
            int score = 0;
            ConsoleKey direction = ConsoleKey.RightArrow;

            Random rand = new Random();
            List<int[]> snake = new List<int[]>();
            snake.Add(new int[] { snakeX, snakeY });

            SpawnFood();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if ((key == ConsoleKey.LeftArrow && direction != ConsoleKey.RightArrow) ||
                        (key == ConsoleKey.RightArrow && direction != ConsoleKey.LeftArrow) ||
                        (key == ConsoleKey.UpArrow && direction != ConsoleKey.DownArrow) ||
                        (key == ConsoleKey.DownArrow && direction != ConsoleKey.UpArrow))
                    {
                        direction = key;
                    }
                }

                switch (direction)
                {
                    case ConsoleKey.LeftArrow:
                        snakeX--;
                        break;
                    case ConsoleKey.RightArrow:
                        snakeX++;
                        break;
                    case ConsoleKey.UpArrow:
                        snakeY--;
                        break;
                    case ConsoleKey.DownArrow:
                        snakeY++;
                        break;
                }

                if (snakeX < 0 || snakeY < 0 || snakeX >= boardWidth || snakeY >= boardHeight || CheckCollision(snakeX, snakeY))
                {
                    Console.Clear();
                    Console.WriteLine("Game over! Your score: " + score);
                    break;
                }

                if (snakeX == foodX && snakeY == foodY)
                {
                    score++;
                    snake.Add(new int[] { foodX, foodY });
                    SpawnFood();
                }

                MoveSnake(snakeX, snakeY);
                RenderBoard();
                Thread.Sleep(100);
            }

            void RenderBoard()
            {
                Console.Clear();
                for (int y = 0; y <= boardHeight; y++)
                {
                    for (int x = 0; x <= boardWidth; x++)
                    {
                        if (x == 0 || y == 0 || x == boardWidth || y == boardHeight) 
                            Console.Write("#");
                        else if (x == foodX && y == foodY)
                            Console.Write("F");
                        else if (CheckCollision(x, y))
                            Console.Write("S");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }


            bool CheckCollision(int x, int y)
            {
                foreach (int[] part in snake)
                {
                    if (part[0] == x && part[1] == y)
                        return true;
                }
                return false;
            }

            void MoveSnake(int newX, int newY)
            {
                snake.Insert(0, new int[] { newX, newY });
                snake.RemoveAt(snake.Count - 1);
            }

            void SpawnFood()
            {
                do
                {
                    foodX = rand.Next(0, boardWidth);
                    foodY = rand.Next(0, boardHeight);
                } while (CheckCollision(foodX, foodY));
            }
        }
    }

}
    