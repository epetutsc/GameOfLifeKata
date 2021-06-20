using Shouldly;

namespace GameOfLife.Tests
{
    public class CellTests
    {
        [ReadableFact]
        public void A_Cell_can_be_dead()
        {
            var cell = new Cell();
            cell.IsDead.ShouldBe(true);
        }
    }
}
