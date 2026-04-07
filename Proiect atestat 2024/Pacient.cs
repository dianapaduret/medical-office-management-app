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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Proiect_atestat_2024
{
    public partial class Pacient : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Pacient()
        {
            string qs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\LOGINdb.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(qs);
            con.Open();
            InitializeComponent();
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            string nume = textBoxNumePacient.Text;
            if (nume.Length < 4)
            {
                MessageBox.Show("Numele pacientului este prea scurt!");
                return;
            }

            string qs = "SELECT COUNT(*) FROM pacienti WHERE NumePacient = @1";
            cmd = new SqlCommand(qs, con);
            cmd.Parameters.AddWithValue("@1", nume);
            int r = (int)cmd.ExecuteScalar();
            if (r > 0)
            {
                MessageBox.Show("Numele pacientului a fost inregistrat deja!");
                return;
            }

            string adresa = textBoxAdresa.Text;
            if (adresa.Length < 4)
            {
                MessageBox.Show("Adresa invalida!");
                return;
            }

            string localitate = textBoxLocalitate.Text;
            if (localitate.Length < 3)
            {
                MessageBox.Show("Localitatea invalida!");
                return;
            }

            string oras = textBoxOras.Text;
            if (oras.Length < 4)
            {
                MessageBox.Show("Adresa invalida!");
                return;
            }

            string sex = textBoxSex.Text;

            int varsta = Convert.ToInt32(textBoxVarsta.Text);

            string grupa = textBoxGrupaSange.Text;

            string numedoc = textBoxNumeleDoc.Text;
            if (numedoc.Length < 4)
            {
                MessageBox.Show("Numele doctorului este prea scurt!");
                return;
            }


            qs = "INSERT INTO pacienti (NumePacient, Adresa, Localitate, Oras, Sex, Varsta, GrupaSange, NumeDoctor) VALUES (@1, @2, @3, @4, @5, @6, @7, @8)";
            cmd = new SqlCommand(qs, con);
            cmd.Parameters.AddWithValue("@1", nume);
            cmd.Parameters.AddWithValue("@2", adresa);
            cmd.Parameters.AddWithValue("@3", localitate);
            cmd.Parameters.AddWithValue("@4", oras);
            cmd.Parameters.AddWithValue("@5", sex);
            cmd.Parameters.AddWithValue("@6", varsta);
            cmd.Parameters.AddWithValue("@7", grupa);
            cmd.Parameters.AddWithValue("@8", numedoc);

            cmd.ExecuteNonQuery();

            con.Close();

            this.Hide();
            Diagnostic di = new Diagnostic();
            di.Show();

        }
    }
}
