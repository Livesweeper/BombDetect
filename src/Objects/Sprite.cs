using System.Numerics;
using BombDetect.Core;

namespace BombDetect.Objects;

public class Sprite : Thing2D
{
    public Texture Texture { get; private set; }
    
    public Sprite(string name, Vector2 position, string imagePath, Thing? parent = null)
        : base(name, position, parent)
    {
        Texture = new(imagePath, name + "Texture", this);
        Texture.Offset = Position;
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