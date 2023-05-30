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
    public partial class FormWebBrowser : Form
    {
        string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "relatorio.pdf";
        public FormWebBrowser()
        {
            InitializeComponent();
            //webBrowser1.Navigate(string.Format("http://www.andrealveslima.com.br/blog/index.php/2016/06/08/exibindo-pdf-no-windows-forms/", Application.StartupPath));
            webBrowser1.Navigate(string.Format(caminho, Application.StartupPath));
        }

        private void FormWebBrowser_Load(object sender, EventArgs e)
        {

        }
    }
}
