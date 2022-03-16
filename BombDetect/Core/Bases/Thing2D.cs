using System.Numerics;

namespace BombDetect.Core;

// 2D thing
public class Thing2D : Thing
{
    public Vector2 Position;
    public Vector2 Size;

    // global position
    public Vector2 GlobalPosition { get; private set; }

    // z-index
    public int ZIndex { get; set; }

    public Thing2D(string name, Vector2 position, Vector2 size, Thing? parent = null) : base(name, parent)
    {
        Position = position;
        Size = size;
    }

    // override OnUpdate to calculate global position if the parent is also a 2D thing
    public override void OnUpdate(float deltaTime)
    {
        if (Parent is Thing2D parent2D)
        {
            GlobalPosition = parent2D.GlobalPosition + Position;
        }
        else
        {
            GlobalPosition = Position;
        }
    }
    
    // a render function
    public virtual void OnRender()
    {
        
    }
}