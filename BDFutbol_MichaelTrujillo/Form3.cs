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
    public partial class Form3 : Form
    {
        SqlConnection con;

        int table;

        DataSet ds;

        SqlDataAdapter da;


        public Form3()
        {
            InitializeComponent();
        }

        public Form3(SqlConnection con)
        {
            InitializeComponent();

            this.con = con;
        }



       

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                errorLabel.Text = "";
                con.Open();
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + comboBox1.SelectedValue);
                DataTable dt = new DataTable();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "select * from inmueble where tipo=@tipo";
                command.Parameters.AddWithValue("@tipo", comboBox1.SelectedValue);

                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);

                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                errorLabel.Text = "Error, Eliga un tipo en el combo";
            }
           
            con.Close();

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tipo_inmueble", con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            comboBox1.ValueMember = "tipo";
            comboBox1.DisplayMember = "descripcion";
            comboBox1.DataSource = dt;
            con.Close();
        }
    }
}
