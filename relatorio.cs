using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using PdfiumViewer;

namespace menu_lateral
{
    public partial class relatorio : Form
    {
        public FileStream fs;
        PdfiumViewer.PdfViewer pdf;
        string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "relatorio.pdf";

        public relatorio()
        {
            InitializeComponent();
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fs.Close();
            new imprimir(this).ShowDialog();
        }



        private void relatorio_Load(object sender, EventArgs e)
        {
            fs = new FileStream(caminho, FileMode.Open);
            pdfViewer1.Document = new Apitron.PDF.Rasterizer.Document(fs);
            pdfViewer1.Zoom = 1;
        }

        private void relatorio_FormClosed(object sender, FormClosedEventArgs e)
        {
            fs.Close();
        }

        private void button2_Click(object sender2, EventArgs ex)
        {
            /*if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PrintJob printJob = new PrintJob(Printer.Default, openFileDialog1.FileName);
                printJob.Print();
            }*/

            printDocument1.PrinterSettings.PrintFileName = caminho;
            printDocument1.DocumentName = caminho;
            printDocument1.PrintController = new StandardPrintController();
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fs.Close();
            
            PdfiumViewer.PdfViewer pdf = new PdfiumViewer.PdfViewer();
            byte[] bytes = System.IO.File.ReadAllBytes(caminho);
            var stream = new System.IO.MemoryStream(bytes);
            PdfDocument pdfDocument = PdfDocument.Load(stream);
            pdf.Document = pdfDocument;
            var p = pdf.Document.CreatePrintDocument();

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
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //abre o pdf externamente
            System.Diagnostics.Process.Start(caminho);
        }
    }
}
