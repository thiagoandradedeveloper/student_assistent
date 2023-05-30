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
    public partial class inserir : Form
    {
        public string retorno;
        materiaGerenciamento matRetorno;
        public inserir(materiaGerenciamento mat)
        {
            InitializeComponent();
            matRetorno = mat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string materia  = textBox1.Text;
            string condicao = comboBox1.Text;
            if (materia != string.Empty)
            {
                if (condicao == "Concluída")
                {
                    condicao = "1";
                }
                else
                {
                    condicao = "0";
                }
                Banco.queryExecute("INSERT INTO materias (materia,condicao) values ('" + materia + "','" + condicao + "')");
                MessageBox.Show("Nova Matéria Inserida com sucesso!");
                matRetorno.mostrar(null);
                this.Close();
            }
            else
            {
                MessageBox.Show("Não é possível inserir valor nulo");
            }
        }

        private void inserir_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }
    }
}
