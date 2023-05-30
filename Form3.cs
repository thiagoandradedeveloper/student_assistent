using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace menu_lateral
{
    public partial class Form3 : Form
    {
        DataTable dt = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }

        public void modificar()
        {

            double total = 0;
            double concluidas = 0;
            double naoConcluido = 0;

            string sql1 = "SELECT * FROM materias WHERE condicao = '0'";
            dt = Banco.queryExecute(sql1);
            if (dt.Rows.Count > 0)
            {
                naoConcluido = dt.Rows.Count;
            }

            string sql2 = "SELECT * FROM materias WHERE condicao = '1'";
            dt = Banco.queryExecute(sql2);
            if (dt.Rows.Count > 0)
            {
                concluidas = dt.Rows.Count;
            }

            total = naoConcluido + concluidas;

            double porcentagem = (concluidas / total) * 100;
            double restantePercentual = 100 - porcentagem;

            label1.Text = "Total de Matérias: " + total.ToString();
            label2.Text = "Matérias Concluidas: " + concluidas.ToString();
            label4.Text = "Porcentagem não concluída: " + restantePercentual.ToString("f") + "%";
            label3.Text = "Porcentagem concluída: " + porcentagem.ToString("f") + "%";
            label5.Text = "Matérias não Concluídas: " + naoConcluido.ToString();

            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Titles.Clear();

            chart1.Palette = ChartColorPalette.SemiTransparent;
            chart1.BackColor = Color.White;

            //Titulo principal
            var titulo = new Title();
            titulo.Font = new Font("Elephant", 22, FontStyle.Bold);
            titulo.ForeColor = Color.DarkBlue;
            titulo.Text = "Matérias Já Concluídas";
            chart1.Titles.Add(titulo);

            //Titulo secundario
            var titulo2 = new Title();
            titulo2.Font = new Font("Arial", 14, FontStyle.Bold);
            titulo2.ForeColor = Color.DarkRed;
            titulo2.Text = "Em Porcentagem (%)";
            chart1.Titles.Add(titulo2);

            chart1.Series.Add("pizza");
            chart1.Series["pizza"].ChartType = SeriesChartType.Pie;
            chart1.Series["pizza"].Points.AddXY("Restantes", Math.Round(restantePercentual, 2));
            chart1.Series["pizza"].Points.AddXY("Concluídas", Math.Round(porcentagem, 2));

            //coloca os valores ao inves do titulo
            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.Legends.Add("Legenda");
            chart1.Legends[0].Title = "Setores";


            //colocar em 3D
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            //inclinação e rotação
            chart1.ChartAreas[0].Area3DStyle.Inclination = 50;
            chart1.ChartAreas[0].Area3DStyle.Rotation = 60;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            modificar();           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            materiaGerenciamento mat = new materiaGerenciamento(this);
            mat.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new relatorio().ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new FormWebBrowser().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
