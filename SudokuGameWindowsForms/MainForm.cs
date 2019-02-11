using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sudoku;

namespace SudokuGameWindowsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            CreateBoardCells();
        }

        #region Constants for creating sudoku cells onto form
        const int START_X = 5;
        const int START_Y = 5;

        const int CELL_WIDTH = 50;
        const int CELL_HEIGHT = 50;

        const int SMALL_PADDING = 1;
        const int LARGE_PADDING = 5;
        #endregion

        //  GameBoard Instance
        SudokuBoard GameBoard = new SudokuBoard();

        // List of the labels which are using as a cell.
        List<Label> CellControls = new List<Label>();

        /// <summary>
        /// Refresh the board through the cell values.
        /// </summary>
        private void RefreshTheBoard()
        {
            CellControls.ForEach(c =>
            {
                int cellIndex = (int)c.Tag;
                string cellValue = GameBoard.GetCell(cellIndex).Value == -1 ? "" : GameBoard.GetCell(cellIndex).Value.ToString();
                c.Text = cellValue;
            });
        }

        /// <summary>
        /// Creates the gameboard cells.
        /// </summary>
        private void CreateBoardCells()
        {
            int currentTop = START_Y;
            int currentLeft = START_X;

            // This loop iterates for the rows of the game board.
            for (int x = 0; x < GameBoard.TOTAL_ROWS; x++)
            {
                currentLeft = START_X;

                // This loop iterates for the columns of the game board.
                // Place the each cells side by of the current row.
                for (int y = 0; y < GameBoard.TOTAL_COLUMNS; y++)
                {
                    // Create label control to use as game cell
                    Label cell = new Label
                    {
                        // Index of the cell
                        Tag = x * GameBoard.TOTAL_ROWS + y,

                        // UI Properties
                        Width = CELL_WIDTH,
                        Height = CELL_HEIGHT,
                        Left = currentLeft,
                        Top = currentTop,
                        ForeColor = Color.Lime,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 28),
                        BackColor = Color.Black,
                    };

                    // Connect to related event handler of the cell.
                    cell.MouseClick += Cell_MouseClick; ;

                    // Increase the 'CurrentLeft' property by large or small padding through whether the current cell is the first one of the group as horizontal.
                    currentLeft += CELL_WIDTH + ((y + 1) % 3 == 0 ? LARGE_PADDING : SMALL_PADDING);

                    // Add the current control to the 'CellControls' list and to the (UI) panel.
                    CellControls.Add(cell);
                    PanelBoardMainFrame.Controls.Add(cell);
                }

                // Increase the 'CurrentTop' property by large or small padding through whether the current cell is the first one of the group as vertical.
                currentTop += CELL_HEIGHT + ((x + 1) % 3 == 0 ? LARGE_PADDING : SMALL_PADDING);
            }
        }

        /// <summary>
        /// Click event handler of the cells.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            Label clickedCellControl = (sender as Label);
            int cellIndex = (int)clickedCellControl.Tag;

            // Handle right-click
            if (e.Button == MouseButtons.Right)
            {
                GameBoard.SetCellValue(-1, cellIndex);
                RefreshTheBoard();
            }
            else // Handle clicks(except right-clicks)
            {
                // Create new numpad dialog
                var numPadDialog = new NumPadDialog();

                #region Calculate the location of the numpad dialog through the location cell clicked.
                int numpadLocationX = clickedCellControl.Location.X - (numPadDialog.Width / 4) + this.Location.X;
                int numpadLocationY = clickedCellControl.Location.Y - (numPadDialog.Height / 4) + this.Location.Y;

                if (numpadLocationX < 0) numpadLocationX = 0;
                if (numpadLocationY < 0) numpadLocationY = 0;

                if (Screen.PrimaryScreen.WorkingArea.Width < numPadDialog.Width + numpadLocationX)
                    numpadLocationX = Screen.PrimaryScreen.WorkingArea.Width - numPadDialog.Width;

                if (Screen.PrimaryScreen.WorkingArea.Height < numPadDialog.Height + numpadLocationY)
                    numpadLocationY = Screen.PrimaryScreen.WorkingArea.Height - numPadDialog.Height;

                Point numpadLocation = new Point(numpadLocationX, numpadLocationY);

                numPadDialog.Location = numpadLocation;
                #endregion

                // Show the numpad dialog.
                numPadDialog.Show();

                // Handle the closed event of the numpad dialog to get the result.
                numPadDialog.FormClosed += (object s, FormClosedEventArgs ea) =>
                {
                    // If any number selected from the numpad dialog then set it to the related cell.
                    if (numPadDialog.Value != -1)
                    {
                        GameBoard.SetCellValue(numPadDialog.Value, cellIndex);
                        RefreshTheBoard();
                    }

                    // Dispose the numpad dialog.
                    numPadDialog.Dispose();
                };
            }
        }

        /// <summary>
        /// 'Check the Puzzle' button click event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckThePuzzle_Click(object sender, EventArgs e)
        {
            if (GameBoard.IsTableEmpty())
                MessageBox.Show("The puzzle is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (GameBoard.IsBoardFilled() && GameBoard.Solver.CheckTableStateIsValid())
                MessageBox.Show("Congratulations, the puzzle is successfully solved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (GameBoard.IsBoardFilled() && !GameBoard.Solver.CheckTableStateIsValid())
                MessageBox.Show("Sorry, the puzzle is not solved correctly.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!GameBoard.IsBoardFilled() && GameBoard.Solver.CheckTableStateIsValid(ignoreEmptyCells: true))
                MessageBox.Show("The current state of the puzzle is correct, but not completed yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Sorry, the current state of the puzzle is incorrect, and not completed yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 'Solve the Puzzle' button click event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSolvePuzzle_Click(object sender, EventArgs e)
        {
            // Check the board is already filled.
            if (GameBoard.IsBoardFilled())
                MessageBox.Show("The game board is already filled. Please reset the board or right click to any cell to empty or use 'Generate' to generate solved game board.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (GameBoard.Solver.SolveThePuzzle(UseRandomGenerator: true))
                RefreshTheBoard();
            else
                MessageBox.Show("Sorry, no solution for the current board. You can reset the board and generate solution from empty board.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 'Generate Puzzle' button click event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneratePuzzle_Click(object sender, EventArgs e)
        {
            GameBoard.Clear();
            GameBoard.Solver.SolveThePuzzle(UseRandomGenerator: true);
            RefreshTheBoard();
        }

        /// <summary>
        /// 'Clear the Board' button click event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTheBoard_Click(object sender, EventArgs e)
        {
            GameBoard.Clear();
            RefreshTheBoard();
        }

        /// <summary>
        /// Help('?') button click event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpMessage = $"- Left-click the cell to set number to it." + Environment.NewLine +
                                 $"- Right-click the cell to clear the number in it." + Environment.NewLine +
                                 $"- Click the 'Check the Puzzle' button to see the current status of the puzzle." + Environment.NewLine +
                                 $"- Click the 'Solve the Puzzle' button to solve the puzzle with the value(s) on it." + Environment.NewLine +
                                 $"- Click the 'Generate Random Puzzle' button to clear current state of the board and generate random puzzle." + Environment.NewLine + Environment.NewLine +
                                 $"Developer: Fırat Eşki - Github: @firateski";

            MessageBox.Show(helpMessage, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}