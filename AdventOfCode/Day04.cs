using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day04
    {
        public static int Part1(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day04));

            var numbersToDraw = input[0].Split(",").Select(int.Parse).ToArray();
            var boardInput = input[2..];

            var boards = CreateBoards(boardInput);
            foreach (var number in numbersToDraw)
            {
                foreach (var board in boards)
                {
                    if (board.Mark(number) && board.Bingo)
                    {
                        var sum = board.UnmarkedNumbers.Sum();
                        return number * sum;
                    }
                }
            }
            
            return 0;
        }

        public static int Part2(string[] input = null)
        {
            input ??= Input.ReadAllLines(nameof(Day04));

            var numbersToDraw = input[0].Split(",").Select(int.Parse).ToArray();
            var boardInput = input[2..];

            var boards = CreateBoards(boardInput);
            var winningBoards = new List<(Board board, int score)>();
            foreach (var number in numbersToDraw)
            {
                foreach (var board in boards)
                {
                    if (board.Bingo)
                        continue;
                    
                    if (board.Mark(number) && board.Bingo)
                    {
                        var sum = board.UnmarkedNumbers.Sum();
                        winningBoards.Add((board, number*sum));
                    }
                }
            }

            return winningBoards.Last().score;
        }

        private static Board[] CreateBoards(string[] input)
        {
            var boards = new List<string[]>();

            var currentBoard = new List<string>();
            foreach (var row in input)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    boards.Add(currentBoard.ToArray());
                    currentBoard = new List<string>();
                    continue;
                }
                currentBoard.Add(row);
            }
            if (currentBoard.Count > 0)
                boards.Add(currentBoard.ToArray());

            return boards.Select(Board.Create).ToArray();
        }

        private class Board
        {
            private readonly (int number, bool marked)[][] _rows;

            public Board((int, bool)[][] rows)
            {
                _rows = rows;
            }

            public bool Mark(int number)
            {
                for (var row = 0; row < 5; row++)
                {
                    for (var col = 0; col < 5; col++)
                    {
                        if (_rows[row][col].number == number)
                        {
                            _rows[row][col].marked = true;
                            return true;
                        }
                    }
                }

                return false;
            }

            public bool Bingo
            {
                get
                {
                    for (var row = 0; row < 5; row++)
                    {
                        if (_rows[row][..].All(x => x.marked))
                            return true;
                    }

                    for (var col = 0; col < 5; col++)
                    {
                        var bingo = true;
                        for (var row = 0; row < 5; row++)
                        {
                            if (!_rows[row][col].marked)
                            {
                                bingo = false;
                                break;
                            }
                        }
                        if (bingo)
                            return true;
                    }
                    
                    return false;
                }
            }

            public int[] UnmarkedNumbers
            {
                get
                {
                    var unmarked = new List<int>();
                    for (var row = 0; row < 5; row++)
                    {
                        for (var col = 0; col < 5; col++)
                        {
                            if (!_rows[row][col].marked)
                            {
                                unmarked.Add(_rows[row][col].number);
                            }
                        }
                    }

                    return unmarked.ToArray();
                }
            }

            public static Board Create(string[] input)
            {
                var intRows = new List<(int, bool)[]>();
                foreach (var row in input)
                {
                    var numbers = row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
                    intRows.Add(numbers.Select(n => (n, false)).ToArray());
                }

                return new Board(intRows.ToArray());
            }
        }
    }
}
