using System;
using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        public int Rows => Cells.GetLength(0);
        public int Columns => Cells.GetLength(1);

        public Cell[,] Cells { get; }

        public Board(int width, int height)
        {
            Cells = new Cell[width, height];
            InitCells(width, height);
        }

        private void InitCells(int width, int height)
        {
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    Cells[row, col] = new Cell();
                }
            }
        }

        public void NextGeneration()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    var cell = Cells[row, col];
                    var neighbours = GetNeighbours(row, col);
                    if (!neighbours.Any(n => n.IsAlive))
                    {
                        cell.Kill();
                    }
                }
            }
        }

        private Cell[] GetNeighbours(int row, int col)
        {
            var qry =
                from r in new[] { row - 1, row, row + 1 }
                from c in new[] { col - 1, col, col + 1 }
                where r >= 0 && r < Rows
                   && c >= 0 && c < Columns
                   && (r, c) != (row, col)
                select Cells[r, c];

            return qry.ToArray();
        }
    }
}
