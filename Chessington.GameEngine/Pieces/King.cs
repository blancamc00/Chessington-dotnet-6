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
            var move = new Square();
            
            move = Square.At(pos.Row - 1, pos.Col + 1);
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                 move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Row - 1, pos.Col));
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Row - 1, pos.Col - 1));
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Row, pos.Col + 1));
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Row, pos.Col - 1));
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Row + 1, pos.Col + 1));
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Row + 1, pos.Col));
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Row + 1, pos.Col - 1));
            if (move.Col < GameSettings.BoardSize  && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            
            //Castling
            if (this.numOfMoves == 0)
            {
                bool cond = true;
                if (board.GetPiece(Square.At(pos.Row, 7)) != null && board.GetPiece(Square.At(pos.Row, 7)).numOfMoves == 0)
                {
                    
                    
                    for (int i = 5; i < 7; i++)
                    {
                        if(board.GetPiece(Square.At(pos.Row, i)) != null) cond = false;
                    }


                    if (cond)
                    {
                        move = Square.At(pos.Row, pos.Col + 2);
                        moves.Add(move);
                    }
                }
                
                cond = true;
                if (board.GetPiece(Square.At(pos.Row, 0)) != null && board.GetPiece(Square.At(pos.Row, 0)).numOfMoves == 0)
                {
                    for (int i = 0; i < pos.Col; i++)
                    {
                        if(board.GetPiece(Square.At(pos.Row, i)) != null) cond = false;
                    }

                    if (cond)
                    {
                        move = Square.At(pos.Row, pos.Col - 2);
                        moves.Add(move);
                    }
                }
            }
            
            
            moves.RemoveAll(s => s.Col >= GameSettings.BoardSize || s.Row >= GameSettings.BoardSize
                                                                 || s.Col < 0 || s.Row < 0);
            
            return moves;
        }
    }
}