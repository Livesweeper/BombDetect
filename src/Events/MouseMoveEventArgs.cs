using System.Numerics;

namespace BombDetect;

public class MouseMoveEventArgs : EventArgs
{
    public Vector2 MouseDelta { get; }

    public MouseMoveEventArgs(Vector2 delta) : base()
    {
        MouseDelta = delta;
    }
}