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

namespace Proiect_atestat_2024
{
    public partial class Diagnostic : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Diagnostic()
        {
            string qs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\LOGINdb.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(qs);
            con.Open();
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void buttonAdauga3_Click(object sender, EventArgs e)
        {
            string nume = textBoxNumePacient.Text;
            if (nume.Length < 4)
            {
                MessageBox.Show("Numele pacientului este invalid!");
                return;
            }

            string qs = "SELECT COUNT(*) FROM Diagnostic WHERE NumePacient = @1";
            cmd = new SqlCommand(qs, con);
            cmd.Parameters.AddWithValue("@1", nume);

            string diagnostic = textBoxDiagnostic.Text;
            string simptome = textBoxSimptome.Text;
            string tratament = textBoxTratament.Text;

            qs = "INSERT INTO Diagnostic (NumePacient, Diagnostic, Simptome, Tratament) VALUES (@1, @2, @3, @4)";
            cmd = new SqlCommand(qs, con);
            cmd.Parameters.AddWithValue("@1", nume);
            cmd.Parameters.AddWithValue("@2", diagnostic);
            cmd.Parameters.AddWithValue("@3", simptome);
            cmd.Parameters.AddWithValue("@4", tratament);

            cmd.ExecuteNonQuery();

            con.Close();

            this.Hide();
            Home home= new Home();
            home.Show();
        }
    }
}
