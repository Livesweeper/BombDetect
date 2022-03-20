using System.Numerics;

namespace BombDetect;

public class MouseWheelEventArgs : EventArgs
{
    public uint Direction { get; }

    public MouseWheelEventArgs(uint direction) : base()
    {
        Direction = direction;
    }
}