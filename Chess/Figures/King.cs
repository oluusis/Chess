using Chess.Movers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures
{
    public class King
    {
        private ControlFigures control;

        public King(ControlFigures control) 
        {
            this.control = control;
        }
        public bool WhiteCastle()
        {
            if (control.WhiteKingMoved) return false;

            if (control.To == "G1" && control.ReturnPosition("H1").Content.ToString() == "\u2656" && control.ReturnPosition("F1").Content.ToString() == "")
            {
                control.WhiteKingMoved = true;
                control.ReturnPosition("H1").Content = "";
                control.ReturnPosition("F1").Content = "\u2656";
                return true;
            }

            if (control.To == "C1" && control.ReturnPosition("A1").Content.ToString() == "\u2656" && control.ReturnPosition("B1").Content.ToString() == "" && control.ReturnPosition("D1").Content.ToString() == "")
            {
                control.WhiteKingMoved = true;
                control.ReturnPosition("A1").Content = "";
                control.ReturnPosition("D1").Content = "♖";
                return true;
            }
            return false;
        }

        public bool BlackCastle()
        {
            if (control.BlackKingMoved) return false;

            if (control.To == "G8" &&  control.ReturnPosition("H8").Content.ToString() == "\u265C" && control.ReturnPosition("F8").Content.ToString() == "")
            {
                control.WhiteKingMoved = true;
                control.ReturnPosition("H8").Content = "";
                control.ReturnPosition("F8").Content = "\u265C";
                return true;
            }

            if (control.To == "C8" && control.ReturnPosition("A8").Content.ToString() == "\u265C" && control.ReturnPosition("B8").Content.ToString() == "" && control.ReturnPosition("D8").Content.ToString() == "")
            {
                control.WhiteKingMoved = true;
                control.ReturnPosition("A8").Content = "";
                control.ReturnPosition("D8").Content = "♖";
                return true;
            }
            return false;

        }
    }
}
