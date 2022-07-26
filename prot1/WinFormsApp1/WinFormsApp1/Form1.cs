using PdfiumViewer;

namespace WinFormsApp1;


public partial class Form1 : Form
{
    private readonly OperationForm form;
    public Form1()
    {
        InitializeComponent();
        pictureBox1.AllowDrop = true;
        form = new OperationForm(this);
        form.Show();
        
        this.MouseWheel += Form1_MouseWheel;
    }

    
    private Point mousePoint;
    private void Form1_MouseWheel(object? sender, MouseEventArgs e)
    {
        //�}�E�X�z�C�[����pageIndex���ړ�����
        if (sender == null) return;
        if(e.Delta < 0)
        {
            Next();
        }
        else
        {
            Back();
        }
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        TitleBarClick.DoNclButtonDown(this.Handle);
   
    }

    private int pageIndex = 0;
    private PdfiumViewer.PdfDocument doc;
    //PDF�t�@�C�����J������
    private void OpenPDF(string filename)
    {
        doc = PdfiumViewer.PdfDocument.Load(filename);
        pageIndex = 0;
        Render();
    }

    private void pictureBox1_DragDrop(object sender, DragEventArgs e)
    {
        //Drop���ꂽPDF�t�@�C�����J��
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
        //�E�N���b�N���ꂽ��OperationForm���ĕ\������
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
        //PDF�����̃y�[�W�Ɉړ�����B
        if (pageIndex < doc.PageCount - 1)
        {
            pageIndex++;
            Render();
        }

    }
    private void Render()
    {
        if(doc == null)
        {
            return;
        }
        Image image = doc.Render(pageIndex,pictureBox1. Width,pictureBox1. Height, 96, 96, false);
        var backImage = pictureBox1.Image;
        pictureBox1.Image = image;
        if (backImage != null)
        {
            backImage.Dispose();
        }
    }            
    public void Back()
    {
        if(doc == null)
        {
            return;
        }
        //PDF��O�̃y�[�W�Ɉړ�����B
        if (pageIndex > 0)
        {
            pageIndex--;
            Render();
        }
    }

    private void pictureBox1_Resize(object sender, EventArgs e)
    {
        Render();
    }
}