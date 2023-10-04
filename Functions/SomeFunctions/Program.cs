using System;
using System.IO;

namespace SomeFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string pathMap = "map.txt";

            char[,] map = ReadMap(pathMap);

            ConsoleKeyInfo pressedKey;

            ConsoleKey pressedKeyExit = ConsoleKey.Escape;

            int pacmanPositionX = 1;
            int pacmanPositionY = 1;
            int score = 0;
            int scorePositionX = map.GetLength(0);
            int scorePositionY = 0;
            int textPositionX = 0;
            int textPositionY = map.GetLength(1) + 1;

            bool isWork = true;

            char pacmanSymbolOnMap = '@';

            while (isWork)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                DrawMap(map);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(pacmanPositionX, pacmanPositionY);
                Console.Write(pacmanSymbolOnMap);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(scorePositionX, scorePositionY);
                Console.Write($"Score: {score}");

                Console.SetCursorPosition(textPositionX, textPositionY);
                Console.WriteLine("Для выхода из игры нажмите ESC");

                pressedKey = Console.ReadKey();

                if (pressedKey.Key == pressedKeyExit)
                {
                    isWork = false;
                    Console.Clear();

                    Console.WriteLine("До свидания!");
                }

                HandelInput(pressedKey, ref pacmanPositionX, ref pacmanPositionY, map, ref score);
            }
        }

        private static char[,] ReadMap(string pathMap)
        {
            string[] file = File.ReadAllLines(pathMap);

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x, y] = file[y][x];

            return map;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }
        }

        private static void HandelInput(ConsoleKeyInfo pressedKey, ref int pacmanPositionX, ref int pacmanPositionY, char[,] map, ref int score)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPacmanPositionX = pacmanPositionX + direction[0];
            int nextPacmanPositionY = pacmanPositionY + direction[1];

            char nextCell = map[nextPacmanPositionX, nextPacmanPositionY];
            char freeSpaceSymbol = ' ';
            char pointSymbol = '.';

            if (nextCell == freeSpaceSymbol || nextCell == pointSymbol)
            {
                pacmanPositionX = nextPacmanPositionX;
                pacmanPositionY = nextPacmanPositionY;

                if (nextCell == pointSymbol)
                {
                    score++;
                    map[nextPacmanPositionX, nextPacmanPositionY] = freeSpaceSymbol;
                }
            }
        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            ConsoleKey upCommand = ConsoleKey.UpArrow;
            ConsoleKey downCommand = ConsoleKey.DownArrow;
            ConsoleKey leftCommand = ConsoleKey.LeftArrow;
            ConsoleKey rightCommand = ConsoleKey.RightArrow;

            if (pressedKey.Key == upCommand)
                direction[1] = -1;
            else if (pressedKey.Key == downCommand)
                direction[1] = 1;
            else if (pressedKey.Key == leftCommand)
                direction[0] = -1;
            else if (pressedKey.Key == rightCommand)
                direction[0] = 1;

            return direction;
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach (var line in lines)
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;
        }
    }
}
