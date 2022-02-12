using static SDL2.SDL;

namespace BombDetect;

internal static class Window
{
    private static IntPtr _window;
    private static SDL_Rect _rect = new();

    public static void Initialize(string title, int x, int y, int w, int h, SDL_WindowFlags flags)
    {
        _window = SDL_CreateWindow(title, x, y, w, h, flags);
        if (_window == IntPtr.Zero)
        {
            Console.WriteLine("failed to initialize window, returning");
            return;
        }

        _rect.x = x;
        _rect.y = y;
        _rect.w = w;
        _rect.h = h;
    }

    public static IntPtr GetWindow() => _window;
    public static SDL_Rect GetRect() => _rect;

    public static SDL_Rect GetDisplayBounds()
    {
        if (SDL_GetDisplayBounds(0, out var rect) != 0)
            Console.WriteLine("failed to get display bounds");

        return rect;
    }

    public static bool IsFullscreen()
    {
        uint flags = SDL_GetWindowFlags(_window);

        return flags == (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN 
                || flags == (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP;
    }
}