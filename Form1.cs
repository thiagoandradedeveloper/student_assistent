using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu_lateral
{
    public partial class Form1 : Form
    {
        private Form formAtivo;
        
        public Form1()
        {
            InitializeComponent();
        }
        private void FormShow(Form frm)
        {
            //fecha o formulario do panel se existir
            ActiveFormClose();

            //nao sei mas é necessario nao posso tirar
            //controla o formulario para quando for aparecer 
            //no panelform, acho que é para nao saltar a janela para fora
            //do form principal
            frm.TopLevel = false;

            //adiciona na variavel o novo form ativo
            formAtivo = frm;            

            //adiciona no panel um form
            panelForm.Controls.Add(frm);

            //coloca na frente
            frm.BringToFront();

            //chama o novo form
            frm.Show();
        }
        private void ActiveFormClose()
        {
            if (formAtivo != null)
            {
                formAtivo.Dispose();
                formAtivo.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*btnHome.Image = Properties.Resources.home64x64;
            btnMat.Image = Properties.Resources.l1;
            btnLivros.Image = Properties.Resources.l3;
            btnStu.Image = Properties.Resources.studing;*/

            //--------------------------
            //tras a janela para frente 
            //--------------------------
            this.BringToFront();
            this.Activate();
            this.Focus();

            //nao deixa outras passarem a frente
            //this.TopMost = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMat_Click(object sender, EventArgs e)
        {
            FormShow(new Form3());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActiveFormClose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Você tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }            
        }
    }
}
