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
            
            move = Square.At(pos.Col - 1, pos.Row + 1);
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                 move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Col - 1, pos.Row));
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Col - 1, pos.Row - 1));
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Col, pos.Row + 1));
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Col, pos.Row - 1));
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Col + 1, pos.Row + 1));
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Col + 1, pos.Row));
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            move = (Square.At(pos.Col + 1, pos.Row - 1));
            if (move.Col < GameSettings.BoardSize -1 && move.Row < GameSettings.BoardSize -1 && move.Col >= 0 &&
                move.Row >= 0)
            {
                if (board.checkIfEmpty(move) || board.GetPiece(move).Player != this.Player) moves.Add(move);
            }
            
            moves.RemoveAll(s => s.Col >= GameSettings.BoardSize || s.Row >= GameSettings.BoardSize
                                                                 || s.Col < 0 || s.Row < 0);
            
            return moves;
        }
    }
}