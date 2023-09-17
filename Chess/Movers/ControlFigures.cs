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
        private readonly List<char> _xDirections = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };


        public ControlFigures(Grid board)
        {
            this._board = board;
        }


        public bool PossibleMove(string Figure, string from, string to)
        {
            switch (Figure)
            {
                case "\u2659":
                    return ValidatePawn(from, to, true);

                case "\u2658":
                    return ValidateKnight(from, to);

                case "\u2656":
                    return ValidateRock(from, to);

                case "\u2657":
                    return ValidateBishop(from, to);

                case "\u2655":
                    return ValidateQueen(from, to);


                default:
                    break;
            }
            return true;
        }

        public Label ReturnPosition(string directions)
        {
            Object obj = _board.FindName(directions);
            return (Label)obj;
        }

        public bool ValidatePawn(string from, string to, bool isWhite)
        {
            if (isWhite)
            {
                if (ReturnPosition(to).Content != "")
                {
                    if (Math.Pow(Convert.ToInt16(to[1]) - Convert.ToInt16(from[1]), 2) == 1 && Math.Pow(_xDirections.IndexOf(to[0]) - _xDirections.IndexOf(from[0]), 2) == 1)
                    {
                        return true;
                    }
                }

                if (from[0] == to[0] && (Convert.ToInt16(from[1]) - Convert.ToInt16(to[1]) == -1))
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

        public bool ValidateQueen(string from, string to)
        {
            if (ValidateRock(from, to) || ValidateBishop(from, to))
            {
                return true;
            }
            return false;
        }

        //kvůli královi musím storovat všechny políčka který figurky napadaj

        public bool ValidateKnight(string from, string to)
        {
            _mark = true;
            string possibleDir = "";
            int row = 0;
            char column = '.';


            for (int i = 0; i < 2; i++)
            {
                //vertikal validation
                row = ChangeMark(Convert.ToInt32(from[1].ToString()), 2);


                if (_xDirections.IndexOf(from[0]) + 1 < _xDirections.Count)
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


        public bool ValidateRock(string from, string to)
        {
            string columns = from[0].ToString();

            for (int i = Convert.ToInt32(from[1].ToString()) + 1; i < 9; i++)
            {
                columns = columns[0] + i.ToString();
                if (columns == to)
                {
                    return true;
                }
                else if (ReturnPosition(columns).Content != "")
                {
                    break;
                }
            }

            columns = from[0].ToString();

            for (int i = Convert.ToInt32(from[1].ToString()) - 1; i > 0; i--)
            {
                columns = columns[0] + i.ToString();
                if (columns == to)
                {
                    return true;
                }
                else if (ReturnPosition(columns).Content != "")
                {
                    break;
                }
            }

            columns = from;

            for (int i = _xDirections.IndexOf(from[0]) + 1; i < 8; i++)
            {
                columns = _xDirections[i] + from[1].ToString();
                if (columns == to)
                {
                    return true;
                }
                else if (ReturnPosition(columns).Content != "")
                {
                    break;
                }
            }

            columns = from;

            for (int i = _xDirections.IndexOf(from[0]) - 1; i > 0; i--)
            {
                columns = _xDirections[i] + from[1].ToString();
                if (columns == to)
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


        public bool ValidateBishop(string from, string to)
        {
            string currentCell = "";
            int a = _xDirections.IndexOf(from[0]);

            //left up
            for (int i = Convert.ToInt32(from[1].ToString()) + 1; i < 9; i++)
            {
                if(from == to)
                {
                    continue;
                }


                if(a == 0)
                {                  
                    currentCell = _xDirections[a] + i.ToString();
                    a--;
                }
                else if (a > 0)
                {
                    a--;
                    currentCell = _xDirections[a] + i.ToString();
                    
                }
                
                if (currentCell == to)
                {
                    return true;
                }
                else if (ReturnPosition(currentCell).Content != "")
                {
                    break;
                }                          
            }

            currentCell = "";
            a = _xDirections.IndexOf(from[0]);

            //left down
            for (int i = Convert.ToInt32(from[1].ToString()) - 1; i > 0; i--)
            {
                if (from == to)
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
                
                if (currentCell == to)
                {
                    return true;
                }
                else if (ReturnPosition(currentCell).Content != "")
                {
                    break;
                }
                
                    
            }

            currentCell = "";
            a = _xDirections.IndexOf(from[0]);

            //right up
            for (int i = Convert.ToInt32(from[1].ToString()) + 1; i < 9; i++)
            {
                if (from == to)
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
                    if (currentCell == to)
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
            a = _xDirections.IndexOf(from[0]);

            //right down
            for (int i = Convert.ToInt32(from[1].ToString()) - 1; i > 0; i--)
            {

                if (from == to)
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
                    if (currentCell == to)
                    {
                        return true;
                    }
                    else if (ReturnPosition(currentCell).Content != "")
                    {
                        break;
                    }
                }
                catch { 
                }
              
               

            }

            return false;
        }



    }
}
