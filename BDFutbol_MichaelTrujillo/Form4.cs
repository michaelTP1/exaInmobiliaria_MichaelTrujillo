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
    public partial class Form4 : Form
    {
        SqlConnection con;

        int table;

        DataSet ds=new DataSet();
        DataView tipoInmuebleDataView = new DataView();

        SqlDataAdapter da;


        public Form4()
        {
            InitializeComponent();
        }

        public Form4(SqlConnection con)
        {
            InitializeComponent();

            this.con = con;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter daTipo = new SqlDataAdapter("select * from tipo_inmueble", con);
            daTipo.Fill(ds, "Tipo_inmueble");

            SqlDataAdapter daInmueble = new SqlDataAdapter("select * from inmueble", con);
            daInmueble.Fill(ds, "Inmueble");

            DataRowView currentRowView;

            tipoInmuebleDataView = new DataView(ds.Tables["Tipo_inmueble"]);
            dataGridView1.DataSource = tipoInmuebleDataView;
            DataColumn parentColumn = ds.Tables["Tipo_inmueble"].Columns["tipo"];
            DataColumn childColumn = ds.Tables["Inmueble"].Columns["tipo"];

            DataRelation ligaEquiposRelation = new DataRelation("TipoInmueble", parentColumn, childColumn);
            ds.Relations.Add(ligaEquiposRelation);

            currentRowView = tipoInmuebleDataView[dataGridView1.CurrentRow.Index];
            dataGridView2.DataSource = currentRowView.CreateChildView(ds.Relations["TipoInmueble"]);
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            DataRowView currentRowView;
            currentRowView = tipoInmuebleDataView[e.RowIndex];
            dataGridView2.DataSource = currentRowView.CreateChildView(ds.Relations["TipoInmueble"]);
            con.Close();
        }
    }
}
