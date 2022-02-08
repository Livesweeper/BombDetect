using static SDL2.SDL;
using System.Collections.Generic;
using System.Numerics;

namespace BombDetect;

public static class Input
{
    // what the fuck c#?
    private static Dictionary<int, bool> _keys = new();
    private static Dictionary<int, bool> _keysNoRepeat = new();
    private static Dictionary<int, bool> _keysUp = new();
    private static Dictionary<int, bool> _buttons = new();
    private static Dictionary<int, bool> _buttonsNoRepeat = new();
    private static Dictionary<int, bool> _buttonsUp = new();

    public static short _scrollWheel = 0;
    public static Vector2 _mousePos;

    public static void Update()
    {
        foreach (var button in _buttonsUp.Keys)
        {
            
        }
    }

    public static void End()
    {

    }

    public static void KeyEvent(SDL_KeyboardEvent e)
    {

    }

    public static void MouseButtonEvent(SDL_MouseButtonEvent e)
    {

    }

    public static void MouseScrollWheelEvent(SDL_MouseWheelEvent e)
    {

    }

    public static void MouseMotionEvent(SDL_MouseMotionEvent e)
    {

    }
}