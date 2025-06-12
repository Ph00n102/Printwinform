using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace FormsApp;

public partial class Form1 : Form
{
      private PrintDocument printDocument = new PrintDocument();
    private string printContent = "อันยอง";
    public Form1()
    {
    
        InitializeComponent();

        // กำหนด Event ให้กับ PrintDocument
        printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

        // สร้างปุ่ม Print
        Button btnPrint = new Button();
        btnPrint.Text = "ปริ้น";
        btnPrint.Location = new Point(20, 20);
        btnPrint.Click += BtnPrint_Click;
        this.Controls.Add(btnPrint);
    }

    private void BtnPrint_Click(object sender, EventArgs e)
    {
        // แสดง Print Preview Dialog
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        previewDialog.Document = printDocument;
        previewDialog.Width = 800;
        previewDialog.Height = 600;
        previewDialog.ShowDialog();
    }

    private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        // กำหนดเนื้อหาที่จะพิมพ์
        Font printFont = new Font("Tahoma", 14);
        e.Graphics.DrawString(printContent, printFont, Brushes.Black, new PointF(100, 100));
    }
}
