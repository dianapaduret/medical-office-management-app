using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Proiect_atestat_2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\LOGINdb.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='"+ textBoxUtilizator.Text +"' AND password='"+ textBoxParola.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string username = textBoxUtilizator.Text;
            string password = textBoxParola.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Va rog introduceti si numele de utilizator si parola");
                return;
            }
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Home hm = new Home();
                hm.Show();
            }
            else
            {
                MessageBox.Show("Numele de utilizator sau parola sunt incorecte");
            }
            

           
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor dc= new Doctor();
            dc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxParola_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
