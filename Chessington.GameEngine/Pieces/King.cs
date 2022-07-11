using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square pos = board.FindPiece(this);
            var moves = new List<Square>();
            moves.Add(Square.At(pos.Col - 1, pos.Row + 1));
            moves.Add(Square.At(pos.Col - 1, pos.Row));
            moves.Add(Square.At(pos.Col - 1, pos.Row - 1));
            moves.Add(Square.At(pos.Col, pos.Row + 1));
            moves.Add(Square.At(pos.Col, pos.Row - 1));
            moves.Add(Square.At(pos.Col + 1, pos.Row + 1));
            moves.Add(Square.At(pos.Col + 1, pos.Row));
            moves.Add(Square.At(pos.Col + 1, pos.Row - 1));
            
            moves.RemoveAll(s => s.Col >= GameSettings.BoardSize || s.Row >= GameSettings.BoardSize
                                                                 || s.Col < 0 || s.Row < 0);
            
            return moves;
        }
    }
}