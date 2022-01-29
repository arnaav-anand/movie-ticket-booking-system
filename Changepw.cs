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
    public partial class Changepw : Form
    {
        OracleConnection conn;

        public Changepw()
        {
            InitializeComponent();
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=ictorcl;User ID=it294;Password=student;";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void Changepw_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            DB_Connect();
            String v = textBox3.Text;
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "update userdetails set password=:pb where userid =:pdn";
            cm.CommandType = CommandType.Text;
            //Uses OracleParameter to read the parameter from the GUI
            OracleParameter pa1 = new OracleParameter();
            pa1.ParameterName = "pb";
            pa1.DbType = DbType.String;
            pa1.Value = v;
            OracleParameter pa2 = new OracleParameter();
            pa2.ParameterName = "pdn";
            pa2.DbType = DbType.Int32;
            pa2.Value = int.Parse(textBox1.Text);
            cm.Parameters.Add(pa1);
            cm.Parameters.Add(pa2);
            cm.ExecuteNonQuery();
            MessageBox.Show("Password has been changed successfully");
            conn.Close();
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
