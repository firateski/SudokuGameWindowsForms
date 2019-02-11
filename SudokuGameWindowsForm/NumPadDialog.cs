using System;
using System.Windows.Forms;

namespace SudokuGameWindowsForm
{
    public partial class NumPadDialog : Form
    {
        public NumPadDialog()
        {
            InitializeComponent();
        }

        public int Value = -1;

        private void NumPadDialog_Deactivate(object sender, EventArgs e) => Close();

        private void btnNumberClick(object sender, EventArgs e)
        {
            Value = Convert.ToInt32((sender as Button).Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void NumPadDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
