using static SDL2.SDL;
using static SDL2.SDL.SDL_EventType;

namespace BombDetect;

// disable warning for non-nullable fields
#pragma warning disable CS8618

public static class Keyboard
{
    public static List<SDL_Keycode> KeysDown = new();

    // events
    public static event EventHandler<KeyEventArgs> KeyDown;
    public static event EventHandler<KeyEventArgs> KeyUp;
    
    public static void HandleKeyboardInput(SDL_Event e)
    {
        if (e.type == SDL_KEYDOWN)
            OnKeyDown(e);
        else if (e.type == SDL_KEYUP)
            OnKeyUp(e);
    }

    private static void OnKeyDown(SDL_Event e)
    {
        if (!KeysDown.Contains(e.key.keysym.sym))
        {
            KeysDown.Add(e.key.keysym.sym);
            Events.SafeInvoke(KeyDown, new KeyEventArgs(e.key.keysym.sym));
        }
    }

    private static void OnKeyUp(SDL_Event e)
    {
        // if the key isn't in the list, no worries
        KeysDown.Remove(e.key.keysym.sym);
        Events.SafeInvoke(KeyUp, new KeyEventArgs(e.key.keysym.sym));
    }
}