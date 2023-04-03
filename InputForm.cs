using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicChronology
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        public int? GetEnteredNumber(string windowName, string windowDescription)
        {
            this.Text = windowName;
            inputDescriptionLabel.Text = windowDescription;
            if (this.ShowDialog() == DialogResult.OK)
            {
                return (int)numericUpDown.Value;
            }
            return null;

        }
    }
}
