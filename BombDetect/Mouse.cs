using static SDL2.SDL;
using static SDL2.SDL.SDL_EventType;
using System.Numerics;

namespace BombDetect;

public static class Mouse
{
    private static List<int> ButtonsDown = new();
    public static Vector2 Position = new();

    // events
    public static event EventHandler<MouseButtonEventArgs> MouseDown;
    public static event EventHandler<MouseButtonEventArgs> MouseUp;
    public static event EventHandler<MouseMoveEventArgs> MouseMoved;
    public static event EventHandler<MouseWheelEventArgs> MouseWheel;

    public static void HandleMouseInput(SDL_Event e)
    {
        
        switch (e.type)
        {
            case SDL_MOUSEBUTTONDOWN:
                OnMouseDown(e);
                break;
            case SDL_MOUSEBUTTONUP:
                OnMouseUp(e);
                break;
            case SDL_MOUSEWHEEL:
                OnMouseWheel(e);
                break;
            case SDL_MOUSEMOTION:
                OnMouseMove(e);
                break;
        }
    }

    public static void OnMouseDown(SDL_Event e)
    {
        if (!ButtonsDown.Contains(e.button.button))
        {
            ButtonsDown.Add(e.button.button);
            MouseDown.Invoke(null, new(e.button.button));
        }
    }

    public static void OnMouseUp(SDL_Event e)
    {
        ButtonsDown.Remove(e.button.button); // simply ignores if it doesn't exist
        MouseUp.Invoke(null, new(e.button.button));
    }

    public static void OnMouseWheel(SDL_Event e)
    {
        MouseWheel.Invoke(null, new(e.wheel.direction));
    }

    public static void OnMouseMove(SDL_Event e)
    {
        Position.X = e.motion.x;
        Position.Y = e.motion.y;
        MouseMoved.Invoke(null, new(new(e.motion.xrel, e.motion.yrel)));
    }
}