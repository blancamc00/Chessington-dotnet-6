using System;
using System.Collections.Generic;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class Board
    {
        private readonly Piece[,] _board;
        public Player CurrentPlayer { get; private set; }
        public IList<Piece> CapturedPieces { get; private set; } 

        public Board()
            : this(Player.White) { }

        public Board(Player currentPlayer, Piece[,] boardState = null)
        {
            _board = boardState ?? new Piece[GameSettings.BoardSize, GameSettings.BoardSize]; 
            CurrentPlayer = currentPlayer;
            CapturedPieces = new List<Piece>();
        }

        public void AddPiece(Square square, Piece pawn)
        {
            _board[square.Row, square.Col] = pawn;
        }
    
        public Piece GetPiece(Square square)
        {
            return _board[square.Row, square.Col];
        }
        
        public Square FindPiece(Piece piece)
        {
            for (var row = 0; row < GameSettings.BoardSize; row++)
                for (var col = 0; col < GameSettings.BoardSize; col++)
                    if (_board[row, col] == piece)
                        return Square.At(row, col);

            throw new ArgumentException("The supplied piece is not on the board.", "piece");
        }

        public bool checkIfEmpty(Square pos)
        {
            if (_board[pos.Row, pos.Col] != null)
            {
                return false;
            }
            else{ return true;}
        }

        public void MovePiece(Square from, Square to)
        {
            var movingPiece = _board[from.Row, from.Col];
            if (movingPiece == null) { return; }

            if (movingPiece.Player != CurrentPlayer)
            {
                throw new ArgumentException("The supplied piece does not belong to the current player.");
            }

            //If the space we're moving to is occupied, we need to mark it as captured.
            if (_board[to.Row, to.Col] != null)
            {
                OnPieceCaptured(_board[to.Row, to.Col]);
            }

            if(movingPiece.GetType().BaseType.Name == "Pawn")
            {
                ((Pawn)movingPiece).firstMove = Square.At(from.Row, from.Col);
                //Move the piece and set the 'from' square to be empty.

            }

            movingPiece.numOfMoves += 1;
            
            _board[to.Row, to.Col] = movingPiece;
            _board[from.Row, from.Col] = null;

            if (_board[to.Row + 1, to.Col] != null && _board[to.Row + 1, to.Col].GetType().BaseType.Name == "Pawn")
            {
                if (((Pawn)movingPiece).firstMove.Row - to.Row == -1)
                {
                    _board[to.Row + 1, to.Col] = null;
                }
            }
            
            if (_board[to.Row - 1, to.Col] != null && _board[to.Row - 1, to.Col].GetType().BaseType.Name == "Pawn")
            {
                if (((Pawn)movingPiece).firstMove.Row - to.Row == 1)
                {
                    _board[to.Row - 1, to.Col] = null;
                }
            }
            
            //Castling
            if (movingPiece.GetType().BaseType.Name == "King" && Math.Abs(from.Col - to.Col) == 2)
            {
                if ((to.Col - from.Col) / 2 > 0)
                {
                    _board[to.Row, to.Col - (to.Col-from.Col)/2] = _board[from.Row, 7];
                    _board[from.Row, 7] = null;
                }
                else
                {
                    _board[to.Row, to.Col - (to.Col-from.Col)/2] = _board[from.Row, 0];
                    _board[from.Row, 0] = null;
                }
            }

            if (movingPiece.GetType().BaseType.Name == "Pawn" && (to.Row == 0 || to.Row == 7))
            {
                _board[to.Row, to.Col] = new Queen(movingPiece.Player);
            }


            //Indicate if a pawn has moved two squares in the last move.
            /*
            var pieceThatMoved = _board[to.Row, to.Col];
            if (pieceThatMoved.GetType().BaseType.Name == "Pawn")
            {
                if (to.Row - from.Row == 2 || to.Row - from.Row == -2)
                {
                    _board[to.Row, to.Col].firstMove
                }
            }
            */

            CurrentPlayer = movingPiece.Player == Player.White ? Player.Black : Player.White;
            OnCurrentPlayerChanged(CurrentPlayer);
        }

        public bool CheckIfYourChecking(Board board, Player player)
        {
            List<Square> possibleMoves = new List<Square>();
            for (int i = 0; i < GameSettings.BoardSize; i++)
            {
                for (int j = 0; j < GameSettings.BoardSize; j++)
                {
                    if(board[i,j].player == player)
                }
            }
        }
        
        public delegate void PieceCapturedEventHandler(Piece piece);
        
        public event PieceCapturedEventHandler PieceCaptured;

        protected virtual void OnPieceCaptured(Piece piece)
        {
            var handler = PieceCaptured;
            handler?.Invoke(piece);
        }

        public delegate void CurrentPlayerChangedEventHandler(Player player);

        public event CurrentPlayerChangedEventHandler CurrentPlayerChanged;

        protected virtual void OnCurrentPlayerChanged(Player player)
        {
            var handler = CurrentPlayerChanged;
            handler?.Invoke(player);
        }
    }
}
