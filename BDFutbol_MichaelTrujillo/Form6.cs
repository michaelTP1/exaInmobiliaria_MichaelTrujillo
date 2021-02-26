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
    public partial class Form6 : Form
    {

        SqlConnection con;

        int table;

        DataSet ds;

        SqlDataAdapter da;


        public Form6()
        {
            InitializeComponent();
        }

        public Form6(SqlConnection con)
        {
            InitializeComponent();

            this.con = con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            con.Open();
            SqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO inmueble (tipo, ubicacion, fecha, importe, vendida) VALUES(@tipo, @ubicacion, @fecha, @importe, @vendida)";

            command.Parameters.AddWithValue("@tipo", comboBox1.SelectedValue);
            command.Parameters.AddWithValue("@ubicacion", ubicacionText.Text);
            command.Parameters.AddWithValue("@fecha", datePicker.Value);
            command.Parameters.AddWithValue("@importe", importeText.Text);
            command.Parameters.AddWithValue("@vendida", checkBox1.Checked);

            command.ExecuteNonQuery();
            con.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
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
