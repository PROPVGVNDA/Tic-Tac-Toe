using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current results of cell in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's (O)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion

        /// <summary>
        /// Starts a new game and sets all values to default
        /// </summary>
        private void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            // Make sure player 1 starts first
            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Make sure the game has not finished
            mGameEnded = false;
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The evenets of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button) sender;

            // Finds the button's position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);
            
            // Skip if the cell already has a value
            if(mResults[index] != MarkType.Free) return;
            
            // Set the set value based on which player turn it is
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "X" : "O";

            // Change noughts to green
            if (!mPlayer1Turn) button.Foreground = Brushes.Red;

            // Toggle the players turns
            mPlayer1Turn = !mPlayer1Turn;

            // Check for a winner
            CheckForWinner();
        }

        /// <summary>
        /// Check if there's a winner of a 3 line straight
        /// </summary>
        private void CheckForWinner()
        {
            #region Horizontal wins
            // Check for horizontal winners
            // Row 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            // Row 1
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            // Row 2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Vertical wins
            // Check for vertical winners
            // Row 0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Diagonal wins
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                // Highlight winnig cells in green
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }


            #endregion

            #region No Wins
            if (!mResults.Any(result => result == MarkType.Free))
            {
                // Game ended
                mGameEnded = true;

                // Turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
            #endregion
        }
    }
}
