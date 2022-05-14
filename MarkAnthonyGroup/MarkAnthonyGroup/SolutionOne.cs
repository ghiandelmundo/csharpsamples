using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarkAnthonyGroup
{
    public class KingChessGame
    {
        internal const int MIN_ROW = 1;
        internal const int MAX_ROW = 8;
        internal const int MIN_COL = 1;
        internal const int MAX_COL = 8;
        internal const int KING_MAX_SQUARE_MOVES = 1;

        int queenRow = MIN_ROW;
        int queenCol = MIN_ROW;
        int kingRow = MIN_ROW;
        int kingCol = MIN_ROW;

        int numberOfMoves = -1;

        public KingChessGame(string[] movesInput)
        {
            GetInitialPositions(movesInput);
            numberOfMoves = CountSquares(kingRow, kingCol);
        }

        private void GetInitialPositions(string[] moves)
        {
            string[] queenMoves = moves[0].Split('(', ')')[1].Split(',');
            queenRow = Convert.ToInt32(queenMoves[0]);
            queenCol = Convert.ToInt32(queenMoves[1]);

            string[] kingMoves = moves[1].Split('(', ')')[1].Split(',');
            kingRow = Convert.ToInt32(kingMoves[0]);
            kingCol = Convert.ToInt32(kingMoves[1]);
        }

        private bool CheckMate(int row, int col)
        {
            if (queenRow == row)
                return true;

            if (queenCol == col)
                return true;

            if (Math.Abs(queenRow - row) == Math.Abs(queenCol - col))
                return true;

            return false;
        }

        private int CountSquares(int row, int column, int move = 1)
        {
            if (CheckMate(row, column))
            {
                int squares = 0;
                for (int i = MIN_ROW; i <= MAX_ROW; i++)
                {
                    for (int j = MIN_COL; j <= MAX_COL; j++)
                    {
                        if (!CheckMate(i, j) && Math.Max(Math.Abs(i - row), Math.Abs(j - column)) <= KING_MAX_SQUARE_MOVES)
                            squares++;
                    }
                }
                return squares;
            }
            return -1;
        }

        public int NumberOfMoves => numberOfMoves;
    }

    class SolutionOne
    {
        static void Main()
        {
            KingChessGame kingChessGame = new KingChessGame(new string[] { "(2,2)", "(1,1)" });

            Console.WriteLine(kingChessGame.NumberOfMoves);
            Console.ReadLine();
        }
    }
}