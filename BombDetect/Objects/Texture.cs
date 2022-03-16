using static SDL2.SDL;
using static SDL2.SDL_image;

using System.Numerics;
using BombDetect.Core;

namespace BombDetect.Objects;

public class Texture : Thing
{
    public string Path;
    public IntPtr TexturePointer;
    public IntPtr Surface;
    
    public Vector2 Offset = new();
    public Vector2 CropSize = new(); // 0, 0 means no crop
    
    private SDL_Rect _offRect;
    private SDL_Rect _cropRect;
    
    public Texture(string path, string name, Thing? parent = null) : base(name, parent)
    {
        Path = path;
        
        Surface = IMG_Load(Path);
        TexturePointer = SDL_CreateTextureFromSurface(Renderer.GetRenderer(), Surface);
        if (Parent is Sprite sprite)
        {
            Offset = sprite.Position;
            CropSize = sprite.Size;
        }

        SDL_QueryTexture(TexturePointer, out _, out _, out _cropRect.w, out _cropRect.h);

        _offRect.x = (int)Offset.X;
        _offRect.y = (int)Offset.Y;
        _offRect.w = (int)CropSize.X == 0 ? _cropRect.w : (int)CropSize.X;
        _offRect.h = (int)CropSize.Y == 0 ? _cropRect.h : (int)CropSize.Y;
    }

    // override update to update texture offsets with the vector2s we have
    public override void OnUpdate(float deltaTime)
    {
        if (Parent is Sprite sprite)
        {
            Offset = sprite.Position;
            CropSize = sprite.Size;
        }

        _offRect.x = (int)Offset.X;
        _offRect.y = (int)Offset.Y;
        _offRect.w = (int)CropSize.X == 0 ? _cropRect.w : (int)CropSize.X;
        _offRect.h = (int)CropSize.Y == 0 ? _cropRect.h : (int)CropSize.Y;
    }

    public void Draw()
    {
        SDL_RenderCopy(Renderer.GetRenderer(), TexturePointer, ref _offRect, ref _offRect);
    }

    // add a way to destroy the texture
    public override void Destroy()
    {
        SDL_DestroyTexture(TexturePointer);
        SDL_FreeSurface(Surface);
    }
}