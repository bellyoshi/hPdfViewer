using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class WorkPDF
    {
        public static WorkPDF ThisWorkPDF { get; } = new WorkPDF();

        private IDisplay? display;
        public void SetDisplay(IDisplay display)
        {
            this.display = display;
        }
        
        //PDFファイルを開く処理
        public void Open(string filename)
        {
            doc = PdfiumViewer.PdfDocument.Load(filename);
            pageIndex = 0;
            Render();
        }

        private int pageIndex = 0;
        private PdfiumViewer.PdfDocument doc;
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

        public void Back()
        {
            if (doc == null)
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


        private void Render()
        {
            if (doc == null)
            {
                return;
            }
            if (display == null)
            {
                return;
            }
            Image image = doc.Render(pageIndex, display.Width, display.Height, 96, 96, false);
            var backImage = display.Image;
            display.Image = image;
            if (backImage != null)
            {
                backImage.Dispose();
            }
        }
        public void Repaint()
        {
            Render();
        }
    }
    
    public interface IDisplay {
        Image Image { get; set; }
        int Width { get; }
        int Height { get; }
    }
}
