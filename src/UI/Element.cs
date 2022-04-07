using BombDetect.Core;
using BombDetect;
using System.Numerics;

using static SDL2.SDL;

namespace BombDetect.UI;

// this is basically a Thing2D with extra steps (UI steps to be exact)
public class Element : Thing2D
{
    public Vector2 Size;
    public SDL_Color Color; // THAT'S IT!!!

    // now the constructor
    public Element(string name, Vector2 position, Vector2 size, SDL_Color color, Element? parent = null)
        : base(name, position, parent)
    {
        Size = size;
        Color = color;

        // the parent has to be another element (insane)
        if (!(parent is Element) && parent != null)
            throw new ArgumentException("Elements can only have other elements as parents");
    }
}
