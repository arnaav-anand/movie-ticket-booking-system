using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace YouNOX
{
    public partial class Movies : Form
    {
        public static string Movie1 = string.Empty;
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

        public Movies()
        {
            InitializeComponent();
            label1.Text += Form3.displayname;
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from movie;";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "moviename");
            dt = ds.Tables["moviename"];
            int t = dt.Rows.Count;
            dr = dt.Rows[i];

            label2.Text = dr["moviename"].ToString();
            i++; dr = dt.Rows[i];
            label3.Text = dr["moviename"].ToString();
            i++; dr = dt.Rows[i];
            label4.Text = dr["moviename"].ToString();
            i = 0;

            pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\venom.png");
            pictureBox2.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\lalaland.png");
            pictureBox3.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\radhe.png");

        }

        private void oPTIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void sIGNOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Movies_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Previous Button
            i -= 3;
            if (i < 0)
                i = dt.Rows.Count - 3;
            int j = i;
            switch (i)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\venom.png");
                    pictureBox2.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\lalaland.png");
                    pictureBox3.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\radhe.png");
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\dhamaka.png");
                    pictureBox2.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\kgf.png");
                    pictureBox3.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\maanikya.png");
                    break;
            }

            //MessageBox.Show(i.ToString());
            dr = dt.Rows[j];
            label2.Text = dr["moviename"].ToString();
            j++; dr = dt.Rows[j];
            label3.Text = dr["moviename"].ToString();
            j++; dr = dt.Rows[j];
            label4.Text = dr["moviename"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Next Button
            i += 3;
            if (i >= dt.Rows.Count)
                i = 0;
            //MessageBox.Show(i.ToString());
            switch (i)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\venom.png");
                    pictureBox2.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\lalaland.png");
                    pictureBox3.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\radhe.png");
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\dhamaka.png");
                    pictureBox2.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\kgf.png");
                    pictureBox3.Image = Image.FromFile(@"C:\Users\student\Desktop\younox_movies\maanikya.png");
                    break;
            }

            int j = i;
            dr = dt.Rows[j];
            label2.Text = dr["moviename"].ToString();
            j++; dr = dt.Rows[j];
            label3.Text = dr["moviename"].ToString();
            j++; dr = dt.Rows[j];
            label4.Text = dr["moviename"].ToString();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Button to View Details for the First Movie on the Movies Page
            Movies.Movie1 = label2.Text;

            MovieX frm = new MovieX();
            frm.Show();
            this.Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Movies.Movie1 = label3.Text;

            MovieX frm = new MovieX();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Movies.Movie1 = label4.Text;

            MovieX frm = new MovieX();
            frm.Show();
            this.Hide();
        }

        private void cHANGEPASSWORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changepw frm = new Changepw();
            this.Hide();
            frm.Show();

        }

        private void vIEWPROFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ticket frm2 = new ticket();
            this.Hide();
            frm2.Show();
        }
    }
}
