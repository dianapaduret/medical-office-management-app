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
    public partial class PacientExistent : Form
    {
        public PacientExistent()
        {
            InitializeComponent();
        }

        private void buttonAdauga2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pacient pa=new Pacient();
            pa.Show();
        }

        private void buttonCauta_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\LOGINdb.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) FROM pacienti WHERE NumePacient='" + textBoxNumePacient.Text + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string nume = textBoxNumePacient.Text;

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Diagnostic di = new Diagnostic();
                di.Show();
            }
            else
            {
                MessageBox.Show("Numele pacientului este incorect!");
            }
        }
    }
}
