using PdfiumViewer;

namespace WinFormsApp1;


public partial class Form1 : Form , IDisplay
{
    private readonly OperationForm form;
    public Form1()
    {
        InitializeComponent();
        pictureBox1.AllowDrop = true;
        form = new OperationForm(this);
        form.Show();
        
        this.MouseWheel += Form1_MouseWheel;
        workPDF.SetDisplay(this);
    }

    
    private void Form1_MouseWheel(object? sender, MouseEventArgs e)
    {
        //マウスホイールでpageIndexを移動する
        if (sender == null) return;
        if(e.Delta < 0)
        {
            workPDF.Next();
        }
        else
        {
            workPDF.Back();
        }
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        TitleBarClick.DoNclButtonDown(this.Handle);
   
    }


    private WorkPDF workPDF = WorkPDF.ThisWorkPDF;

    public Image Image { get => pictureBox1.Image ; set => pictureBox1.Image = value ; }

    private void pictureBox1_DragDrop(object sender, DragEventArgs e)
    {
        //DropされたPDFファイルを開く
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                workPDF.Open(files[0]);
            }
        }
    }

    private void pictureBox1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data == null) return;
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
            //クリックされた位置に表示する。
            form.Location = new Point(e.X + this.Left , e.Y + this.Top);
            form.Show();
            form.Activate();
        }

    }
    private void pictureBox1_Resize(object sender, EventArgs e)
    {
        workPDF.Repaint();
    }
}