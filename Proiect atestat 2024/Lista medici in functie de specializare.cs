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

namespace Proiect_atestat_2024
{
    public partial class Lista_medici_in_functie_de_specializare : Form
    {
        string qs;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public Lista_medici_in_functie_de_specializare()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\LOGINdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            qs = @"SELECT *FROM login";
            afisare(qs);
        }
        void afisare(string qs)
        {
            cmd = new SqlCommand(qs, con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void buttonInchidere_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonPaginaPrincipala_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.Show();
        }

        private void buttonAfiseaza_Click(object sender, EventArgs e)
        {
            qs = $@"SELECT USERNAME, PASSWORD, EMAIL, YEARSOFEXPERIENCE, SPECIALTY FROM login
                WHERE SPECIALTY='{textBoxSpecializare.Text}' ORDER BY USERNAME";
            afisare(qs);
        }
    }
}
