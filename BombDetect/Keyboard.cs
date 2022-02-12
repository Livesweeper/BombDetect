using static SDL2.SDL;
using static SDL2.SDL.SDL_EventType;

namespace BombDetect;

public static class Keyboard
{
    private static List<SDL_Keycode> KeysDown;

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
            KeyDown.Invoke(null, new(e.key.keysym.sym));
        }
    }

    private static void OnKeyUp(SDL_Event e)
    {
        // if the key isn't in the list, no worries
        KeysDown.Remove(e.key.keysym.sym);
        KeyUp.Invoke(null, new(e.key.keysym.sym));
    }
}