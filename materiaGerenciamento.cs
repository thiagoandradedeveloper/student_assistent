using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace menu_lateral
{
    public partial class materiaGerenciamento : Form
    {
        bool carregamentoConcluido = false;
        Form3 pai_2;
        DataTable dt = new DataTable();
        string sql = "SELECT * FROM materias ORDER BY id DESC";
        int materiaSelecionada = 0;

        public materiaGerenciamento(Form3 pai)
        {
            InitializeComponent();
            pai_2 = pai;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inserir newMat = new inserir(this);
            newMat.ShowDialog();
        }

        public void mostrar(string sql1){

            if (sql1 == null)
            {
                sql1 = sql;
            }
            
            dt = Banco.queryExecute(sql1);
            
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                //permite a seleção de uma unica linha
                dataGridView1.MultiSelect = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //impede a edição
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;

                //dados ocupando todo espaço
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //impedir reodernação das linhas em tempo de execução e impede click na linha de titulo 
                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

                //impede o redimencinamento das linhas ou colunas
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.AllowUserToResizeRows = false;

                //impede a edição do combobox
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                int contagem = dataGridView1.RowCount;

                for (int i = 0; i < contagem; i++)
                {
                    //[coluna, linha];
                    //dataGridView1[1, i].Value.ToString() + " - ";

                    if (dataGridView1[2, i].Value.ToString() == "0")
                    {
                        dataGridView1[2, i].Value = "Não Concluída";
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        dataGridView1[2, i].Value = "Concluída";
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                }

                //tira a coluna vazia do canto esquerdo
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

                //ajusta o tamanho da primeira linha
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[2].Width = 120;

                carregamentoConcluido = true;

                //muda o titulo da coluna
                dataGridView1.Columns[0].HeaderText = "Código";
                dataGridView1.Columns[1].HeaderText = "Matéria";
                dataGridView1.Columns[2].HeaderText = "Condição";

                groupBox1.Enabled = false;
            }
        }

        private void materiaGerenciamento_Load(object sender, EventArgs e)
        {
            mostrar(null);
            groupBox1.Enabled = false;
        }

        private void materiaGerenciamento_FormClosed(object sender, FormClosedEventArgs e)
        {
            pai_2.modificar();
        }

        private void linhaSelecionada()
        {
            groupBox1.Enabled = true;
            if (carregamentoConcluido)
            {
                string valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();

                string condicao = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();

                if (condicao == "Concluída")
                {
                    comboBox1.SelectedIndex = 1;
                }
                else
                {
                    comboBox1.SelectedIndex = 0;
                }
                label5.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                materiaSelecionada = int.Parse(label5.Text);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            linhaSelecionada();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Você tem certeza que deseja excluir esta materia? \nCaso opte por excluir, você não terá como recuperar o registro!", "Confirmação de exclusão!", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string sqlDel = "DELETE FROM materias WHERE id = '" + materiaSelecionada.ToString() + "'";
                dt = Banco.queryExecute(sqlDel);
                mostrar(null);
                MessageBox.Show("Matéria excluída com sucesso!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string newSql;
            dataGridView1.DataSource = null;
            newSql = "SELECT * FROM materias WHERE materia LIKE '%" + textBox2.Text + "%' ORDER BY id DESC";
            //MessageBox.Show(newSql);
            //newSql = sql;
            mostrar(newSql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linhaSelecionada();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, "Você tem certeza que deseja alterar esta matária? \nCaso opte pela alteração, as informaçoes anteriores não serão preservadas!", "Confirmação de exclusão!", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string sqlAlt = "UPDATE materias SET materia = '" + textBox1.Text + "', condicao = '" + comboBox1.SelectedIndex.ToString() + "' WHERE id='" + materiaSelecionada.ToString() + "'";
                dt = Banco.queryExecute(sqlAlt);
                mostrar(null);
                MessageBox.Show("Matéria alterada com sucesso!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
