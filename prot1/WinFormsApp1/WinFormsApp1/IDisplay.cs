namespace WinFormsApp1;

public interface IDisplay
{
    Image Image { get; set; }
    Size DisplaySize { get; }

    void SetMaxSize(Size size);

    Screen GetScreen();

}
