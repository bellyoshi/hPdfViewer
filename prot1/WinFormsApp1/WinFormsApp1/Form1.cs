using PdfiumViewer;

namespace WinFormsApp1;


public partial class Form1 : Form
{
    OperationForm form;
    public Form1()
    {
        InitializeComponent();
        pictureBox1.AllowDrop = true;
        form = new OperationForm(this);
        form.Show();
    }




    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        TitleBarClick.DoNclButtonDown(this.Handle);
    

    }



    int pageIndex = 0;
    private PdfiumViewer.PdfDocument doc;
    //PDFファイルを開く処理
    private void OpenPDF(string filename)
    {
        doc = PdfiumViewer.PdfDocument.Load(filename);
        pageIndex = 0;
        Render();
    }

    private void pictureBox1_DragDrop(object sender, DragEventArgs e)
    {
        //DropされたPDFファイルを開く
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                OpenPDF(files[0]);
            }
        }
    }

    private void pictureBox1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Move;
        }
    }

    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        //右クリックされたらOperationFormを再表示する
        if (e.Button == MouseButtons.Right)
        {
            form.Show();
        }

    }
    
    public void Next()
    {
        if (doc == null)
        {
            return;
        }
        //PDFを次のページに移動する。
        if (pageIndex < doc.PageCount - 1)
        {
            pageIndex++;
            Render();
        }

    }
    private void Render()
    {
        Image image = doc.Render(pageIndex, Width, Height, 96, 96, false);
        pictureBox1.Image = image;
    }            
    public void Back()
    {
        if(doc == null)
        {
            return;
        }
        //PDFを前のページに移動する。
        if (pageIndex > 0)
        {
            pageIndex--;
            Render();
        }
    }
}