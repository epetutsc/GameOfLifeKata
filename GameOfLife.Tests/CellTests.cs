using Shouldly;

namespace GameOfLife.Tests
{
    public class CellTests
    {
        private readonly Cell _sut = new();

        [ReadableFact]
        public void A_cell_can_be_dead()
        {
            _sut.IsDead.ShouldBe(true);
        }

        [ReadableFact]
        public void A_cell_can_be_alive()
        {
            _sut.SetAlive();

            _sut.IsDead.ShouldBe(false);
        }
    }
}
