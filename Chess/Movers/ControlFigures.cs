using Chess.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace Chess.Movers
{
    public class ControlFigures
    {
        private Grid? _board { get; set; }
        public readonly List<char> _xDirections = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

        public bool WhiteKingMoved = false;
        public bool BlackKingMoved = false;    

        private List<string> _allAttackedSquaresFromBlack = new List<string>();
        private List<string> _allAttackedSquaresFromWhite = new List<string>();

        private Pawn pawn { get; set; }
        public King king { get; set; }  

        public ControlFigures(Grid board)
        {
            this._board = board;
            this.pawn = new Pawn(this);
            this.king = new King(this);
        }

        public string From { get; set; }
        public string To { get; set; }

        public bool PossibleMove(string Figure, string from, string to)
        {
            this.From = from;
            this.To = to;

            switch (Figure)
            {
                case "\u2659":
                    return ValidateWhitePawn();

                case "\u2658":
                    return ValidateKnight();

                case "\u2656":
                    return ValidateRock();

                case "\u2657":
                    return ValidateBishop();

                case "\u2655":
                    return ValidateQueen();

                case "\u2654":
                    return ValidateKing(true);


                case "\u265F":
                    return ValidateBlackPawn();

                case "\u265B":
                    return ValidateQueen();

                case "\u265A":
                    return ValidateKing(false);

                case "\u265D":
                    return ValidateBishop();

                case "\u265E":
                    return ValidateKnight();

                case "\u265C":
                    return ValidateRock();


            }
            return false;
        }

        public Label ReturnPosition(string directions)
        {
            Object obj = _board.FindName(directions);
            return (Label)obj;
        }

        public bool ValidateWhitePawn()
        {
            if (ReturnPosition(this.To).Content != "")
            {
                if (pawn.ValidateTaking(1))
                {
                    return true;
                }
            }
            else
            {
                return pawn.ValidateWhite();
            }
            return false;
        }

        public bool ValidateBlackPawn()
        {
            if (ReturnPosition(this.To).Content != "")
            {
                if (pawn.ValidateTaking(-1))
                {
                    return true;
                }
            }
            else
            {
                return pawn.ValidateBlack();
            }
            return false;
        }

        private bool _mark;

        private int ChangeMark(int N1, int N2)
        {
            if (_mark)
            {
                _mark = false;
                return N1 + N2;
            }
            _mark = true;
            return N1 - N2;
        }

        public bool ValidateQueen()
        {
            if (ValidateRock() || ValidateBishop())
            {
                return true;
            }
            return false;
        }

        //kvůli královi musím storovat všechny políčka který figurky napadaj

        public bool ValidateKnight()
        {
            _mark = true;
            string possibleDir = "";
            int row = 0;
            char column = '.';


            for (int i = 0; i < 2; i++)
            {
                //vertikal validation
                row = ChangeMark(Convert.ToInt32(this.From[1].ToString()), 2);


                if (_xDirections.IndexOf(this.From[0]) + 1 < _xDirections.Count)
                {
                    column = _xDirections[_xDirections.IndexOf(this.From[0]) + 1];
                }

                possibleDir = column.ToString() + row.ToString();

                if (this.To == possibleDir)
                {
                    return true;
                }


                if (_xDirections.IndexOf(this.From[0]) - 1 > -1)
                {
                    column = _xDirections[_xDirections.IndexOf(this.From[0]) - 1];
                }

                possibleDir = column.ToString() + row.ToString();

                if (this.To == possibleDir)
                {
                    return true;
                }


                //Horizontal validation
                row = ChangeMark(Convert.ToInt32(this.From[1].ToString()), 1);

                if (_xDirections.IndexOf(this.From[0]) + 2 < _xDirections.Count)
                {
                    column = _xDirections[_xDirections.IndexOf(this.From[0]) + 2];
                }

                possibleDir = column.ToString() + row.ToString();

                if (this.To == possibleDir)
                {
                    return true;
                }

                if (_xDirections.IndexOf(this.From[0]) - 2 > -1)
                {
                    column = _xDirections[_xDirections.IndexOf(this.From[0]) - 2];
                }

                possibleDir = column.ToString() + row.ToString();

                if (this.To == possibleDir)
                {
                    return true;
                }

                _mark = !_mark;
            }

            return false;
        }


        public bool ValidateRock()
        {
            string columns = this.From[0].ToString();

            for (int i = Convert.ToInt32(this.From[1].ToString()) + 1; i < 9; i++)
            {
                columns = columns[0] + i.ToString();
                if (columns == this.To)
                {
                    return true;
                }
                else if (ReturnPosition(columns).Content != "")
                {
                    break;
                }
            }

            columns = this.From[0].ToString();

            for (int i = Convert.ToInt32(this.From[1].ToString()) - 1; i > 0; i--)
            {
                columns = columns[0] + i.ToString();
                if (columns == this.To)
                {
                    return true;
                }
                else if (ReturnPosition(columns).Content != "")
                {
                    break;
                }
            }

            columns = this.From;

            for (int i = _xDirections.IndexOf(this.From[0]) + 1; i < 8; i++)
            {
                columns = _xDirections[i] + this.From[1].ToString();
                if (columns == this.To)
                {
                    return true;
                }
                else if (ReturnPosition(columns).Content != "")
                {
                    break;
                }
            }

            columns = this.From;

            for (int i = _xDirections.IndexOf(this.From[0]) - 1; i > 0; i--)
            {
                columns = _xDirections[i] + this.From[1].ToString();
                if (columns == this.To)
                {
                    return true;
                }
                else if (ReturnPosition(columns).Content != "")
                {
                    break;
                }
            }

            return false;
        }


        public bool ValidateBishop()
        {
            string currentCell = "";
            int a = _xDirections.IndexOf(this.From[0]);

            //left up
            for (int i = Convert.ToInt32(this.From[1].ToString()) + 1; i < 9; i++)
            {
                if (this.From == this.To)
                {
                    continue;
                }


                if (a == 0)
                {
                    currentCell = _xDirections[a] + i.ToString();
                    a--;
                }
                else if (a > 0)
                {
                    a--;
                    currentCell = _xDirections[a] + i.ToString();

                }

                if (currentCell == this.To)
                {
                    return true;
                }
                else if (ReturnPosition(currentCell).Content != "")
                {
                    break;
                }
            }

            currentCell = "";
            a = _xDirections.IndexOf(this.From[0]);

            //left down
            for (int i = Convert.ToInt32(this.From[1].ToString()) - 1; i > 0; i--)
            {
                if (this.From == this.To)
                {
                    continue;
                }


                if (a == 0)
                {
                    currentCell = _xDirections[a] + i.ToString();
                    a--;
                }
                else if (a > 0)
                {
                    a--;
                    currentCell = _xDirections[a] + i.ToString();

                }

                if (currentCell == this.To)
                {
                    return true;
                }
                else if (ReturnPosition(currentCell).Content != "")
                {
                    break;
                }


            }

            currentCell = "";
            a = _xDirections.IndexOf(this.From[0]);

            //right up
            for (int i = Convert.ToInt32(this.From[1].ToString()) + 1; i < 9; i++)
            {
                if (this.From == this.To)
                {
                    continue;
                }

                if (a == 8)
                {
                    currentCell = _xDirections[a] + i.ToString();
                    a++;
                }
                else if (a < 7)
                {
                    a++;
                    currentCell = _xDirections[a] + i.ToString();

                }

                try
                {
                    if (currentCell == this.To)
                    {
                        return true;
                    }
                    else if (ReturnPosition(currentCell).Content != "")
                    {
                        break;
                    }
                }
                catch
                {
                }




            }

            currentCell = "";
            a = _xDirections.IndexOf(this.From[0]);

            //right down
            for (int i = Convert.ToInt32(this.From[1].ToString()) - 1; i > 0; i--)
            {

                if (this.From == this.To)
                {
                    continue;
                }

                if (a == 8)
                {
                    a++;
                    currentCell = _xDirections[a] + i.ToString();

                }
                else if (a < 7)
                {
                    a++;
                    currentCell = _xDirections[a] + i.ToString();

                }

                try
                {
                    if (currentCell == this.To)
                    {
                        return true;
                    }
                    else if (ReturnPosition(currentCell).Content != "")
                    {
                        break;
                    }
                }
                catch
                {
                }



            }

            return false;
        }

        public bool ValidateKing(bool isWhite)
        {
            int fromColumn = _xDirections.IndexOf(this.From[0]);
            int toColumn = _xDirections.IndexOf(this.To[0]);

            int fromRow = Convert.ToInt32(this.From[1]);
            int toRow = Convert.ToInt32(this.To[1]);

            if (fromColumn - toColumn <= 1 && fromColumn - toColumn >= -1 && fromRow - toRow <= 1 && fromRow - toRow >= -1)
            {
                this.WhiteKingMoved = true;
                return true;
            }

           if(isWhite) return king.WhiteCastle();
            return king.BlackCastle();
        }

    }
}
