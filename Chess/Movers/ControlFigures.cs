using System;
using System.Collections.Generic;
using System.Linq;
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
                 
                default:
                    break;
            }
            return true;
        }


        public bool PawnValidation(string from, string to, bool isWhite)
        {
            if (isWhite)
            {
                Object a = _board.FindName(to);
                Label toL = (Label)a;

                if (from[0] == to[0] && (Convert.ToInt16(from[1]) - Convert.ToInt16(to[1]) == -1 || from[1] == '2' && to[1] == '4')) // ještě dořešit přeskakování figurek
                {
                    
                    
                    if(toL.Content == "")
                    {
                        return true;
                    }
                    
                }
                return false;
            }
            return false;
            
        }
    }
}
