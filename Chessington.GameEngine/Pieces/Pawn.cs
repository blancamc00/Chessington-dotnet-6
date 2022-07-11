using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private readonly Piece[,] _board;
        public Pawn(Player player) 
            : base(player) { }

        public Square firstMove { set; get; }

        public Square lastPos { get; private set; }
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square pos = board.FindPiece(this);
            if (this.Player == Player.White)
            {
                Square move = new Square(pos.Row - 1, pos.Col);
                if (move.Row >= 0 && board.checkIfEmpty(move) && move.Row >= 0)
                {
                    yield return move;
                    if (this.numOfMoves == 0)
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
                
                moveToEat = Square.At(pos.Row, pos.Col + 1);
                if (moveToEat.Col < GameSettings.BoardSize-1 && moveToEat.Row < GameSettings.BoardSize-1 && moveToEat.Col >= 0 &&
                    moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player && Math.Abs(((Pawn)pieceThere).firstMove.Row - moveToEat.Row) == 2)
                    {
                        moveToEat = Square.At(pos.Row - 1, pos.Col + 1);
                        yield return moveToEat;
                    }
                }
                
                moveToEat = Square.At(pos.Row, pos.Col - 1);
                if (moveToEat.Col < GameSettings.BoardSize-1 && moveToEat.Row < GameSettings.BoardSize-1 && moveToEat.Col >= 0 &&
                    moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player && Math.Abs(((Pawn)pieceThere).firstMove.Row - moveToEat.Row) == 2)
                    {
                        moveToEat = Square.At(pos.Row - 1, pos.Col - 1);
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
                    if (this.numOfMoves == 0)
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
                
                moveToEat = Square.At(pos.Row, pos.Col - 1);
                if (moveToEat.Col < GameSettings.BoardSize-1 && moveToEat.Row < GameSettings.BoardSize-1 && moveToEat.Col >= 0 &&
                    moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player && Math.Abs(((Pawn)pieceThere).firstMove.Row - moveToEat.Row) == 2)
                    {
                        moveToEat = Square.At(pos.Row + 1, pos.Col - 1);
                        yield return moveToEat;
                    }
                }
                
                moveToEat = Square.At(pos.Row, pos.Col + 1);
                if (moveToEat.Col < GameSettings.BoardSize-1 && moveToEat.Row < GameSettings.BoardSize-1 && moveToEat.Col >= 0 &&
                    moveToEat.Row >= 0)
                {
                    Piece pieceThere = board.GetPiece(moveToEat);
                    if (pieceThere != null && pieceThere.Player != this.Player && Math.Abs(((Pawn)pieceThere).firstMove.Row - moveToEat.Row) == 2)
                    {
                        moveToEat = Square.At(pos.Row + 1, pos.Col + 1);
                        yield return moveToEat;
                    }
                }

            }
        }
    }
}