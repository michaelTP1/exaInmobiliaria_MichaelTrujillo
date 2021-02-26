using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Michael Jonay Trujillo Padilla
 * */
namespace exaInmobiliaria_MichaelTrujillo
{
    public partial class Form1 : Form
    {
        Connection con = new Connection();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(con.Con());
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(con.Con());
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(con.Con());
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5(con.Con());
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(con.Con());
            form.Show();
        }
    }
}
