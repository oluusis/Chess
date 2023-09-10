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
        private readonly List<char> _xDirections = new List<char>() { 'A','B', 'C', 'D', 'E', 'F', 'G', 'H'};


        public ControlFigures(Grid board) 
        { 
            this._board = board;
        }

        
        public bool PossibleMove(string Figure, string from, string to)
        {
            switch (Figure)
            {
                case "\u2659":
                    return PawnValidation(from, to, true);

                case "\u2658":
                    return KnightValidation(from, to);


                default:
                    break;
            }
            return true;
        }

        public Label ReturnPosition(string directions)
        {
            Object obj = _board.FindName(directions);
            return(Label)obj;
        }

        public bool PawnValidation(string from, string to, bool isWhite)
        {
            if (isWhite)
            {
                if(ReturnPosition(to).Content != "")
                {
                    if (Math.Pow(Convert.ToInt16(to[1]) - Convert.ToInt16(from[1]),2) == 1 && Math.Pow(_xDirections.IndexOf(to[0]) - _xDirections.IndexOf(from[0]),2) == 1)
                    {
                        return true;
                    }
                }

                if (from[0] == to[0] && (Convert.ToInt16(from[1]) - Convert.ToInt16(to[1]) == -1 )) 
                {
                    if (ReturnPosition(to).Content == "")
                    {
                        return true;
                    }                                      
                }
                else if (from[1] == '2' && to[1] == '4')
                {

                    if (ReturnPosition(from[0] + "3").Content == "")
                    {
                        if (ReturnPosition(to).Content == "")
                        {
                            return true;
                        }
                    }
                }
                return false;
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

        //kvůli královi musím storovat všechny políčka který figurky napadaj

        public bool KnightValidation(string from, string to)
        {
            _mark = true;
            string possibleDir = "";
            int row = 0;
            char column = '.';


            for (int i = 0; i < 2; i++)
            {
                //vertikal validation
                row = ChangeMark(Convert.ToInt32(from[1].ToString()), 2);
                

                if (_xDirections.IndexOf(from[0]) +1 < _xDirections.Count)
                {
                    column = _xDirections[_xDirections.IndexOf(from[0]) + 1];
                }

                possibleDir = column.ToString() + row.ToString();

                if (to == possibleDir)
                {
                    return true;
                }


                if (_xDirections.IndexOf(from[0]) - 1 > -1)
                {
                    column = _xDirections[_xDirections.IndexOf(from[0]) - 1];
                }

                possibleDir = column.ToString() + row.ToString();

                if (to == possibleDir)
                {
                    return true;
                }


                //Horizontal validation
                row = ChangeMark(Convert.ToInt32(from[1].ToString()), 1);

                if (_xDirections.IndexOf(from[0]) + 2 < _xDirections.Count)
                {
                    column = _xDirections[_xDirections.IndexOf(from[0]) + 2];
                }

                possibleDir = column.ToString() + row.ToString();

                if (to == possibleDir)
                {
                    return true;
                }

                if (_xDirections.IndexOf(from[0]) - 2 > -1)
                {
                    column = _xDirections[_xDirections.IndexOf(from[0]) - 2];
                }

                possibleDir = column.ToString() + row.ToString();

                if (to == possibleDir)
                {
                    return true;
                }

                _mark = !_mark;
            }

            return false;
        }

    }
}
