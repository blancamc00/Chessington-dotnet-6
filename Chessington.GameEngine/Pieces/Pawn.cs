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
                if (move.Row >= 0 && board.checkIfEmpty(move) && move.Row >= 0)
                {
                    yield return move;
                    if (pos.Row == 7)
                    {
                        move = Square.At(pos.Row - 2, pos.Col);
                        if (move.Row >= 0 && board.checkIfEmpty(move)) yield return move;
                    }
                }

                var moveToEat = Square.At(pos.Row - 1, pos.Col - 1);
                if (moveToEat.Col < GameSettings.BoardSize-1 && moveToEat.Row < GameSettings.BoardSize-1 && moveToEat.Col >= 0 &&
                    moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player)
                    {
                        yield return moveToEat;
                    }
                }

                moveToEat = Square.At(pos.Row - 1, pos.Col + 1);
                if (moveToEat.Col < GameSettings.BoardSize-1 && moveToEat.Row < GameSettings.BoardSize-1 && moveToEat.Col >= 0 &&
                    moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player)
                    {
                        yield return moveToEat;
                    }
                }

            }
            else
            {
                Square move = new Square(pos.Row + 1, pos.Col);
                if (move.Row <8 && board.checkIfEmpty(move))
                {
                    yield return move;
                    if (pos.Row == 1)
                    {
                        move = Square.At(pos.Row + 2, pos.Col);
                        if (move.Row < 8 && board.checkIfEmpty(move)) yield return move;
                    }
                }
                
                var moveToEat = Square.At(pos.Row + 1, pos.Col + 1);
                if (moveToEat.Col < GameSettings.BoardSize - 1 && moveToEat.Row < GameSettings.BoardSize - 1 &&
                    moveToEat.Col >= 0 && moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player)
                    {
                        yield return moveToEat;
                    }
                }

                moveToEat = Square.At(pos.Row + 1, pos.Col - 1);
                if (moveToEat.Col < GameSettings.BoardSize - 1 && moveToEat.Row < GameSettings.BoardSize - 1 &&
                    moveToEat.Col >= 0 && moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player)
                    {
                        yield return moveToEat;
                    }
                }

            }
        }
    }
}