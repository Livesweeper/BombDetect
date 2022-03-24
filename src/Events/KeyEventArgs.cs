using static SDL2.SDL;

namespace BombDetect;

public class KeyEventArgs : EventArgs
{
    public SDL_Keycode Key { get; }
    public SDL_Keymod Mod { get; }
    public KeyEventArgs(SDL_Keycode key, SDL_Keymod mod)
    {
        Key = key;
        Mod = mod;
    }
}