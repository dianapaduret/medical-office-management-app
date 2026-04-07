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
using System.IO;

namespace Proiect_atestat_2024
{
    public partial class Doctor : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Doctor()
        {
            string qs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\LOGINdb.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(qs);
            con.Open();
            InitializeComponent();
        }

        private void buttonAdauga_Click_1(object sender, EventArgs e)
        {
            string name = textBoxUtilizator1.Text;
            if (name.Length < 4)
            {
                MessageBox.Show("Numele de Utilizator este prea scurt!");
                return;
            }

            string qs = "SELECT COUNT(*) FROM login WHERE username = @1";
            cmd = new SqlCommand(qs, con);
            cmd.Parameters.AddWithValue("@1", name);
            int r = (int)cmd.ExecuteScalar();
            if (r > 0)
            {
                MessageBox.Show("Numele de Utilizator a fost inregistrat deja!");
                return;
            }

            string password = textBoxParola1.Text;
            if (password.Length < 6)
            {
                MessageBox.Show("Parola este prea scurta!");
                return;
            }

            string confirmationPassword = textBoxConfirmareParola.Text;
            if (password != confirmationPassword)
            {
                MessageBox.Show("Parolele nu coincid!");
                return;
            }

            string email = textBoxEmail.Text;
            bool at = false, dot = false;
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                    if (at == true || i == 0)
                    {
                        MessageBox.Show("Invalid email!");
                        return;
                    }
                    else
                        at = true;
                if (email[i] == '.')
                    if (at == false || email[i - 1] == '@' || i == email.Length - 1)
                    {
                        MessageBox.Show("Invalid email!");
                        return;
                    }
                    else
                        dot = true;
            }

            if (!(at && dot))
            {
                MessageBox.Show("Invalid email!");
                return;
            }

           int years = Convert.ToInt32(textBoxAniDeExperieta.Text);
            
            string specialty = textBoxSpecializare.Text;
            if (specialty.Length < 3)
            {
                MessageBox.Show("Specializarea este prea scurta!");
                return;
            }

            qs = "INSERT INTO login (USERNAME, PASSWORD, EMAIL, YEARSOFEXPERIENCE, SPECIALTY) VALUES (@1, @2, @3, @4, @5)";
            cmd = new SqlCommand(qs, con);
            cmd.Parameters.AddWithValue("@1", name);
            cmd.Parameters.AddWithValue("@2", password);
            cmd.Parameters.AddWithValue("@3", email);
            cmd.Parameters.AddWithValue("@4", years);
            cmd.Parameters.AddWithValue("@5", specialty);

            cmd.ExecuteNonQuery();

            con.Close();

            this.Hide();
            Home hm = new Home();
            hm.Show();

        }
    }
}
