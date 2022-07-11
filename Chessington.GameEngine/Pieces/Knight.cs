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
            var move = new Square();
            
            
            move = (Square.At(pos.Row-2 , pos.Col + 1));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                 move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }

            move = (Square.At(pos.Row-2 , pos.Col - 1));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }

            move = (Square.At(pos.Row+2 , pos.Col + 1));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }

            move = (Square.At(pos.Row+2 , pos.Col - 1));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }

            move = (Square.At(pos.Row+1 , pos.Col + 2));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }

            move = (Square.At(pos.Row-1 , pos.Col + 2));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }

            move = (Square.At(pos.Row+1 , pos.Col - 2));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }

            move = (Square.At(pos.Row-1 , pos.Col - 2));
            if (move.Col < GameSettings.BoardSize && move.Row < GameSettings.BoardSize && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }


            //moves.RemoveAll(move => move.Col >= GameSettings.BoardSize || move.Row >= GameSettings.BoardSize
            //                                                          || move.Col < 0 || move.Row < 0);
            
            return moves;
        }
    }
}