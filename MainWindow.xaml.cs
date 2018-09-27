using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace ChessGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Handles board and its content
        public Status[,] status;
        public Ellipse[,] ellipse;
        public Button[,] button;
        //Handles turn control and game mode
        bool Player1Turn, IsGameEnded;
        //Handles last indexes of the current playing tool and the potential enemies for it per move
        int last_i = 0, last_j = 0, last_enemy_i = 0,
        last_enemy_j = 0, last_enemy_i2 = 0, last_enemy_j2 = 0,
        last_enemy_i3 = 0, last_enemy_j3 = 0, last_enemy_i4 = 0, last_enemy_j4 = 0;
        public MainWindow()
        {
            InitializeComponent();
            New_Game();
        }
        public void New_Game()
        {
            status = new Status[8, 8];
            ellipse = new Ellipse[8, 8];
            button = new Button[8, 8];
            //Initializes Board
            Initialize_Board();
            //Player 1 begins
            Player1Turn = true;
            //Make sure game hasn't finished
            IsGameEnded = false;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsGameEnded)
            { //checks if game over
                New_Game();
                return;
            }
            var btn = (Button)sender;
            int i = Grid.GetRow(btn), j = Grid.GetColumn(btn);
            if (Player1Turn)
            {
                //checks if this square is green
                Check_Green1(i, j);
                //make sure player 2 can't play while player 1's turn and the square isn't free  
                if (!Player1Turn || status[i, j] == Status.P2 || status[i, j] == Status.KP2 || status[i, j] == Status.Free) return;
                //checks if this king
                if (status[i, j] == Status.KP1)
                    Check_King_Moves1(i, j);
                else
                    Check_Moves1(i, j);
            }
            else
            {
                //checks if this square is green
                Check_Green2(i, j);
                //make sure player 1 can't play while player 2's turn and the square isn't free
                if (Player1Turn || status[i, j] == Status.P1 || status[i, j] == Status.KP1 || status[i, j] == Status.Free) return;
                //checks if this king
                if (status[i, j] == Status.KP2)
                    Check_King_Moves2(i, j);
                else
                    Check_Moves2(i, j);

            }
        }
        public void Initialize_Board()
        {
            #region Initialize squares' status,tools and buttons
            for (int i = 0; i < 8; i++)
            {
                if (i >= 0 && i <= 2)
                {//Player 2
                    if (i % 2 == 0)
                        for (int j = 1; j < 8; j += 2)
                        {
                            button[i, j] = new Button() { Background = Brushes.Brown };
                            Grid.SetRow(button[i, j], i);
                            Grid.SetColumn(button[i, j], j);
                            Board.Children.Add(button[i, j]);
                            button[i, j].AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
                            ellipse[i, j] = new Ellipse() { Height = 60, Width = 60, Fill = Brushes.White };
                            Grid.SetRow(ellipse[i, j], i);
                            Grid.SetColumn(ellipse[i, j], j);
                            Board.Children.Add(ellipse[i, j]);
                            status[i, j] = Status.P2;
                        }
                    else for (int j = 0; j < 8; j += 2)
                        {
                            button[i, j] = new Button() { Background = Brushes.Brown };
                            Grid.SetRow(button[i, j], i);
                            Grid.SetColumn(button[i, j], j);
                            Board.Children.Add(button[i, j]);
                            button[i, j].AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
                            ellipse[i, j] = new Ellipse() { Height = 60, Width = 60, Fill = Brushes.White };
                            Grid.SetRow(ellipse[i, j], i);
                            Grid.SetColumn(ellipse[i, j], j);
                            Board.Children.Add(ellipse[i, j]);
                            status[i, j] = Status.P2;
                        }
                }
                else if (i >= 3 && i <= 4)
                {//Free squares
                    if (i % 2 == 0)
                        for (int j = 1; j < 8; j += 2)
                        {
                            button[i, j] = new Button() { Background = Brushes.Brown };
                            Grid.SetRow(button[i, j], i);
                            Grid.SetColumn(button[i, j], j);
                            Board.Children.Add(button[i, j]);
                            button[i, j].AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
                            status[i, j] = Status.Free;
                        }
                    else for (int j = 0; j < 8; j += 2)
                        {
                            button[i, j] = new Button() { Background = Brushes.Brown };
                            Grid.SetRow(button[i, j], i);
                            Grid.SetColumn(button[i, j], j);
                            Board.Children.Add(button[i, j]);
                            button[i, j].AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
                            status[i, j] = Status.Free;
                        }
                }
                else
                {//Player 1
                    if (i % 2 == 0)
                        for (int j = 1; j < 8; j += 2)
                        {
                            button[i, j] = new Button() { Background = Brushes.Brown };
                            Grid.SetRow(button[i, j], i);
                            Grid.SetColumn(button[i, j], j);
                            Board.Children.Add(button[i, j]);
                            button[i, j].AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
                            ellipse[i, j] = new Ellipse() { Height = 60, Width = 60, Fill = Brushes.Black };
                            Grid.SetRow(ellipse[i, j], i);
                            Grid.SetColumn(ellipse[i, j], j);
                            Board.Children.Add(ellipse[i, j]);
                            status[i, j] = Status.P1;
                        }
                    else for (int j = 0; j < 8; j += 2)
                        {
                            button[i, j] = new Button() { Background = Brushes.Brown };
                            Grid.SetRow(button[i, j], i);
                            Grid.SetColumn(button[i, j], j);
                            Board.Children.Add(button[i, j]);
                            button[i, j].AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
                            ellipse[i, j] = new Ellipse() { Height = 60, Width = 60, Fill = Brushes.Black };
                            Grid.SetRow(ellipse[i, j], i);
                            Grid.SetColumn(ellipse[i, j], j);
                            Board.Children.Add(ellipse[i, j]);
                            status[i, j] = Status.P1;
                        }
                }
            }
            #endregion
        }
        public void Check_Green1(int i, int j)
        {
            if (button[i, j].Background == Brushes.Green)
            {
                //case of eating
                if (status[last_i, last_j] == Status.P1)
                {
                    if ((i + 1) == last_enemy_i || (i + 1) == last_enemy_i2)
                        Eat_Enemy1(i, j);
                    else if ((i - 1) == last_enemy_i || (i - 1) == last_enemy_i2)
                        Eat_Enemy2(i, j);
                }
                else if (status[last_i, last_j] == Status.KP1)
                { 
                      if ((i + 1) == last_enemy_i&&i<last_enemy_i || (i + 1) == last_enemy_i2&&i < last_enemy_i2)
                        Eat_Enemy1(i, j);
                    else if ((i - 1) == last_enemy_i3 && i > last_enemy_i3 || (i - 1) == last_enemy_i4 && i > last_enemy_i4)
                        Eat_Enemy3(i, j);
                }
                //move the tool 
                Ellipse e = new Ellipse() { Width = 60, Height = 60, Fill = Brushes.Black };
                ellipse[i, j] = e;
                if (status[last_i, last_j] == Status.KP1)
                {
                    ellipse[i, j].Fill = Brushes.Red;
                    status[i, j] = Status.KP1;
                }
                else status[i, j] = Status.P1;
                status[last_i, last_j] = Status.Free;
                Grid.SetRow(ellipse[i, j], i);
                Grid.SetColumn(ellipse[i, j], j);
                Board.Children.Remove(ellipse[last_i, last_j]);
                Board.Children.Add(ellipse[i, j]);
                //Check king situation
                if (i == 0)
                {
                    status[i, j] = Status.KP1;
                    ellipse[i, j].Fill = Brushes.Red;
                }
                //Turn all buttons to brown
                for (int k = 0; k < 8; k++)
                    if (k % 2 == 0)
                        for (int l = 1; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                    else
                        for (int l = 0; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                Player1Turn = false;
                //Checks if there is a winner
                Check_Winner();
                //Reset the enemy's indexes for the new turn
                last_i = 0; last_j = 0; last_enemy_i = 0;
                last_enemy_j = 0; last_enemy_i2 = 0; last_enemy_j2 = 0;
                last_enemy_i3 = 0; last_enemy_j3 = 0; last_enemy_i4 = 0; last_enemy_j4 = 0;
                return;
            }
            ///if the player clicks a non-green square in his turn
            else
            {//turns all buttons back to brown and replay
                for (int k = 0; k < 8; k++)
                    if (k % 2 == 0)
                        for (int l = 1; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                    else
                        for (int l = 0; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                //Reset the enemy's indexes for the new turn
                last_i = 0; last_j = 0; last_enemy_i = 0;
                last_enemy_j = 0; last_enemy_i2 = 0; last_enemy_j2 = 0;
                last_enemy_i3 = 0; last_enemy_j3 = 0; last_enemy_i4 = 0; last_enemy_j4 = 0;
            }
        }
        public void Check_Green2(int i, int j)
        {
            if (button[i, j].Background == Brushes.Green)
            {
                //case of eating
                if (status[last_i, last_j] == Status.P2)
                {
                    if ((i + 1) == last_enemy_i || (i + 1) == last_enemy_i2)
                        Eat_Enemy1(i, j);
                    else if ((i - 1) == last_enemy_i || (i - 1) == last_enemy_i2)
                        Eat_Enemy2(i, j);
                }
                else if (status[last_i, last_j] == Status.KP2)
                {
                    if ((i + 1) == last_enemy_i && i < last_enemy_i || (i + 1) == last_enemy_i2 && i < last_enemy_i2)
                        Eat_Enemy1(i, j);
                    else if ((i - 1) == last_enemy_i3 && i > last_enemy_i3 || (i - 1) == last_enemy_i4 && i > last_enemy_i4)
                        Eat_Enemy3(i, j);
                }

                //move the tool 
                Ellipse e = new Ellipse() { Width = 60, Height = 60, Fill = Brushes.White };
                ellipse[i, j] = e;
                if (status[last_i, last_j] == Status.KP2)
                {
                    ellipse[i, j].Fill = Brushes.Blue;
                    status[i, j] = Status.KP2;
                }
                else status[i, j] = Status.P2;
                status[last_i, last_j] = Status.Free;
                Grid.SetRow(ellipse[i, j], i);
                Grid.SetColumn(ellipse[i, j], j);
                Board.Children.Remove(ellipse[last_i, last_j]);
                Board.Children.Add(ellipse[i, j]);
                //Check king situation
                if (i == 7)
                {
                    status[i, j] = Status.KP2;
                    ellipse[i, j].Fill = Brushes.Blue;
                }
                //Turn all buttons to brown
                for (int k = 0; k < 8; k++)
                    if (k % 2 == 0)
                        for (int l = 1; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                    else
                        for (int l = 0; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                Player1Turn = true;
                //Checks if there is a winner
                Check_Winner();
                //Reset the enemy's indexes for the new turn
                last_i = 0; last_j = 0; last_enemy_i = 0;
                last_enemy_j = 0; last_enemy_i2 = 0; last_enemy_j2 = 0;
                last_enemy_i3 = 0; last_enemy_j3 = 0; last_enemy_i4 = 0; last_enemy_j4 = 0;
                return;
            }
            ///if the player clicks non-green square in his turn 
            else
            {//turns all buttons back to brown and replay
                for (int k = 0; k < 8; k++)
                    if (k % 2 == 0)
                        for (int l = 1; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                    else
                        for (int l = 0; l < 8; l += 2)
                            button[k, l].Background = Brushes.Brown;
                //Reset the enemy's indexes for the new turn
                last_i = 0; last_j = 0; last_enemy_i = 0;
                last_enemy_j = 0; last_enemy_i2 = 0; last_enemy_j2 = 0;
                last_enemy_i3 = 0; last_enemy_j3 = 0; last_enemy_i4 = 0; last_enemy_j4 = 0;
            }

        }
        public void Check_Moves1(int i, int j)
        {//Moves of player 1
            #region Normal Astrategic Cases
            if ((i % 2) != 0)//Odd Row Cases
            {//handles 1 enemy right and outrange right or just one regular move
                if (status[i - 1, j + 1] == Status.Free && (j - 1) < 0) { button[i - 1, j + 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
                else if ((status[i - 1, j + 1] == Status.P2 || status[i - 1, j + 1] == Status.P2) && (j + 2) <= 7 && (i - 2) >= 0 && (j - 1) < 0)
                    if (status[i - 2, j + 2] == Status.Free) { button[i - 2, j + 2].Background = Brushes.Green; last_enemy_i = i - 1; last_enemy_j = j + 1; last_i = i; last_j = j; return; }
            }
            else //Even Row Cases
            {//handles 1 enemy left and outrange left or just one regular move
                if (status[i - 1, j - 1] == Status.Free && (j + 1) > 7) { button[i - 1, j - 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
                else if ((j + 1) > 7 && (status[i - 1, j - 1] == Status.P2 || status[i - 1, j - 1] == Status.KP2) && (i - 2) >= 0 && (j - 2) >= 0)
                    if (status[i - 2, j - 2] == Status.Free) { button[i - 2, j - 2].Background = Brushes.Green; last_enemy_i = i - 1; last_enemy_j = j - 1; last_i = i; last_j = j; return; }
            }//handles 2 free squares
            if ((j + 1) <= 7 && (j - 1) >= 0)
                if (status[i - 1, j - 1] == Status.Free && status[i - 1, j + 1] == Status.Free)
                { button[i - 1, j - 1].Background = Brushes.Green; button[i - 1, j + 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
            if ((j + 1) <= 7 && (j - 1) >= 0)
                if ((status[i - 1, j - 1] == Status.P2 || status[i - 1, j - 1] == Status.KP2) && (status[i - 1, j + 1] == Status.P2 || status[i - 1, j + 1] == Status.KP2)
                    && (i - 2) >= 0 && (j - 2) >= 0 && (j + 2) <= 7)
                {//handles 2 enemies left and right
                    if (status[i - 2, j - 2] == Status.Free && status[i - 2, j + 2] == Status.Free)
                    {
                        button[i - 2, j - 2].Background = Brushes.Green;
                        button[i - 2, j + 2].Background = Brushes.Green;
                        last_enemy_i = i - 1; last_enemy_j = j - 1;
                        last_enemy_i2 = i - 1; last_enemy_j2 = j + 1; last_i = i; last_j = j; return;
                    }
                }//handles 1 enemy left and free square right
            if ((j + 1) <= 7)
                if (status[i - 1, j + 1] == Status.Free && (status[i - 1, j - 1] == Status.P2 || status[i - 1, j - 1] == Status.KP2) && (j - 2) >= 0 && (i - 2) >= 0)
                    if (status[i - 2, j - 2] == Status.Free)
                    {
                        button[i - 2, j - 2].Background = Brushes.Green;
                        button[i - 1, j + 1].Background = Brushes.Green;
                        last_enemy_i = i - 1; last_enemy_j = j - 1; last_i = i; last_j = j; return;
                    }//handles 1 enemy right and free square left
            if ((j - 1) >= 0)
                if (status[i - 1, j - 1] == Status.Free && (status[i - 1, j + 1] == Status.P2 || status[i - 1, j + 1] == Status.KP2) && (i - 2) >= 0 && (j + 2) <= 7)
                    if (status[i - 2, j + 2] == Status.Free)
                    {
                        button[i - 2, j + 2].Background = Brushes.Green;
                        button[i - 1, j - 1].Background = Brushes.Green;
                        last_enemy_i = i - 1; last_enemy_j = j + 1; last_i = i; last_j = j; return;
                    }
            //handles ememy left only without limitations
            if ((j - 1) >= 0 && (j - 2) >= 0 && (i - 1) >= 0 && (i - 2) >= 0)
                if ((status[i - 1, j - 1] == Status.P2 || status[i - 1, j - 1] == Status.KP2) && status[i - 2, j - 2] == Status.Free)
                {
                    button[i - 2, j - 2].Background = Brushes.Green;
                    last_enemy_i = i - 1; last_enemy_j = j - 1; last_i = i; last_j = j; return;
                }
            //handles enemy right only without limitations
            if ((j + 1) <= 7 && (j + 2) <= 7 && (i - 1) >= 0 && (i - 2) >= 0)
                if ((status[i - 1, j + 1] == Status.P2 || status[i - 1, j + 1] == Status.KP2) && status[i - 2, j + 2] == Status.Free)
                {
                    button[i - 2, j + 2].Background = Brushes.Green;
                    last_enemy_i = i - 1; last_enemy_j = j + 1; last_i = i; last_j = j; return;
                }
            //handle free left square only
            if ((j - 1) >= 0 && (i - 1) >= 0)
                if (status[i - 1, j - 1] == Status.Free) { button[i - 1, j - 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
            //handle free right square only
            if ((j + 1) <= 7 && (i - 1) >= 0)
                if (status[i - 1, j + 1] == Status.Free) { button[i - 1, j + 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
            #endregion

        }
        public void Check_Moves2(int i, int j)
        {//Moves of player 2
            #region Normal Astrategic Cases
            if ((i % 2) != 0)//Odd Row Cases
            {//handles 1 enemy right and outrange left or just one regular move
                if (status[i + 1, j + 1] == Status.Free && (j - 1) < 0) { button[i + 1, j + 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
                else if ((status[i + 1, j + 1] == Status.P1 || status[i + 1, j + 1] == Status.KP1) && (j + 2) <= 7 && (i + 2) >= 0 && (j - 1) < 0)
                    if (status[i + 2, j + 2] == Status.Free) { button[i + 2, j + 2].Background = Brushes.Green; last_enemy_i = i + 1; last_enemy_j = j + 1; last_i = i; last_j = j; return; }
            }
            else //Even Row Cases
            {//handles 1 enemy left and outrange right or just one regular move
                if (status[i + 1, j - 1] == Status.Free && (j + 1) > 7) { button[i + 1, j - 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
                else if ((j + 1) > 7 && (status[i + 1, j - 1] == Status.P1 || status[i + 1, j - 1] == Status.KP1) && (i + 2) >= 0 && (j - 2) >= 0)
                    if (status[i + 2, j - 2] == Status.Free) { button[i + 2, j - 2].Background = Brushes.Green; last_enemy_i = i + 1; last_enemy_j = j - 1; last_i = i; last_j = j; return; }
            }//handles 2 free squares
            if ((j + 1) <= 7 && (j - 1) >= 0)
                if (status[i + 1, j + 1] == Status.Free && status[i + 1, j - 1] == Status.Free)
                { button[i + 1, j + 1].Background = Brushes.Green; button[i + 1, j - 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
            if ((j + 1) <= 7 && (j - 1) >= 0)
                if ((status[i + 1, j + 1] == Status.P1 || status[i + 1, j + 1] == Status.KP1) && (status[i + 1, j - 1] == Status.P1 || status[i + 1, j - 1] == Status.KP1) &&
                    (i + 2) <= 7 && (j + 2) <= 7 && (j - 2) >= 0)
                {//handles 2 enemies left and right
                    if (status[i + 2, j + 2] == Status.Free && status[i + 2, j - 2] == Status.Free)
                    {
                        button[i + 2, j + 2].Background = Brushes.Green;
                        button[i + 2, j - 2].Background = Brushes.Green;
                        last_enemy_i = i + 1; last_enemy_j = j + 1;
                        last_enemy_i2 = i + 1; last_enemy_j2 = j - 1; last_i = i; last_j = j; return;
                    }
                }//handles 1 enemy left and free square right
            if ((j + 1) <= 7)
                if (status[i + 1, j + 1] == Status.Free && (status[i + 1, j - 1] == Status.P1 || status[i + 1, j - 1] == Status.KP1) && (j - 2) >= 0 && (i + 2) <= 7)
                    if (status[i + 2, j - 2] == Status.Free)
                    {
                        button[i + 2, j - 2].Background = Brushes.Green;
                        button[i + 1, j + 1].Background = Brushes.Green;
                        last_enemy_i = i + 1; last_enemy_j = j - 1; last_i = i; last_j = j; return;
                    }//handles 1 enemy right and free square left
            if ((j - 1) >= 0)
                if (status[i + 1, j - 1] == Status.Free && (status[i + 1, j + 1] == Status.P1 || status[i + 1, j + 1] == Status.KP1) && (i + 2) <= 7 && (j + 2) <= 7)
                    if (status[i + 2, j + 2] == Status.Free)
                    {
                        button[i + 2, j + 2].Background = Brushes.Green;
                        button[i + 1, j - 1].Background = Brushes.Green;
                        last_enemy_i = i + 1; last_enemy_j = j + 1; last_i = i; last_j = j; return;
                    }
            //handles ememy left only without limitations
            if ((j - 1) >= 0 && (j - 2) >= 0 && (i + 2) <= 7)
                if ((status[i + 1, j - 1] == Status.P1 || status[i + 1, j - 1] == Status.KP1) && status[i + 2, j - 2] == Status.Free)
                {
                    button[i + 2, j - 2].Background = Brushes.Green;
                    last_enemy_i = i + 1; last_enemy_j = j - 1; last_i = i; last_j = j; return;
                }
            //handles enemy right only without limitations
            if ((j + 1) <= 7 && (j + 2) <= 7 && (i + 2) <= 7 && (i + 1) <= 7)
                if ((status[i + 1, j + 1] == Status.P1 || status[i + 1, j + 1] == Status.KP1) && status[i + 2, j + 2] == Status.Free)
                {
                    button[i + 2, j + 2].Background = Brushes.Green;
                    last_enemy_i = i + 1; last_enemy_j = j + 1; last_i = i; last_j = j; return;
                }
            //handle free left square only
            if ((j - 1) >= 0)
                if (status[i + 1, j - 1] == Status.Free) { button[i + 1, j - 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
            //handle free right square only
            if ((j + 1) <= 7)
                if (status[i + 1, j + 1] == Status.Free) { button[i + 1, j + 1].Background = Brushes.Green; last_i = i; last_j = j; return; }
            #endregion

        }
        public void Check_King_Moves1(int k, int l)
        {
            #region King Astrategic Cases
            //check up-left direction
            last_i = k; last_j = l;
            for (int i = k - 1, j = l - 1; (i) >= 0 && (j) >= 0; i--, j--)
            {
                if (status[i, j] == Status.P1 || status[i, j] == Status.KP1) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P2 || status[i, j] == Status.KP2) && (i - 1) >= 0 && (j - 1) >= 0)
                    if ((status[i - 1, j - 1] == Status.P2 || status[i - 1, j - 1] == Status.KP2)) break;
                    else if (status[i - 1, j - 1] == Status.Free)
                    {
                        button[i - 1, j - 1].Background = Brushes.Green;
                        last_enemy_i = i;
                        last_enemy_j = j;
                        break;
                    }
            }
            //check up-right direction
            for (int i = k - 1, j = l + 1; (i) >= 0 && (j) <= 7; i--, j++)
            {
                if (status[i, j] == Status.P1 || status[i, j] == Status.KP1) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P2 || status[i, j] == Status.KP2) && (i - 1) >= 0 && (j + 1) <= 7)
                    if ((status[i - 1, j + 1] == Status.P2 || status[i - 1, j + 1] == Status.KP2)) break;
                    else if (status[i - 1, j + 1] == Status.Free)
                    {
                        button[i - 1, j + 1].Background = Brushes.Green;
                        last_enemy_i2 = i;
                        last_enemy_j2 = j;
                        break;
                    }
            }
            //check down-left direction
            for (int i = k + 1, j = l - 1; (i) <= 7 && (j) >= 0; i++, j--)
            {
                if (status[i, j] == Status.P1 || status[i, j] == Status.KP1) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P2 || status[i, j] == Status.KP2) && (i + 1) <= 7 && (j - 1) >= 0)
                    if ((status[i + 1, j - 1] == Status.P2 || status[i + 1, j - 1] == Status.KP2)) break;
                    else if (status[i + 1, j - 1] == Status.Free)
                    {
                        button[i + 1, j - 1].Background = Brushes.Green;
                        last_enemy_i3 = i;
                        last_enemy_j3 = j;
                        break;
                    }
            }
            //check down right direction
            for (int i = k + 1, j = l + 1; (i) <= 7 && (j) <= 7; i++, j++)
            {
                if (status[i, j] == Status.P1 || status[i, j] == Status.KP1) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P2 || status[i, j] == Status.KP2) && (i + 1) <= 7 && (j + 1) <= 7)
                    if ((status[i + 1, j + 1] == Status.P2 || status[i + 1, j + 1] == Status.KP2)) break;
                    else if (status[i + 1, j + 1] == Status.Free)
                    {
                        button[i + 1, j + 1].Background = Brushes.Green;
                        last_enemy_i4 = i;
                        last_enemy_j4 = j;
                        break;
                    }
            }
            #endregion

        }
        public void Check_King_Moves2(int k, int l)
        {
            #region King Astrategic Cases
            //check up-left direction
            last_i = k; last_j = l;
            for (int i = k - 1, j = l - 1; (i) >= 0 && (j) >= 0; i--, j--)
            {
                if (status[i, j] == Status.P2 || status[i, j] == Status.KP2) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P1 || status[i, j] == Status.KP1) && (i - 1) >= 0 && (j - 1) >= 0)
                    if (status[i - 1, j - 1] == Status.P1 || status[i - 1, j - 1] == Status.KP1) break;
                    else if (status[i - 1, j - 1] == Status.Free)
                    {
                        button[i - 1, j - 1].Background = Brushes.Green;
                        last_enemy_i = i;
                        last_enemy_j = j;
                        break;
                    }
            }
            //check up-right direction
            for (int i = k - 1, j = l + 1; (i) >= 0 && (j) <= 7; i--, j++)
            {
                if (status[i, j] == Status.P2 || status[i, j] == Status.KP2) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P1 || status[i, j] == Status.KP1) && (i - 1) >= 0 && (j + 1) <= 7)
                    if (status[i - 1, j + 1] == Status.P1 || status[i - 1, j + 1] == Status.KP1) break;
                    else if (status[i - 1, j + 1] == Status.Free)
                    {
                        button[i - 1, j + 1].Background = Brushes.Green;
                        last_enemy_i2 = i;
                        last_enemy_j2 = j;
                        break;
                    }
            }
            //check down-left direction
            for (int i = k + 1, j = l - 1; (i) <= 7 && (j) >= 0; i++, j--)
            {
                if (status[i, j] == Status.P2 || status[i, j] == Status.KP2) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P1 || status[i, j] == Status.KP1) && (i + 1) <= 7 && (j - 1) >= 0)
                    if (status[i + 1, j - 1] == Status.P1 || status[i + 1, j - 1] == Status.KP1) break;
                    else if (status[i + 1, j - 1] == Status.Free)
                    {
                        button[i + 1, j - 1].Background = Brushes.Green;
                        last_enemy_i3 = i;
                        last_enemy_j3 = j;
                        break;
                    }
            }
            //check down right direction
            for (int i = k + 1, j = l + 1; (i) <= 7 && (j) <= 7; i++, j++)
            {
                if (status[i, j] == Status.P2 || status[i, j] == Status.KP2) break;
                if (status[i, j] == Status.Free)
                    button[i, j].Background = Brushes.Green;
                if ((status[i, j] == Status.P1 || status[i, j] == Status.KP1) && (i + 1) <= 7 && (j + 1) <= 7)
                    if (status[i + 1, j + 1] == Status.P1 || status[i + 1, j + 1] == Status.KP1) break;
                    else if (status[i + 1, j + 1] == Status.Free)
                    {
                        button[i + 1, j + 1].Background = Brushes.Green;
                        last_enemy_i4 = i;
                        last_enemy_j4 = j;
                        break;
                    }
            }
            #endregion
        }
        public void Eat_Enemy1(int i, int j)
        {
            //Eat enemy 1
            if ((i + 1) == last_enemy_i && ((j - 1) == last_enemy_j || (j + 1) == last_enemy_j))
            {
                status[last_enemy_i, last_enemy_j] = Status.Free;
                Board.Children.Remove(ellipse[last_enemy_i, last_enemy_j]);
            }
            else if ((i + 1) == last_enemy_i2 && ((j - 1) == last_enemy_j2 || (j + 1) == last_enemy_j2))
            {//Eat enemy 2
                status[last_enemy_i2, last_enemy_j2] = Status.Free;
                Board.Children.Remove(ellipse[last_enemy_i2, last_enemy_j2]);
            }
        }
        public void Eat_Enemy2(int i, int j)
        {
            //Eat enemy 1
            if ((i - 1) == last_enemy_i && ((j - 1) == last_enemy_j || (j + 1) == last_enemy_j))
            {
                status[last_enemy_i, last_enemy_j] = Status.Free;
                Board.Children.Remove(ellipse[last_enemy_i, last_enemy_j]);
            }
            else if ((i - 1) == last_enemy_i2 && ((j - 1) == last_enemy_j2 || (j + 1) == last_enemy_j2))
            {//Eat enemy 2
                status[last_enemy_i2, last_enemy_j2] = Status.Free;
                Board.Children.Remove(ellipse[last_enemy_i2, last_enemy_j2]);
            }

        }
        public void Eat_Enemy3(int i, int j)
        {
            //Eat enemy 3
            if ((i - 1) == last_enemy_i3 && ((j - 1) == last_enemy_j3 || (j + 1) == last_enemy_j3))
            {
                status[last_enemy_i3, last_enemy_j3] = Status.Free;
                Board.Children.Remove(ellipse[last_enemy_i3, last_enemy_j3]);
            }
            else if ((i - 1) == last_enemy_i4 && ((j - 1) == last_enemy_j4 || (j + 1) == last_enemy_j4))
            {//Eat enemy 4
                status[last_enemy_i4, last_enemy_j4] = Status.Free;
                Board.Children.Remove(ellipse[last_enemy_i4, last_enemy_j4]);
            }
        }
        public void Check_Winner()
        {
            bool flag1 = true, flag2 = true;
            //Checks if player 1 wins
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                    for (int j = 1; j < 8; j += 2)
                    {
                        if (status[i, j] == Status.KP2 || status[i, j] == Status.P2)
                        {
                            flag1 = false;
                            break;
                        }
                    }
                else
                    for (int j = 0; j < 8; j += 2)
                    {
                        if (status[i, j] == Status.KP2 || status[i, j] == Status.P2)
                        {
                            flag1 = false;
                            break;
                        }
                    }
            }
            if (flag1)
            {
                MessageBox.Show("Player 1 Wins!");
                IsGameEnded = true;
                return;
            }
            //Checks if player 2 wins
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                    for (int j = 1; j < 8; j += 2)
                    {
                        if (status[i, j] == Status.KP1 || status[i, j] == Status.P1)
                        {
                            flag2 = false;
                            break;
                        }
                    }
                else
                    for (int j = 0; j < 8; j += 2)
                    {
                        if (status[i, j] == Status.KP1 || status[i, j] == Status.P1)
                        {
                            flag2 = false;
                            break;
                        }
                    }
            }
            if (flag2)
            {
                MessageBox.Show("Player 2 Wins!");
                IsGameEnded = true;
                return;
            }
        }
    }
}









