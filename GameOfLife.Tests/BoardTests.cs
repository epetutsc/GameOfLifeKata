﻿using System;
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

        [ReadableFact]
        public void Initial_all_cells_are_dead()
        {
            var board = new Board(width: 200, height: 200);

            for (var i = 0; i < board.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < board.Cells.GetLength(1); j++)
                {
                    board.Cells[i, j].IsDead.ShouldBeTrue();
                }
            }
        }

        [ReadableFact]
        public void All_cells_can_be_alive()
        {
            var board = new Board(width: 200, height: 200);

            for (var i = 0; i < board.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < board.Cells.GetLength(1); j++)
                {
                    board.Cells[i, j].SetAlive();
                    board.Cells[i, j].IsDead.ShouldBeFalse();
                }
            }
        }

        [ReadableFact]
        public void Any_alive_cell_with_no_alive_neighbours_dies()
        {
            var board = new Board(width: 3, height: 3);
            var cell = board.Cells[2, 2];
            cell.SetAlive();

            board.NextGeneration();

            cell.IsDead.ShouldBeTrue();
        }

        [ReadableFact]
        public void Any_alive_cell_with_fewer_than_two_alive_neighbours_dies_as_if_caused_by_underpopulation()
        {
            var board = new Board(width: 2, height: 2);
            var cell = board.Cells[0, 0];

            board.Cells[0, 0].SetAlive();
            board.Cells[0, 1].SetAlive();

            board.NextGeneration();

            cell.IsDead.ShouldBeTrue();
        }
    }
}
