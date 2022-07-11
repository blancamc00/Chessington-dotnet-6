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
            var move = new Square();

            for (var i = 0; i < 8; i++)
            {
                move = Square.At(pos.Row, i);
                if (board.checkIfEmpty(move)) moves.Add(move);
                else if (board.GetPiece(move).Player == this.Player && move != pos) break;
                else if (board.GetPiece(move).Player != this.Player && move != pos)
                {
                    moves.Add(move);
                    break;
                }
            }


            for (var i = 0; i < 8; i++)
            {
                move = Square.At(i, pos.Col);
                if (board.checkIfEmpty(move)) moves.Add(move);
                else if (board.GetPiece(move).Player == this.Player && move != pos) break;
                else if (board.GetPiece(move).Player != this.Player && move != pos)
                {
                    moves.Add(move);
                    break;
                }
            }

            //Get rid of our starting location.
            //moves.RemoveAll(s => s == pos);
            return moves;
        }
    }
}