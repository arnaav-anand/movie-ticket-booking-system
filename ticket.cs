using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace YouNOX
{
    public partial class ticket : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;

        public void DB_Connect()
        {
            String oradb = "Data Source=ictorcl;User ID=it294;Password=student;";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public ticket()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from ticket;";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "ticket");
            dt = ds.Tables["ticket"];
            int t = dt.Rows.Count;
            dr = dt.Rows[i];

            label2.Text = dr["moviename"].ToString();
            label3.Text = "Venue : " + dr["hallname"].ToString();
            label4.Text = "Seat : " + dr["seat_id"].ToString();
            label6.Text = "Screen No. : " + dr["screen_no"].ToString();
            label5.Text = "Date : 2021-12-15";
            label7.Text = "Price : 400";  //dr["price"].ToString();
            conn.Close();
        }

        private void ticket_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movies frm = new Movies();
            this.Hide();
            frm.Show();
        }
    }
}
