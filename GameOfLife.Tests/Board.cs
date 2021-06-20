namespace GameOfLife.Tests
{
    public class Board
    {
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
    }
}
