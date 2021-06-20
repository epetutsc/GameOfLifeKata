using Shouldly;

namespace GameOfLife.Tests
{
    public class CellTests
    {
        [ReadableFact]
        public void A_cell_can_be_dead()
        {
            var cell = new Cell();
            cell.IsDead.ShouldBe(true);
        }

        [ReadableFact]
        public void A_cell_can_be_alive()
        {
            var cell = new Cell();
            cell.SetAlive();
            cell.IsDead.ShouldBe(false);
        }
    }
}
