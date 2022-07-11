using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square pos = board.FindPiece(this);
            
            var moves = new List<Square>();

            for (var i = 0; i < 8; i++)
                moves.Add(Square.At(pos.Row, i));

            for (var i = 0; i < 8; i++)
                moves.Add(Square.At(i, pos.Col));

            //Get rid of our starting location.
            moves.RemoveAll(s => s == pos);
            return moves;
        }
    }
}