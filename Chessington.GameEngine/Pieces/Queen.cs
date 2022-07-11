using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            Square pos = board.FindPiece(this);
            Square latestMove = pos;

            while (latestMove.Col < GameSettings.BoardSize-1 && latestMove.Row < GameSettings.BoardSize-1)
            {
                latestMove = Square.At(latestMove.Row + 1, latestMove.Col + 1);
                moves.Add(latestMove);
            }
            
            latestMove = pos;
            
            while (latestMove.Col < GameSettings.BoardSize-1 && latestMove.Row > 0)
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
            
            while (latestMove.Col > 0 && latestMove.Row < GameSettings.BoardSize-1 )
            {
                latestMove = Square.At(latestMove.Row+1, latestMove.Col-1);
                moves.Add(latestMove);
            }
            
            for (var i = 0; i < GameSettings.BoardSize; i++)
                moves.Add(Square.At(pos.Row, i));

            for (var i = 0; i < GameSettings.BoardSize; i++)
                moves.Add(Square.At(i, pos.Col));

            //Get rid of our starting location.
            moves.RemoveAll(s => s == pos);
            
            return moves;
        }
    }
}