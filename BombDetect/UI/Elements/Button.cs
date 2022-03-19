using static SDL2.SDL;

using System.Numerics;

namespace BombDetect.UI;

// you can't initialize an event handler, shut up c# compiler
#pragma warning disable CS8618

public class Button : Element
{
    public TextLabel Label { get; set; }
    public Rectangle Rect { get; set; }

    public SDL_Color HoverColor { get; set; }
    public SDL_Color PressColor { get; set; }

    // a little thing for me
    private bool _mouseDown = false;

    // clicked event!
    public event EventHandler Clicked;

    public Button
        (string name, Vector2 position, Vector2 size, SDL_Color color, string text, IntPtr font, Element? parent = null)
        : base(name, position, size, color, parent)
    {
        Label = new TextLabel("Label", new Vector2(0, 0), color, text, font, this);
        Rect = new Rectangle("Rect", new Vector2(0, 0), size, color, this);

        // make the rect slightly wider than the label
        Rect.Size = new(Label.GetTextWidth() + 10, Size.Y);

        // center the label (position is relative to the rect)
        Label.Position = new(5, 0); // it's that simple

        // hover color is slightly lighter
        HoverColor = new()
        {
            r = (byte)(Color.r + (255 - Color.r) * 0.5f),
            g = (byte)(Color.g + (255 - Color.g) * 0.5f),
            b = (byte)(Color.b + (255 - Color.b) * 0.5f),
            a = Color.a
        };
        
        // press color is slightly darker
        PressColor = new()
        {
            r = (byte)(Color.r - (Color.r * 0.5f)),
            g = (byte)(Color.g - (Color.g * 0.5f)),
            b = (byte)(Color.b - (Color.b * 0.5f)),
            a = Color.a
        };

        // connect events
        Mouse.MouseDown += (sender, e) => _mouseDown = true;
        Mouse.MouseUp += OnClick;
    }

    private void OnClick(object? sender, MouseButtonEventArgs e)
    {
        if (_mouseDown)
        {
            _mouseDown = false;
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        // update rect colors based on the mouse
        if (Mouse.Inside(Position, Size))
        {
            if (_mouseDown)
                Rect.Color = PressColor;
            else
                Rect.Color = HoverColor;
        }
        else
            Rect.Color = Color;
    }
}