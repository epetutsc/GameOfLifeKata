using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var generation = 1;
            var board = Board.Parse(
                "x x x x x x x o x o o o x x o o o x x x x x x x x x x x x x x x x x x x x x x x ",
                "x x o x x x x x x x o x x x x x x x o x x x x x x x o x x x x x x x o x x x x x ",
                "x x x o o o x x x x x o o o x x x x x o o o x x x x x o o o x x x x x o o o x x ",
                "x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x x ",
                "x x o x o o x x x x o x o o x x x x o x o o x x x x o x o o x o x x o x o o x x ",
                "x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x ",
                "x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x ",
                "x x o x x x x x x x o x x x x x x x o x x x x x x x o x x x x x x x o x x x x x ",
                "x x x o o o x x x x x o o o x x x x x o o o x x x x x o o o x x x x x o o o x x ",
                "x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x x ",
                "x x o x o o x x x x o x o o x x x x o x o o x x x x o x o o x x x x o x o o x x ",
                "x x x x x x x x x x x x x x x x o x x x x x x x x x x x x x x x x x x x x x x x ",
                "x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x ",
                "x x o x x x x x x x o x x x x x x x o x x x x x x x o x x x x x x x o x x x x x ",
                "x x x o o o x x x x x o o o x x x x x o o o x x x x x o o o x x x x x o o o x x ",
                "x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x o ",
                "x x o x o o x x x x o x o o x x x x o x o o x x x x o x o o x x x x o x o o x x ",
                "o x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x o x x x o ",
                "o x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x x o x ",
                "x x o x x x x x x x o x x x x x x o o x x o x x x x o x x x x x x x o x x x x x ",
                "x x x o o o x x x x x o o o x x x x x o o o x x x x x o o o x x x x o o o o x x ",
                "x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x x x x x o x o x x ",
                "x x o x o o x x x x o x o o x x x x o x o o x x x x o x o o x x o x o x o o x x ",
                "x x x x x x x x x x x x x x x x x x x x x x x x x x o x x x x x x x x x x x x x "
                );

            while(true)
            {
                var screen = board.ToString();
                board = board.NextGeneration();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(screen);
                Console.WriteLine(generation);
                await Task.Delay(10);
                generation++;
            }
        }
    }
}
