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
        btnPrint.Click += btnPrint_Click;
        this.Controls.Add(btnPrint);
    }

    // private void BtnPrint_Click(object sender, EventArgs e)
    // {
    //     // แสดง Print Preview Dialog
    //     PrintPreviewDialog previewDialog = new PrintPreviewDialog();
    //     previewDialog.Document = printDocument;
    //     previewDialog.Width = 800;
    //     previewDialog.Height = 600;
    //     previewDialog.ShowDialog();
    // }

    // private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
    // {
    //     // กำหนดเนื้อหาที่จะพิมพ์
    //     Font printFont = new Font("Tahoma", 14);
    //     e.Graphics.DrawString(printContent, printFont, Brushes.Black, new PointF(100, 100));
    // }

    private void PrintNow()
    {
        printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

        // แสดง Dialog ให้ผู้ใช้เลือกเครื่องพิมพ์ (ถ้าไม่ต้องการ dialog ให้ใช้ printDocument.Print() เลย)
        PrintDialog printDialog = new PrintDialog();
        printDialog.Document = printDocument;

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            printDocument.Print();
        }
    }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // ตั้งค่าฟอนต์
            Font printFont = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            // ข้อความที่จะพิมพ์
            string printText = "อันยอง";

            // ตำแหน่งที่พิมพ์ (X, Y)
            e.Graphics.DrawString(printText, printFont, brush, new PointF(20, 5));
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintNow();
        }
}
