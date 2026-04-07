using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_atestat_2024
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            PacientExistent p=new PacientExistent();
            p.Show();
        }

        private void buttonInchidere_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonLMedSpe_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lista_medici_in_functie_de_specializare lmedspe= new Lista_medici_in_functie_de_specializare();
            lmedspe.Show();
        }

        private void buttonLPaSpeMed_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lista_pacienti_in_functie_de_specializarea_medicului lpaspemed=new Lista_pacienti_in_functie_de_specializarea_medicului();  
            lpaspemed.Show();
        }

        private void buttonLGrupaSange_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lista_pacienti_in_functie_de_grupa_de_sange lgrupsange=new Lista_pacienti_in_functie_de_grupa_de_sange();
            lgrupsange.Show();
        }

        private void buttonLOras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lista_pacienti_in_functie_de_orasul_de_provenienta lgrup=new Lista_pacienti_in_functie_de_orasul_de_provenienta();
            lgrup.Show();
        }
    }
}
