using Shouldly;

namespace GameOfLife.Tests
{
    public class BoardTests
    {
        [ReadableFact]
        public void A_board_contains_cells_in_2_dimensions()
        {
            var board = new Board(width: 200, height: 200);

            board.Cells[0, 0].ShouldNotBeNull();
            board.Cells[199, 199].ShouldNotBeNull();
        }
    }
}
