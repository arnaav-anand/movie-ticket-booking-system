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
    public partial class Form3 : Form
    {
        public static String usrname = String.Empty;
        public static String password = String.Empty;
        public static String displayname = String.Empty;
        int userfound = 0, pwdfound = 0, i = 0;

        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Form3()
        {
            InitializeComponent();
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=ictorcl;User ID=it294;Password=student;";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from userdetails;";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "userdetails");
            dt = ds.Tables["userdetails"];
            int t = dt.Rows.Count;
            dr = dt.Rows[i];

            textBox1.Text = dr["userid"].ToString();

            for (i = 0; i < t; i++)     //Iterate loop to match entered userid in table
            {
                dr = dt.Rows[i];
                if (textBox1.Text == dr["userid"].ToString())
                {
                    userfound = 1;
                    break;
                }
                // else userfound = 0;
            }

            for (i = 0; i < t; i++)
            {
                dr = dt.Rows[i];
                if (textBox3.Text == dr["password"].ToString())
                {
                    pwdfound = 1;
                    break;
                }
                // else pwdfound = 0;
            }

            if (userfound == 0)
            {
                MessageBox.Show("User not found");
            }

            if (userfound == 1 && pwdfound == 0)
            {
                MessageBox.Show("Incorrect Password");
                i = 0;
            }
            else if (userfound == 1 && pwdfound == 1)
            {
                displayname = dr["username"].ToString() ;
                Movies obj = new Movies();
                this.Hide();
                obj.Show();
            }
           
        }
    }
}
