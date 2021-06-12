using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Label firstclicked;
        Label secondclicked;
        public static int score = 0;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.8);
            timer.Tick += runGame;

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (firstclicked != null && secondclicked != null)
                return;
            Label clickedLabel = sender as Label;
            if (clickedLabel == null)
                return;
            if (clickedLabel.Foreground == Brushes.Black)
                return;
            if (firstclicked == null)
            {
                firstclicked = clickedLabel;
                firstclicked.Foreground = Brushes.Black;
                return;
            }
            else if (secondclicked == null)
            {
                secondclicked = clickedLabel;
                secondclicked.Foreground = Brushes.Black;
            }
            if (firstclicked.Content.ToString() == secondclicked.Content.ToString())
            {
                firstclicked = null;
                secondclicked = null;
                score++;
                winWScores();
            }
           else timer.Start();
        }
        private void runGame(object sender, EventArgs e)
        {
            timer.Stop();
            
            firstclicked.Foreground = Brushes.LightBlue;
            secondclicked.Foreground = Brushes.LightBlue;
            firstclicked = null;
            secondclicked = null;
           
        }
        private void winWScores()
        {
            if (score == 4)
            {
                MessageBox.Show("You won!", "Winner");
                Close();
            }
        }
        
    }
}
