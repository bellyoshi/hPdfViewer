//todo リンクファイルが開けるようん
//引数
//オリジナルサイズに縦横比合わせる。
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if(args.Length == 2)
                WorkPDF.ThisWorkPDF.Open(args[1]);
            Application.Run(new Form1());
        }
    }
}