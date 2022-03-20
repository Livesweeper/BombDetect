using static SDL2.SDL;

namespace BombDetect;

public class KeyEventArgs : EventArgs
{
    public SDL_Keycode Key { get; }
    public KeyEventArgs(SDL_Keycode key)
    {
        Key = key;
    }
}