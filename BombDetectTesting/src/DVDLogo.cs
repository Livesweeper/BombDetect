using BombDetect;
using BombDetect.Objects;
using System.Numerics;

using static SDL2.SDL;

namespace BombDetectTesting;

public class DVDLogo : Sprite
{
    // velocity thing
    private Vector2 _velocity;

    // rng
    private Random _rng;

    // hey i figured out how to change a texture's color
    private SDL_Color _color;

    // a constructor
    public DVDLogo() : base("DVD Logo", new(50, 50), "resources/dvd.png")
    {
        // random position and velocity
        _rng = new Random();
        Position = new(
            _rng.Next(50, 500),
            _rng.Next(50, 500)
        );
        _velocity = new(2, -2);

        Console.WriteLine(_velocity);

        // random color
        _color = RandomColor();
        SDL_SetTextureColorMod(Texture.TexturePointer, _color.r, _color.g, _color.b);
    }

    // returns a random bright color
    private SDL_Color RandomColor()
    {
        var color = new SDL_Color();
        color.r = (byte)_rng.Next(127, 255);
        color.g = (byte)_rng.Next(127, 255);
        color.b = (byte)_rng.Next(127, 255);
        color.a = 255;
        return color;
    }

    // render with dvd logic
    public override void OnRender()
    {
        Position += _velocity; // remember order of operations, don't get confused
        Texture.Offset = Position;

        // if we hit the edge, reverse direction
        if (Position.X < 0 || Position.X > Window.OriginalResolution.X - Texture.Size.X)
        {
            _velocity.X *= -1;

            // change color
            _color = RandomColor();
            SDL_SetTextureColorMod(Texture.TexturePointer, _color.r, _color.g, _color.b);
        }

        // same for Y
        if (Position.Y < 0 || Position.Y > Window.OriginalResolution.Y - Texture.Size.Y)
        {
            _velocity.Y *= -1;

            // change color too
            _color = RandomColor();
            SDL_SetTextureColorMod(Texture.TexturePointer, _color.r, _color.g, _color.b);
        }

        // base so it actually renders
        base.OnRender();

        // funny rectangle
        SDL_Rect rect = new()
        {
            x = 1,
            y = 1,
            w = (int)Window.OriginalResolution.X - 1,
            h = (int)Window.OriginalResolution.Y - 1
        };
        Renderer.SetDrawColor(_color);
        SDL_RenderDrawRect(Renderer.GetRenderer(), ref rect);
    }
}