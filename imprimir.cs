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
using Org.BouncyCastle.Ocsp;
using PdfiumViewer;

namespace menu_lateral
{
    public partial class imprimir : Form
    {
        relatorio report;
        PdfiumViewer.PdfViewer pdf;

        public imprimir(relatorio rel)
        {
            InitializeComponent();
            report = rel;
        }

        private void imprimir_Load(object sender, EventArgs e)
        {
            report.fs.Close();
            /*byte[] bytes = System.IO.File.ReadAllBytes("c:\\pdf\\relatorio.pdf");
            var stream = new System.IO.MemoryStream(bytes);
            PdfDocument pd = PdfDocument.Load(stream);*/

            //this.Visible = false;
            //this.Hide();

            PdfiumViewer.PdfViewer pdf = new PdfiumViewer.PdfViewer();
            this.Controls.Add(pdf);
            pdf.Width = this.Width - 25;
            pdf.Height = this.Height - 50;
            pdf.BorderStyle = BorderStyle.FixedSingle;
            pdf.Left = 5;
            pdf.Top = 4;
            pdf.ZoomMode = PdfViewerZoomMode.FitWidth;
            byte[] bytes = System.IO.File.ReadAllBytes("c://pdf//relatorio.pdf");
            var stream = new System.IO.MemoryStream(bytes);
            PdfDocument pdfDocument = PdfDocument.Load(stream);
            pdf.Document = pdfDocument;
            //pdf.Visible = false;
            var p = pdf.Document.CreatePrintDocument();
            //p.Print();

            // Permite que o usuário escolha o intervalo de páginas que deseja imprimir
            printDialog1.AllowSomePages = true;

            // Mostra o botão de ajuda.
            printDialog1.ShowHelp = true;

            // Defina a propriedade Document para o PrintDocument para
            // qual o evento PrintPage foi manipulado. Para exibir o
            // caixa de diálogo, esta propriedade ou a propriedade PrinterSettings
            // deve ser definido
            printDialog1.Document = p;

            DialogResult result = printDialog1.ShowDialog();

            // Se o resultado for OK imprima o documento.
            if (result == DialogResult.OK)
            {
                printDialog1.Document.Print();
                //this.Close();
            }
            if (result == DialogResult.Cancel)
            {
                //this.Close();
            }
        }
    }
}
