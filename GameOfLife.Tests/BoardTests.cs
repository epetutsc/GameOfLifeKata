using System;
using System.Threading;
using Shouldly;

namespace GameOfLife.Tests
{
    public class BoardTests
    {
        [ReadableFact]
        public void A_board_contains_cells_in_2_dimensions()
        {
            var board = new Board(height: 200, width: 200);

            board.Cells[0, 0].ShouldNotBeNull();
            board.Cells[199, 199].ShouldNotBeNull();
        }

        [ReadableFact]
        public void Initial_all_cells_are_dead()
        {
            var board = new Board(height: 200, width: 200);

            foreach (var cell in board.Cells)
            {
                cell.IsDead.ShouldBeTrue();
            }
        }

        [ReadableFact]
        public void All_cells_can_be_alive()
        {
            var board = new Board(height: 200, width: 200);

            foreach (var cell in board.Cells)
            {
                cell.SetAlive();
                cell.IsAlive.ShouldBeTrue();
            }
        }

        [ReadableFact]
        public void A_board_can_be_cloned()
        {
            var board = Board.Parse(
                    "o o o",
                    "o o o",
                    "o o o");

            var clone = board.Clone();
            clone.Cells[0, 0].Kill();

            board.Cells[0, 0].IsAlive.ShouldBeTrue();
        }

        [ReadableFact]
        public void Any_alive_cell_with_no_alive_neighbours_dies()
        {
            Assert(
                Board.Parse(
                    "x x x",
                    "x o x",
                    "x x x"),

                Board.Parse(
                    "x x x",
                    "x x x",
                    "x x x"));
        }

        [ReadableFact]
        public void Any_alive_cell_with_fewer_than_two_alive_neighbours_dies_as_if_caused_by_underpopulation()
        {
            Assert(
                Board.Parse(
                    "o x",
                    "x x"),

                Board.Parse(
                    "x x",
                    "x x"));

            Assert(
                Board.Parse(
                    "o o",
                    "x x"),

                Board.Parse(
                    "x x",
                    "x x"));

            Assert(
                Board.Parse(
                    "o x",
                    "o x"),

                Board.Parse(
                    "x x",
                    "x x"));

            Assert(
                Board.Parse(
                    "o x",
                    "x o"),

                Board.Parse(
                    "x x",
                    "x x"));
        }

        [ReadableFact]
        public void Any_alive_cell_with_more_than_three_live_neighbours_dies_as_if_by_overcrowding()
        {
            Assert(
                Board.Parse(
                    "o o o",
                    "o o o",
                    "o o o"),

                Board.Parse(
                    "o x o",
                    "x x x",
                    "o x o"));
        }

        [ReadableFact]
        public void Any_alive_cell_with_two_or_three_alive_neighbours_lives_on_to_the_next_generation()
        {
            Assert(
                Board.Parse(
                    "o x o",
                    "x o x",
                    "x x x"),

                Board.Parse(
                    "x o x",
                    "x o x",
                    "x x x"));

            Assert(
                Board.Parse(
                    "x x o",
                    "x o x",
                    "o x o"),

                Board.Parse(
                    "x x x",
                    "x o o",
                    "x o x"));
        }

        [ReadableFact]
        public void Any_dead_cell_with_exactly_three_live_neighbours_becomes_a_live_cell()
        {
            Assert(
                Board.Parse(
                    "x o x",
                    "o o x",
                    "x x x"),

                Board.Parse(
                    "o o x",
                    "o o x",
                    "x x x"));
        }

        private static void Assert(Board old, Board @new)
        {
            var result = old.NextGeneration();

            result.ShouldBe(@new, $"input: {old}");
        }
    }
}
