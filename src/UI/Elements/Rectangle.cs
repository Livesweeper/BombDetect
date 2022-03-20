using static SDL2.SDL;

using System.Numerics;

namespace BombDetect.UI;

public class Rectangle : Element
{
    private SDL_Rect _rect;

    public Rectangle(string name, Vector2 position, Vector2 size, SDL_Color color, Element? parent = null)
        : base(name, position, size, color, parent)
    {
        _rect.x = (int)GlobalPosition.X;
        _rect.y = (int)GlobalPosition.Y;
        _rect.w = (int)Size.X;
        _rect.h = (int)Size.Y;
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        _rect.x = (int)GlobalPosition.X;
        _rect.y = (int)GlobalPosition.Y;
        _rect.w = (int)Size.X;
        _rect.h = (int)Size.Y;
    }

    public override void OnRender()
    {
        base.OnRender();

        Renderer.SetDrawColor(Color);
        SDL_RenderFillRect(Renderer.GetRenderer(), ref _rect);
    }
}