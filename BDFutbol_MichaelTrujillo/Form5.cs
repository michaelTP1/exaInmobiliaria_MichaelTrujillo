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
    public partial class Form5 : Form
    {
        SqlConnection con;

        int table;

        DataSet ds;

        SqlDataAdapter da;


        public Form5()
        {
            InitializeComponent();
        }

        public Form5(SqlConnection con)
        {
            InitializeComponent();

            this.con = con;
        }

        private void Form5_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand command = new SqlCommand("listainmuebles ", con);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter
                ("@tipo", SqlDbType.Char);
                param.Direction = ParameterDirection.Input;
                param.Value = comboBox1.SelectedValue;
                command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);

                dataGridView1.DataSource = dt;


                
            }
            catch (Exception)
            {
                errorLabel.Text = "datos incorrectos";
                dataGridView1.Rows.Clear();
            }


            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("Select dbo.Numeroinmueblesportipo(@tipo); ", con);

                command.Parameters.AddWithValue("@tipo", comboBox1.SelectedValue);

                functionResultLabel.Text = command.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                errorLabel.Text = "datos incorrectos";
            }
           

            con.Close();
        }

     
        private void functionResultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
