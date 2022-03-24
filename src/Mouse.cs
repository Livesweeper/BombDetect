using static SDL2.SDL;
using static SDL2.SDL.SDL_EventType;

using System.Numerics;

namespace BombDetect;

// disable that same warning here too
#pragma warning disable CS8618

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
            
            // invoke (safely)
            Events.SafeInvoke(MouseDown, new MouseButtonEventArgs(e.button.button));
        }
    }

    public static void OnMouseUp(SDL_Event e)
    {
        ButtonsDown.Remove(e.button.button); // simply ignores if it doesn't exist

        // invoke this one the cool way
        Events.SafeInvoke(MouseUp, new MouseButtonEventArgs(e.button.button));
    }

    public static void OnMouseWheel(SDL_Event e)
    {
        // ya
        Events.SafeInvoke(MouseWheel, new MouseWheelEventArgs(e.wheel.direction));
    }

    public static void OnMouseMove(SDL_Event e)
    {
        // set position using SDL_GetMouseState
        SDL_GetMouseState(out var x, out var y);
        Position = new(x, y);

        // this is the exact place where i found the bug, fortunately i have a fix!!!
        // invoke MouseMoved with mouse delta
        Events.SafeInvoke(MouseMoved, new MouseMoveEventArgs(new(e.motion.xrel, e.motion.yrel)));
    }

    // is the mouse position inside the given rectangle? (vector2)
    public static bool Inside(Vector2 pos, Vector2 size) 
        => Position.X >= pos.X && Position.X <= pos.X + size.X && Position.Y >= pos.Y && Position.Y <= pos.Y + size.Y;
}