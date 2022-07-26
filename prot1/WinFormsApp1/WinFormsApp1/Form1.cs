using PdfiumViewer;

namespace WinFormsApp1;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        pictureBox1.AllowDrop = true;
        
    }

    
    private Point mousePoint;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        //���N���b�N���ꂽ�Ƃ��Ƀ}�E�X�|�C���g��ێ�����B
        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
            mousePoint = e.Location;
        }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        //���N���b�N���ꂽ�Ƃ��ɕێ����Ă���ʂƂ̍������E�C���h�E�̈ړ��ʂƂ���
        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
            this.Left += e.X - mousePoint.X;
            this.Top += e.Y - mousePoint.Y;
        }
    }

    //�h���b�O�A���h�h���b�v���ꂽ�Ƃ���PDF���J��
    
    
    private PdfiumViewer.PdfDocument doc;
    //PDF�t�@�C�����J������
    private void OpenPDF(string filename)
    {
        doc = PdfiumViewer.PdfDocument.Load(filename);
        int pageIndex = 0;
        Image image = doc.Render(pageIndex, Width, Height, 96, 96, false);
        pictureBox1.Image = image;
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
}