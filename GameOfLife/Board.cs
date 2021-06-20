using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class Board : System.IEquatable<Board>
    {
        public int Rows => Cells.GetLength(0);
        public int Columns => Cells.GetLength(1);

        public Cell[,] Cells { get; init; } = new Cell[0, 0];

        private Board() { }

        public Board(int height, int width)
        {
            Cells = new Cell[height, width];
            InitCells(height, width);
        }

        private void InitCells(int height, int width)
        {
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    Cells[row, col] = new Cell();
                }
            }
        }

        public Board NextGeneration()
        {
            var clone = Clone();

            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    var cell = Cells[row, col];
                    var neighbours = GetNeighbours(row, col);
                    var neighboursCount = neighbours.Count(n => n.IsAlive);

                    if (cell.IsAlive)
                    {
                        if (neighboursCount < 2 || 3 < neighboursCount)
                        {
                            clone.Cells[row, col].Kill();
                        }
                    }
                    else if (neighboursCount == 3)
                    {
                        clone.Cells[row, col].SetAlive();
                    }
                }
            }

            return clone;
        }

        public Board Clone()
        {
            var clone = new Cell[Cells.GetLength(0), Cells.GetLength(1)];
            for (var i = 0; i < clone.GetLength(0); i++)
            {
                for (var j = 0; j < clone.GetLength(1); j++)
                {
                    clone[i, j] = Cells[i, j] with { };
                }
            }

            return new Board { Cells = clone };
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

        public static Board Parse(params string[] rows)
        {
            var columnsCount = GetColumns(rows[0]).Length;

            var cells = new Cell[rows.Length, columnsCount];
            for (var i = 0; i < rows.Length; i++)
            {
                var columns = GetColumns(rows[i]);
                for (var j = 0; j < columns.Length; j++)
                {
                    var cell = Cell.Parse(columns[j]);
                    cells[i, j] = cell;
                }
            }

            return new Board { Cells = cells };

            static string[] GetColumns(string row)
            {
                return row.Split(' ');
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Board);
        }

        public bool Equals(Board? other)
        {
            return ToString() == other?.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var i = 1;
            foreach (var cell in Cells)
            {
                sb.Append($"{cell} ");
                if (i % Columns == 0)
                {
                    sb.AppendLine();
                }
                i++;
            }

            return sb.ToString();
        }
    }
}
