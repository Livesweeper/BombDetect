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
    public Vector2 Size = new();
    
    private SDL_Rect _offRect;
    private SDL_Rect _cropRect;
    
    public Texture(string path, string name, Thing? parent = null) : base(name, parent)
    {
        // relative path
        Path = Directory.GetCurrentDirectory() + "/" + path;
        
        Surface = IMG_Load(Path);
        if (Surface == IntPtr.Zero) throw new Exception("Failed to load image: " + IMG_GetError());

        TexturePointer = SDL_CreateTextureFromSurface(Renderer.GetRenderer(), Surface);
        if (Parent is Sprite sprite)
        {
            Offset = sprite.Position;
        }

        SDL_QueryTexture(TexturePointer, out _, out _, out _cropRect.w, out _cropRect.h);

        _offRect.x = (int)Offset.X;
        _offRect.y = (int)Offset.Y;
        _offRect.w = _cropRect.w;
        _offRect.h = _cropRect.h;

        Size = new(
            (float)_cropRect.w,
            (float)_cropRect.h
        );
    }

    // override update to update texture offsets with the vector2s we have
    public override void OnUpdate(float deltaTime)
    {
        if (Parent is Sprite sprite)
        {
            Offset = sprite.Position;
        }

        _offRect.x = (int)Offset.X;
        _offRect.y = (int)Offset.Y;
        _offRect.w = _cropRect.w;
        _offRect.h = _cropRect.h;

        Size = new(
            (float)_cropRect.w,
            (float)_cropRect.h
        );
    }

    public void Draw()
    {
        SDL_RenderCopy(Renderer.GetRenderer(), TexturePointer, ref _cropRect, ref _offRect);
    }

    // add a way to destroy the texture
    public override void Destroy()
    {
        SDL_DestroyTexture(TexturePointer);
        SDL_FreeSurface(Surface);
    }
}