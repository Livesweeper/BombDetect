using System.Numerics;
using BombDetect.Core;

namespace BombDetect.Objects;

public class Sprite : Thing2D
{
    public Texture Texture { get; private set; }
    
    public Sprite(string name, Vector2 position, Vector2 size, Texture texture, Thing? parent = null)
        : base(name, position, size, parent)
    {
        Texture = texture;
        Texture.Offset = Position;
        Texture.CropSize = Size;
    }
    
    public override void OnRender()
    {
        Texture.Draw();
    }

    public override void Destroy()
    {
        Texture.Destroy();
    }
}