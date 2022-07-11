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
            Square latestMove = pos;

            while (latestMove.Col < 7 && latestMove.Row < 7)
            {
                latestMove = Square.At(latestMove.Row + 1, latestMove.Col + 1);
                moves.Add(latestMove);
            }
            
            latestMove = pos;
            
            while (latestMove.Col < 7 && latestMove.Row > 0)
            {
                latestMove = Square.At(latestMove.Row-1, latestMove.Col+1);
                moves.Add(latestMove);
            }
            
            latestMove = pos;
            
            while (latestMove.Col > 0 && latestMove.Row > 0)
            {
                latestMove = Square.At(latestMove.Row-1, latestMove.Col-1);
                moves.Add(latestMove);
            }
            latestMove = pos;
            
            while (latestMove.Col > 0 && latestMove.Row < 7 )
            {
                latestMove = Square.At(latestMove.Row+1, latestMove.Col-1);
                moves.Add(latestMove);
            }


            return moves;
        }
    }
}