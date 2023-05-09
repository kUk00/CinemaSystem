using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaC
{
    public partial class Adm : Form
    {
        public Adm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123")
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.Close();
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
