using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            Square pos = board.FindPiece(this);
            Square move = pos;

            while (move.Col < 7 && move.Row < 7)
            {
                move = Square.At(move.Row + 1, move.Col + 1);
                if (board.checkIfEmpty(move)) moves.Add(move);
                else if (board.GetPiece(move).Player == this.Player && move != pos) break;
                else if (board.GetPiece(move).Player != this.Player && move != pos)
                {
                    moves.Add(move);
                    break;
                }
            }
            
            move = pos;
            
            while (move.Col < 7 && move.Row > 0)
            {
                move = Square.At(move.Row-1, move.Col+1);
                if (board.checkIfEmpty(move)) moves.Add(move);
                else if (board.GetPiece(move).Player == this.Player && move != pos) break;
                else if (board.GetPiece(move).Player != this.Player && move != pos)
                {
                    moves.Add(move);
                    break;
                }
            }
            
            move = pos;
            
            while (move.Col > 0 && move.Row > 0)
            {
                move = Square.At(move.Row-1, move.Col-1);
                if (board.checkIfEmpty(move)) moves.Add(move);
                else if (board.GetPiece(move).Player == this.Player && move != pos) break;
                else if (board.GetPiece(move).Player != this.Player && move != pos)
                {
                    moves.Add(move);
                    break;
                }
            }
            move = pos;
            
            while (move.Col > 0 && move.Row < 7 )
            {
                move = Square.At(move.Row+1, move.Col-1);
                if (board.checkIfEmpty(move)) moves.Add(move);
                else if (board.GetPiece(move).Player == this.Player && move != pos) break;
                else if (board.GetPiece(move).Player != this.Player && move != pos)
                {
                    moves.Add(move);
                    break;
                }
            }


            return moves;
        }
    }
}