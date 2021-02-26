using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class Form2 : Form


    {

        SqlConnection con;

        int table;

        DataSet ds;

        SqlDataAdapter da;


        public Form2()
        {
            InitializeComponent();
        }
        public Form2(SqlConnection con)
        {
            InitializeComponent();

            this.con = con;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT * from inmueble;";
            SqlCommand command = new SqlCommand(queryString, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    } 
}
