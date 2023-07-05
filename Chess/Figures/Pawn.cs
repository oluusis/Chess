using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures
{
    public class Pawn
    {
        // Position
        private Label Square { get; set; }

        // true - white, false - black
        public bool Side { get; private set; }

        // false - was killed
        public bool IsInGame { get; set; }  

        public Pawn(Label square, bool side)
        {
            this.Square = square;
            this.Side = side;
        }

        public void Move(Label square)
        {
            this.Square = square;
        }

        public void IsValid(Label square)
        {
            if (Side)
            {

            }
        }
        
    }
}
