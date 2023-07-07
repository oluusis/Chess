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
        private Grid board {  get; set; }

        public Mover(Grid board)
        {
            this.board = board;
        }

        public void MoveTo(Label toMove)
        {
            //if(this.Figure.Content.ToString() == "\u2659")
            //{
                toMove.Content = this.Figure.Content;
                this.Figure.Content = "";
            //}

            this.Figure = null;
        }

        //another part
        //private void MovePawn(bool isWhite)
        //{
        //    char column = Figure.Name[0];
        //    int row = Convert.ToInt32(Figure.Name[1]);

        //    if(isWhite)
        //    {
                
        //    }
        //}
    }
}
