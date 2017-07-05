using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        bool p1w = true, p2w = true;
        public MainWindow()
        {
            InitializeComponent();
            richTextBox.IsReadOnly = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.Visibility = Visibility.Hidden;
            turn_1.Visibility = Visibility.Visible;
            stop_1.Visibility = Visibility.Visible;
            turn_2.Visibility = Visibility.Visible;
            stop_2.Visibility = Visibility.Visible;
            turn_2.IsEnabled = false;
            stop_2.IsEnabled = false;
            play();
        }

        private void play()
        {
            richTextBox.Document.Blocks.Clear();
            winner.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Hidden;
            turn_1.Visibility = Visibility.Visible;
            stop_1.Visibility = Visibility.Visible;
            turn_2.Visibility = Visibility.Visible;
            stop_2.Visibility = Visibility.Visible;
            result_1.Visibility = Visibility.Visible;
            result_2.Visibility = Visibility.Visible;
            richTextBox.Visibility = Visibility.Visible;
            turn_1.IsEnabled = true;
            stop_1.IsEnabled = true;
            turn_2.IsEnabled = false;
            stop_2.IsEnabled = false;
            p1w = true;
            p2w = true;
            game = new Game();
            updateResult();
        }


        private void changeRoundButtons()
        {
                turn_1.IsEnabled = !turn_1.IsEnabled;
                stop_1.IsEnabled = !stop_1.IsEnabled;
                turn_2.IsEnabled = !turn_2.IsEnabled;
                stop_2.IsEnabled = !stop_2.IsEnabled;
        }

        private void turn_1_Click(object sender, RoutedEventArgs e)
        {
            Card turnedCard = game.turnCard();
            richTextBox.AppendText(string.Format("\nPlayer 1 turned: {0}", turnedCard.ToString()));
            richTextBox.ScrollToEnd();
            game.increasePlayer(1, turnedCard.getNumber());
            if(game.checkIfBlow(1))
            {
                getWinner();
            }
            updateResult();
            if(p2w == true)
            {
                changeRoundButtons();
            }
            
        }

        private void updateResult()
        {
            result_1.Content = game.getCurrentScore(1);
            result_2.Content = game.getCurrentScore(2);
        }

        private void stop_1_Click(object sender, RoutedEventArgs e)
        {
            p1w = false;
            if(p2w)
            {
                changeRoundButtons();
            }
            else
            {
                getWinner();
            }
        }

        private void turn_2_Click(object sender, RoutedEventArgs e)
        {
            Card turnedCard = game.turnCard();
            richTextBox.AppendText(string.Format("\nPlayer 2 turned: {0}", turnedCard.ToString()));
            richTextBox.ScrollToEnd();
            game.increasePlayer(2, turnedCard.getNumber());
            if (game.checkIfBlow(2))
            {
                getWinner();
            }
            updateResult();
            if (p1w == true)
            {
                changeRoundButtons();
            }
                
        }

        private void getWinner()
        {
            result_1.Visibility = Visibility.Hidden;
            result_2.Visibility = Visibility.Hidden;
            winner.Visibility = Visibility.Visible;
            turn_1.Visibility = Visibility.Hidden;
            stop_1.Visibility = Visibility.Hidden;
            turn_2.Visibility = Visibility.Hidden;
            stop_2.Visibility = Visibility.Hidden;
            button1.Visibility = Visibility.Visible;
            switch (game.getWinner())
            {
                case 1:
                    winner.Content = "Player 1 is\nWinner!";
                    break;
                case 2:
                    winner.Content = "Player 2 is\nWinner!";
                    break;
                case 3:
                    winner.Content = "You've reached\na tie!!";
                    break;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            play();
        }

        private void stop_2_Click(object sender, RoutedEventArgs e)
        {
            p2w = false;
            if (p1w)
            {
                changeRoundButtons();
            }
            else
            {
                getWinner();
            }
        }
    }
}
