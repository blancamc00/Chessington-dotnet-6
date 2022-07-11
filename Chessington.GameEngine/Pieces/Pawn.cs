using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private readonly Piece[,] _board;
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square pos = board.FindPiece(this);
            if (this.Player == Player.White)
            {
                Square move = new Square(pos.Row - 1, pos.Col);
                if (board.checkIfEmpty(move))
                {
                    yield return move;
                    if (pos.Row == 7)
                    {
                        move = Square.At(pos.Row - 2, pos.Col);
                        if (board.checkIfEmpty(move)) yield return move;
                    }
                }

            }
            else
            {
                Square move = new Square(pos.Row + 1, pos.Col);
                if (board.checkIfEmpty(move))
                {
                    yield return move;
                    if (pos.Row == 1)
                    {
                        move = Square.At(pos.Row + 2, pos.Col);
                        if (board.checkIfEmpty(move)) yield return move;
                    }
                }
                
            }
        }
    }
}