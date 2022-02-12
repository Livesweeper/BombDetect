namespace BombDetect;

public class MouseButtonEventArgs : EventArgs
{
    public int Button { get; }
    public MouseButtonEventArgs(int button)
    {
        Button = button;
    }
}