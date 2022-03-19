// TODO: make text change dynamically, for timers and stuff
using static SDL2.SDL_ttf;
using static SDL2.SDL;

using System.Numerics;

namespace BombDetect.UI;

public class TextLabel : Element
{
    public string Text { get; set; }
    public IntPtr Font { get; set; }

    // sdl pointers
    private IntPtr _texture;
    private IntPtr _surface;

    // some rects
    private SDL_Rect _posRect;
    private SDL_Rect _sizeRect;

    public TextLabel(string name, Vector2 position, SDL_Color color, string text, IntPtr font, Element? parent = null) 
        : base(name, position, new(), color, parent)
    {
        Text = text;
        Font = font;

        if (Font == IntPtr.Zero)
            throw new ArgumentException("Font must be a valid SDL_Font pointer");

        _surface = TTF_RenderText_Blended(Font, Text, Color);
        _texture = SDL_CreateTextureFromSurface(Renderer.GetRenderer(), _surface);

        SDL_QueryTexture(_texture, out _, out _, out _sizeRect.w, out _sizeRect.h);
        _posRect.x = (int)GlobalPosition.X;
        _posRect.y = (int)GlobalPosition.Y;
        _posRect.w = _sizeRect.w;
        _posRect.h = _sizeRect.h;
    }

    // override OnUpdate to update rects
    public override void OnUpdate(float dt)
    {
        base.OnUpdate(dt);

        _posRect.x = (int)GlobalPosition.X;
        _posRect.y = (int)GlobalPosition.Y;
        _posRect.w = _sizeRect.w;
        _posRect.h = _sizeRect.h;
    }

    // render
    public override void OnRender()
    {
        SDL_RenderCopy(Renderer.GetRenderer(), _texture, ref _sizeRect, ref _posRect);
    }

    // destroy everything we just created
    public override void Destroy()
    {
        SDL_DestroyTexture(_texture);
        SDL_FreeSurface(_surface);
        base.Destroy();
    }

    public int GetTextWidth() => _sizeRect.w;

    public int GetTextHeight() => _sizeRect.h;
}