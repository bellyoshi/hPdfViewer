//todo �����N�t�@�C�����J����悤�ɂ���
//todo Ctrl + �}�E�X�X�N���[���Ŋg��A�k��
//todo �t�@�C�����j���[�̍쐬
//todo �A�v�������{�^��
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