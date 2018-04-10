using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int x2 = int.Parse(textBox2.Text);

            var calc = new ComplexCalc();
            int result = await calc.AddAsync(x1, x2).ConfigureAwait(false);
            textBox3.Text = result.ToString();
        }
    }
}
