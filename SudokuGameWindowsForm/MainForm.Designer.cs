namespace SudokuGameWindowsForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelBoardMainFrame = new System.Windows.Forms.Panel();
            this.btnSolvePuzzle = new System.Windows.Forms.Button();
            this.btnClearTheBoard = new System.Windows.Forms.Button();
            this.btnGeneratePuzzle = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCheckThePuzzle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PanelBoardMainFrame
            // 
            this.PanelBoardMainFrame.BackColor = System.Drawing.Color.Gray;
            this.PanelBoardMainFrame.Location = new System.Drawing.Point(0, 0);
            this.PanelBoardMainFrame.Name = "PanelBoardMainFrame";
            this.PanelBoardMainFrame.Size = new System.Drawing.Size(477, 477);
            this.PanelBoardMainFrame.TabIndex = 0;
            // 
            // btnSolvePuzzle
            // 
            this.btnSolvePuzzle.Location = new System.Drawing.Point(111, 485);
            this.btnSolvePuzzle.Name = "btnSolvePuzzle";
            this.btnSolvePuzzle.Size = new System.Drawing.Size(100, 32);
            this.btnSolvePuzzle.TabIndex = 1;
            this.btnSolvePuzzle.Text = "Solve the Puzzle";
            this.btnSolvePuzzle.UseVisualStyleBackColor = true;
            this.btnSolvePuzzle.Click += new System.EventHandler(this.btnSolvePuzzle_Click);
            // 
            // btnClearTheBoard
            // 
            this.btnClearTheBoard.Location = new System.Drawing.Point(352, 485);
            this.btnClearTheBoard.Name = "btnClearTheBoard";
            this.btnClearTheBoard.Size = new System.Drawing.Size(100, 32);
            this.btnClearTheBoard.TabIndex = 2;
            this.btnClearTheBoard.Text = "Clear the Board";
            this.btnClearTheBoard.UseVisualStyleBackColor = true;
            this.btnClearTheBoard.Click += new System.EventHandler(this.btnClearTheBoard_Click);
            // 
            // btnGeneratePuzzle
            // 
            this.btnGeneratePuzzle.Location = new System.Drawing.Point(212, 485);
            this.btnGeneratePuzzle.Name = "btnGeneratePuzzle";
            this.btnGeneratePuzzle.Size = new System.Drawing.Size(139, 32);
            this.btnGeneratePuzzle.TabIndex = 4;
            this.btnGeneratePuzzle.Text = "Generate Random Puzzle";
            this.btnGeneratePuzzle.UseVisualStyleBackColor = true;
            this.btnGeneratePuzzle.Click += new System.EventHandler(this.btnGeneratePuzzle_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHelp.Location = new System.Drawing.Point(452, 485);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(25, 32);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCheckThePuzzle
            // 
            this.btnCheckThePuzzle.Location = new System.Drawing.Point(0, 485);
            this.btnCheckThePuzzle.Name = "btnCheckThePuzzle";
            this.btnCheckThePuzzle.Size = new System.Drawing.Size(110, 32);
            this.btnCheckThePuzzle.TabIndex = 6;
            this.btnCheckThePuzzle.Text = "Check the Puzzle";
            this.btnCheckThePuzzle.UseVisualStyleBackColor = true;
            this.btnCheckThePuzzle.Click += new System.EventHandler(this.btnCheckThePuzzle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 523);
            this.Controls.Add(this.btnCheckThePuzzle);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnGeneratePuzzle);
            this.Controls.Add(this.btnClearTheBoard);
            this.Controls.Add(this.btnSolvePuzzle);
            this.Controls.Add(this.PanelBoardMainFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Sudoku | github.com/firateski";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBoardMainFrame;
        private System.Windows.Forms.Button btnSolvePuzzle;
        private System.Windows.Forms.Button btnClearTheBoard;
        private System.Windows.Forms.Button btnGeneratePuzzle;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCheckThePuzzle;
    }
}