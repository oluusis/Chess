using Chess.Figures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace Chess
{
    public class SetupBoard
    {
        private Grid _board { get; set; }

        private ArrayList _figures { get; set; }

        private Mover _mover { get; set; }



        private readonly List<string> whiteFigures = new List<string> { "\u2655", "\u2654", "\u2657", "\u2656", "\u2658", "\u2659" };
        private readonly List<string> blackFigures = new List<string> { "\u265F", "\u265C", "\u265E", "\u265D", "\u265A", "\u265B" };

        public SetupBoard(Grid board, ArrayList figures)
        {
            this._board = board;
            this._figures = figures;
            this._mover = new Mover(_board);
            SetUpFigures();
            this.Side = true;
        }


        private void SetUpFigures()
        {
            for (int i = 0; i < _board.Children.Count; i++)
            {
                Label label = _board.Children[i] as Label;

                if (label.Name.Substring(1, 1) == "7")
                {
                    label.Content = "\u265F";
                    //_figures.Add(new Pawn(label, false));
                }
                else if (label.Name.Substring(1, 1) == "2")
                {
                    label.Content = "\u2659";
                    //_figures.Add(new Pawn(label, true));
                }
                else
                {

                    switch (label.Name)
                    {
                        case "A8":
                            label.Content = "\u265C";
                            break;
                        case "H8":
                            label.Content = "\u265C";
                            break;
                        case "A1":
                            label.Content = "\u2656";
                            break;
                        case "H1":
                            label.Content = "\u2656";
                            break;
                        case "B8":
                            label.Content = "\u265E";
                            break;
                        case "G8":
                            label.Content = "\u265E";
                            break;
                        case "B1":
                            label.Content = "\u2658";
                            break;
                        case "G1":
                            label.Content = "\u2658";
                            break;
                        case "C8":
                            label.Content = "\u265D";
                            break;
                        case "F8":
                            label.Content = "\u265D";
                            break;
                        case "C1":
                            label.Content = "\u2657";
                            break;
                        case "F1":
                            label.Content = "\u2657";
                            break;
                        case "E8":
                            label.Content = "\u265A";
                            break;
                        case "E1":
                            label.Content = "\u2654";
                            break;
                        case "D8":
                            label.Content = "\u265B";
                            break;
                        case "D1":
                            label.Content = "\u2655";
                            break;
                        default:
                            label.Content = "";
                            break;
                    }
                }

                label.MouseLeftButtonUp += OnClickSquare;


            }
        }

        public bool Side { get; set; }
        public void OnClickSquare(object sender, EventArgs e)
        {

            if (sender.GetType().ToString() != "System.Windows.Controls.Label") return;

            Label? clickedLabel = sender as Label;

            if (clickedLabel?.Content.ToString() == "" && this._mover.Figure == null) return;


            if (this._mover.Figure != null)
            {
                TryMove(clickedLabel);
            }
            else
            {
                //Control who playing
                if (whiteFigures.Contains(clickedLabel.Content.ToString()) != Side) return;

                this._mover.Figure = clickedLabel;
            }


        }

        //Control this.To not killing yours
        public void TryMove(Label? clickedLabel)
        {
            if (Side)
            {
                if (whiteFigures.Contains(clickedLabel?.Content))
                {
                    this._mover.Figure = clickedLabel;
                    return;
                }
            }
            else
            {
                if (blackFigures.Contains(clickedLabel?.Content))
                {
                    this._mover.Figure = clickedLabel;
                    return;
                }
            }

            //Moving
            if (this._mover.MoveTo(clickedLabel))
            {
                Side = !Side;
            }
        }


    }
}
