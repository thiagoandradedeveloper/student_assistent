using menu_lateral;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace menu_lateral
{
    public partial class login : Form
    {
        Form1 form1;
        DataTable dt = new DataTable();
        public login(Form1 f)
        {
            //InitializeComponent();
            form1 = f;
        }

        private void login_Load(object sender, EventArgs e)
        {
            DataTable newDataTable = new DataTable();
            newDataTable.Columns.Add("Código", typeof(int));
            newDataTable.Columns.Add("Nome");
            newDataTable.Rows.Add(1, "Lucas");
            newDataTable.Rows.Add(2, "Debora");
            newDataTable.Rows.Add(3, "Thiago");
            //dataGridView2.DataSource = newDataTable;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void arquivoTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ok deu certo!");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help!");
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string email = textBox1.Text;
            if (email == "")
            {
                MessageBox.Show("Digite um email válido!");
                textBox1.Focus();
                return;
            }
            string sql = "select * from email where email = '" + email + "'";
            dt = Banco.consulta(sql);
            if (dt.Rows.Count > 0)
            {
                form1.label10.Text = "Logado: " + dt.Rows[0].ItemArray[1].ToString();
                form1.label10.Text = int.Parse(dt.Rows[0].Field<Int64>("id").ToString()) + " - " + form1.label10.Text;
                form1.pictureBox2.Image = Properties.Resources.green;
                this.Close();
            }
            else
            {
                form1.pictureBox2.Image = Properties.Resources.yellow;
                MessageBox.Show("Acesso negado!");
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Banco.inserir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //dt = Banco.somaId();

            MessageBox.Show("A soma de todos os Ids é: " + dt.Rows[0].ItemArray[0].ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            /*string sql = "select * from email";
            dt = Banco.consulta(sql);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].HeaderText = "teste";
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns["id"].Visible = false;
                foreach (DataRow row in dt.Rows)
                {
                    MessageBox.Show(row["email"].ToString());
                    Console.WriteLine(row["email"].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MessageBox.Show(dt.Rows[i]["id"].ToString());
                }
            }*/
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //string valor = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //MessageBox.Show(valor);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // login
            // 
            this.ClientSize = new System.Drawing.Size(590, 406);
            this.Name = "login";
            this.Load += new System.EventHandler(this.login_Load_1);
            this.ResumeLayout(false);

        }

        private void login_Load_1(object sender, EventArgs e)
        {

        }
    }
}

