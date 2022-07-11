using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square pos = board.FindPiece(this);
            if (this.Player == Player.White)
            {
                Square move = new Square(pos.Row - 1, pos.Col);
                yield return move;
                if (pos.Row == 7)
                {
                    yield return new Square(pos.Row - 2, pos.Col);
                }
            }
            else
            {
                Square move = new Square(pos.Row + 1, pos.Col);
                yield return move;
                if (pos.Row == 1)
                {
                    yield return new Square(pos.Row + 2, pos.Col);
                }
            }
        }
    }
}