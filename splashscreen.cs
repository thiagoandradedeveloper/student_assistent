using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu_lateral
{
    public partial class splashscreen : Form
    {
        Random randNum = new Random();

        public splashscreen()
        {
            InitializeComponent();
        }

        private void novoForm()
        {
            Application.Run(new Form1());
        }

        int valor;
        private void acrescentar()
        {
            valor += randNum.Next(20);
            if (valor > 100) { valor = 100; }

            label2.Text = "(" + valor.ToString() + "%)";
            progressBar1.Value = valor;

            if (progressBar1.Value >= 100)
            {
                this.Close();
                Thread nt;
                nt = new Thread(novoForm);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            acrescentar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
