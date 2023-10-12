using Chess.Movers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess
{
    public class Mover
    {
        public Label? Figure { get; set; }
        private Grid board { get; set; }

        public ControlFigures Controller { get; set; }

        public Mover(Grid board)
        {
            this.Controller = new ControlFigures(board);
            this.board = board;
        }

        public bool MoveTo(Label toMove)
        {
            if (!Controller.PossibleMove(Figure.Content.ToString(), Figure.Name, toMove.Name))
            {
                return false;
            }

            toMove.Content = this.Figure.Content;
            this.Figure.Content = "";


            this.Figure = null;
            return true;
        }
    }
}
