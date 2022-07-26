using System.Runtime.InteropServices;
namespace WinFormsApp1;

internal class TitleBarClick
{
    private const int WM_NCLBUTTONDOWN = 0xA1;
    private const int HT_CAPTION = 0x2;
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(
IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    [DllImportAttribute("user32.dll")]
    private static extern bool ReleaseCapture();

    public static void DoNclButtonDown(IntPtr Handle)
    {
        ReleaseCapture();
        //タイトルバーでマウスの左ボタンが押されたことにする
        SendMessage(Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
    }
}
