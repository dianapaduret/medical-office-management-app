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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proiect_atestat_2024
{
    public partial class Lista_pacienti_in_functie_de_grupa_de_sange : Form
    {
        string qs;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public Lista_pacienti_in_functie_de_grupa_de_sange()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\LOGINdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            qs = @"SELECT *FROM pacienti";
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
            qs = $@"SELECT NumePacient, Adresa, Localitate, Oras, Sex, Varsta, GrupaSange, NumeDoctor FROM pacienti
                WHERE GrupaSange='{textBoxGrupaSange.Text}' ORDER BY NumePacient";
            afisare(qs);
        }
    }
}
