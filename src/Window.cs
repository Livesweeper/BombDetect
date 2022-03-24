using static SDL2.SDL;

namespace BombDetect;

public static class Window
{
    public static SDL_Color BackgroundColor;

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

        BackgroundColor = new()
        {
            r = 0,
            g = 0,
            b = 0,
            a = 255
        };
    }

    // making a public field called "Window" is a bad idea when the class is also named "Window"
    // - c# compiler, 2022 i think
    public static IntPtr GetWindow() => _window;

    // i actually have good reasoning to not make _rect public!!!
    public static SDL_Rect GetRect()
    {
        // it is a very good idea to not update the rect every frame so let's do it when this is called
        UpdateRect();
        return _rect;
    }

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

    public static void UpdateRect()
    {
        SDL_GetWindowPosition(_window, out _rect.x, out _rect.y);
        SDL_GetWindowSize(_window, out _rect.w, out _rect.h);
    }
}