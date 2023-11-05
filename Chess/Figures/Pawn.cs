using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;
using Chess.Movers;

namespace Chess.Figures
{
    public class Pawn
    {
        private ControlFigures control { get; set; }

        public Pawn(ControlFigures control)
        {
            this.control = control;
        }

        public bool ValidateWhite()
        {
            if (control.From[0] == control.To[0] && (Convert.ToInt16(control.From[1]) - Convert.ToInt16(control.To[1]) == -1))
            {
                return true;
            }
            else if (control.From[0] == control.To[0] && control.From[1] == '2' && control.To[1] == '4')
            {
                if (control.ReturnPosition(control.From[0] + "3").Content == "") return true;

            }
            return false;
        }

        public bool ValidateTaking(int side)
        {
            if (Convert.ToInt16(control.To[1]) - Convert.ToInt16(control.From[1]) == side && Math.Pow(control._xDirections.IndexOf(control.To[0]) - control._xDirections.IndexOf(control.From[0]), 2) == 1)
                return true;
            return false;

        }

        public bool ValidateBlack()
        {
            if (control.From[0] == control.To[0] && (Convert.ToInt16(control.From[1]) - Convert.ToInt16(control.To[1]) == 1))
            { 
                return true;
            }
            else if (control.From[0] == control.To[0] && control.From[1] == '7' && control.To[1] == '5')
            {
                if (control.ReturnPosition(control.From[0] + "6").Content == "") return true;
            }
            return false;
        }
        
    }
}
