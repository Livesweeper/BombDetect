//using static SDL2.SDL;

using System.Numerics;
using BombDetect.Core;

namespace BombDetect.Objects;

public class Sprite : Thing2D
{
    public Texture Texture { get; private set; }
    
    public Sprite(string name, Vector2 position, Vector2 size, 
        IntPtr texture, Thing? parent = null) : base(name, position, size, parent)
    {
        Texture = texture;
    }
    
    public override void OnRender()
    {
        // something will go here, trust
    }
}