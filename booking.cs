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
    public partial class booking : Form
    {
        public static int rd, pric;
        public static string cinemaname,date_selected;
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

        public booking()
        {
            InitializeComponent();
            label4.Hide();
            comboBox2.Hide();
            label2.Hide();
            button1.Hide();
        }

        private void booking_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) rd = 1;
            else if (radioButton2.Checked == true) rd = 2;
            else if (radioButton3.Checked == true) rd = 3;
            else if (radioButton4.Checked == true) rd = 4;
            else if (radioButton5.Checked == true) rd = 5;
            else if (radioButton6.Checked == true) rd = 6;
            else if (radioButton7.Checked == true) rd = 7;
            else if (radioButton8.Checked == true) rd = 8;
            else if (radioButton9.Checked == true) rd = 9;
            else if (radioButton10.Checked == true) rd = 10;
            else if (radioButton11.Checked == true) rd = 11;
            else if (radioButton12.Checked == true) rd = 12;
            else if (radioButton13.Checked == true) rd = 13;
            else if (radioButton14.Checked == true) rd = 14;
            else if (radioButton15.Checked == true) rd = 15;
            else if (radioButton16.Checked == true) rd = 16;
            else if (radioButton17.Checked == true) rd = 17;
            else if (radioButton18.Checked == true) rd = 18;
            else if (radioButton19.Checked == true) rd = 19;
            else if (radioButton20.Checked == true) rd = 20;
            else if (radioButton21.Checked == true) rd = 21;
            else if (radioButton22.Checked == true) rd = 22;
            else if (radioButton23.Checked == true) rd = 23;
            else if (radioButton24.Checked == true) rd = 24;
            else if (radioButton25.Checked == true) rd = 25;
            else if (radioButton26.Checked == true) rd = 26;
            else if (radioButton27.Checked == true) rd = 27;
            else if (radioButton28.Checked == true) rd = 28;
            else if (radioButton29.Checked == true) rd = 29;
            else if (radioButton30.Checked == true) rd = 30;
            else if (radioButton31.Checked == true) rd = 31;
            else if (radioButton32.Checked == true) rd = 32;
            else if (radioButton33.Checked == true) rd = 33;
            else if (radioButton34.Checked == true) rd = 34;
            else if (radioButton35.Checked == true) rd = 35;
            else if (radioButton36.Checked == true) rd = 36;
            else if (radioButton37.Checked == true) rd = 37;
            else if (radioButton38.Checked == true) rd = 38;
            else if (radioButton39.Checked == true) rd = 39;
            else if (radioButton40.Checked == true) rd = 40;
            else if (radioButton41.Checked == true) rd = 41;
            else if (radioButton42.Checked == true) rd = 42;
            else if (radioButton43.Checked == true) rd = 43;
            else if (radioButton44.Checked == true) rd = 44;
            else if (radioButton45.Checked == true) rd = 45;
            else if (radioButton46.Checked == true) rd = 46;
            else if (radioButton47.Checked == true) rd = 47;
            else if (radioButton48.Checked == true) rd = 48;
            else if (radioButton49.Checked == true) rd = 49;
            else if (radioButton50.Checked == true) rd = 50;
            else if (radioButton51.Checked == true) rd = 51;
            else if (radioButton52.Checked == true) rd = 52;
            else if (radioButton53.Checked == true) rd = 53;
            else if (radioButton54.Checked == true) rd = 54;
            else if (radioButton55.Checked == true) rd = 55;
            else if (radioButton56.Checked == true) rd = 56;
            else if (radioButton57.Checked == true) rd = 57;
            else if (radioButton58.Checked == true) rd = 58;
            else if (radioButton59.Checked == true) rd = 59;
            else if (radioButton60.Checked == true) rd = 60;


            if (rd < 21) { pric = 400; }
            else pric = 300;

            label4.Text = "Rs. " + pric.ToString();
            label4.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MovieX frm = new MovieX();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cinemaname = comboBox1.SelectedItem.ToString();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select timings from hall where moviename='" + Movies.Movie1 + "' and hallname ='" + cinemaname + "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "hall");
            dt = ds.Tables["hall"];
            comboBox2.DataSource = dt.DefaultView;
            comboBox2.DisplayMember = "timings";
            date_selected = comboBox2.SelectedItem.ToString();
            conn.Close();

            comboBox2.Show();
            label2.Show();
            button1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your ticket has been booked!");



            Movies frm3 = new Movies();
            frm3.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand(); //"Insert_tickets(:pb1,:pb2,:pb3,:pb4,:pb5,:pb6,:pb7)",conn);
            c.Connection = conn;
            c.CommandText = "EXECUTE Insert_tickets(1,'Radhe','INOX',9,300,1892,'2021-12-16')";
            MessageBox.Show(c.CommandText);
            OracleParameter pa1 = new OracleParameter();
            pa1.ParameterName = "pb1";
            pa1.DbType = DbType.Int32;
            pa1.Value = rd; //Seat_NO;
            OracleParameter pa2 = new OracleParameter();
            pa2.ParameterName = "pb2";
            pa2.DbType = DbType.String;
            pa2.Value = Movies.Movie1; //MovieName;
            OracleParameter pa3 = new OracleParameter();
            pa3.ParameterName = "pb3";
            pa3.DbType = DbType.String;
            pa3.Value = cinemaname; //Hallname;
            OracleParameter pa4 = new OracleParameter();
            pa4.ParameterName = "pb4";
            pa4.DbType = DbType.Int32;
            pa4.Value = 1; //Screen_NO;
            OracleParameter pa5 = new OracleParameter();
            pa5.ParameterName = "pb5";
            pa5.DbType = DbType.Int32;
            pa5.Value = pric; //Price;
            OracleParameter pa6 = new OracleParameter();
            pa6.ParameterName = "pb6";
            pa6.DbType = DbType.Int32;
            pa6.Value = Form3.usrname; //user_id;
            OracleParameter pa7 = new OracleParameter();
            pa7.ParameterName = "pb7";
            pa7.DbType = DbType.String;
            pa7.Value = "2021-12-15"; // date_selected; //Date;

            c.Parameters.Add(pa1);
            c.Parameters.Add(pa2);
            c.Parameters.Add(pa3);
            c.Parameters.Add(pa4);
            c.Parameters.Add(pa5);
            c.Parameters.Add(pa6);
            c.Parameters.Add(pa7);
            c.CommandType = CommandType.StoredProcedure;
            c.ExecuteNonQuery();
            conn.Close();
        }
    }
}
