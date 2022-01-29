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
    public partial class MovieX : Form
    {
        public static String Movie1;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da, daa;
        DataSet ds, dss;
        DataTable dt, dtt;
        DataRow dr, drr;
        int i = 0, j = 0;
        public MovieX()
        {
            InitializeComponent();
            label1.Text = Movies.Movie1;
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from movie where moviename='" + Movies.Movie1 + "'";

            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "movie");
            dt = ds.Tables["movie"];
            int t = dt.Rows.Count;
            dr = dt.Rows[i];

            label2.Text += " : " + dr["genre"].ToString();
            label3.Text += " : " + dr["cast"].ToString();
            label4.Text += " : " + dr["avgrating"].ToString();
            label5.Text += " : " + dr["runtime"].ToString();
            label6.Text += " : " + dr["language"].ToString();

            switch (Movies.Movie1)
            {
                case "Venom: Let There Be Carnage":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\venom.png");
                    break;
                case "La La Land":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\lalaland.png");
                    break;
                case "Radhe":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\radhe.png");
                    break;
                case "Dhamaka":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\dhamaka.png");
                    break;
                case "K.G.F: Chapter 1":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\kgf.png");
                    break;
                case "Maanikya":
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\maanikya.png");
                    break;
            }
            conn.Close();
        }
        public void DB_Connect()
        {
            String oradb = "Data Source=ictorcl;User ID=it294;Password=student;";
            conn = new OracleConnection(oradb);
            conn.Open();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MovieX_Load(object sender, EventArgs e)
        {
            DB_Connect();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "select comments from review where moviename='" + Movies.Movie1 + "'";

            cm.CommandType = CommandType.Text;
            dss = new DataSet();
            daa = new OracleDataAdapter(cm.CommandText, conn);
            daa.Fill(dss, "review");
            dtt = dss.Tables["review"];
            int t = dtt.Rows.Count;
            drr = dtt.Rows[j];
            richTextBox1.Text = drr["comments"].ToString();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Movies frm = new Movies();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            booking frm2 = new booking();
            this.Hide();
            frm2.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            j++;
            if (j >= dtt.Rows.Count)
                j = 0;
            drr = dtt.Rows[j];
            richTextBox1.Text = drr["comments"].ToString();
        }
    }
}
