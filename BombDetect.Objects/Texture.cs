using static SDL2.SDL;
using static SDL2.SDL_image;

using System.Numerics;
using BombDetect;

namespace BombDetect.Objects;

public class Texture : Thing
{
    public string Path;
    public IntPtr Texture;
    public IntPtr Surface;
    
    public Vector2 Offset;
    public Vector2 CropSize;
    
    private SDL_Rect _offRect;
    private SDL_Rect _cropRect;
    
    public Texture(string path, string name, Thing? parent = null)
        : base(name, parent)
    {
        Path = path;
        
        Surface = IMG_Load(Path);
        Texture = SDL_CreateTextureFromSurface(Renderer.GetRenderer(), Surface);
        if (Parent is Sprite sprite)
        {
            Offset = sprite.Position;
            CropSize = sprite.Size;
            
        }
        else throw new ArgumentException("Textures can't be used with this object");
    }
}