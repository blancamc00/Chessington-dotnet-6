using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square pos = board.FindPiece(this);
            var moves = new List<Square>();
            moves.Add(Square.At(pos.Row-2 , pos.Col + 1));
            moves.Add(Square.At(pos.Row-2 , pos.Col - 1));
            moves.Add(Square.At(pos.Row+2 , pos.Col + 1));
            moves.Add(Square.At(pos.Row+2 , pos.Col - 1));
            moves.Add(Square.At(pos.Row+1 , pos.Col + 2));
            moves.Add(Square.At(pos.Row-1 , pos.Col + 2));
            moves.Add(Square.At(pos.Row+1 , pos.Col - 2));
            moves.Add(Square.At(pos.Row-1 , pos.Col - 2));
            
            moves.RemoveAll(s => s.Col >= GameSettings.BoardSize || s.Row >= GameSettings.BoardSize
                    || s.Col < 0 || s.Row < 0);
            
            return moves;
        }
    }
}