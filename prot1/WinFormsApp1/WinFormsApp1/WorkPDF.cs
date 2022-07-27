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
            var size = GetRenderSize();
            Image image = doc.Render(pageIndex, size.Width, size.Height, 96, 96, false);
            var backImage = display.Image;
            display.Image = image;
            if (backImage != null)
            {
                backImage.Dispose();
            }
        }
        
        private Size GetRenderSize()
        {
            if(doc == null)
            {
                return new Size(0, 0);
            }
            if (display == null)
            {
                return new Size(0, 0);
            }
            var pdfSize = doc.PageSizes[pageIndex];
            var bound = display.DisplaySize;
            if (bound.Width == 0 || bound.Height == 0)
            {
                return new Size(0,0);
            }

            var pdfWdivH = (double)pdfSize.Width / pdfSize.Height;
            var boxWdivH = (double)bound.Width / bound.Height;
            if (boxWdivH > 10)
            {
                return new Size(0,0);
            }
            if (pdfWdivH<boxWdivH)
            {
                return new Size((int)(bound.Height* pdfWdivH), bound.Height);
            }
            else
            {
                return  new Size(bound.Width, (int)(bound.Width / pdfWdivH));
            }

        }
        public void Repaint()
        {
            Render();
        }
    }
    
    public interface IDisplay {
        Image Image { get; set; }
        Size DisplaySize { get; }
        
    }
}
