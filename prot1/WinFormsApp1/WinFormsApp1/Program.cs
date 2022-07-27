//todo リンクファイルが開けるようにする
//todo Ctrl + マウススクロールで拡大、縮小
//todo ファイルメニューの作成
//todo アプリを閉じるボタン
//todo 前回起動時のファイルを再読み込み
//todo 前回の読んでいるページ位置の保存
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();              
            Application.Run(new ViewerForm());
        }
    }
}