using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ArrayList Figures { get; set; }  

        public MainWindow()
        {
            InitializeComponent();
            Grid myGrid = ChessBoard;

            myGrid.Children.Contains(A8);

            //
            MainWindow mainWindow = this;
            Label label = mainWindow.A8;
            label.Content = "\u2654";

            Figures = new ArrayList();
            SetupBoard board = new SetupBoard(ChessBoard, Figures);
            

        }

    }
}
