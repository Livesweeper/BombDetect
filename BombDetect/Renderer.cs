using static SDL2.SDL;

namespace BombDetect;

public static class Renderer
{
    private static IntPtr _renderer;
    private static SDL_Color _drawColor;

    private static int _windowWidth;
    private static int _displayWidth;
    private static int _windowHeight;
    private static int _displayHeight;

    internal static void Initialize()
    {
        _renderer = SDL_CreateRenderer(Window.GetWindow(), -1, 
                SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
        if (_renderer == IntPtr.Zero)
        {
            Console.WriteLine("failed to initialize renderer, returning");
            return;
        }

        _windowWidth = Window.GetRect().w;
        _displayWidth = Window.GetDisplayBounds().w;
        _windowHeight = Window.GetRect().h;
        _displayHeight = Window.GetDisplayBounds().h;

        SDL_Rect viewport = new() { x = 0, y = 0, w = _windowWidth, h = _windowHeight };

        if (Window.IsFullscreen())
        {
            if (_displayWidth - _windowWidth > 0)
                viewport.x = (_displayWidth - _windowWidth) / 2;

            if (_displayHeight - _windowHeight > 0)
                viewport.y = (_displayHeight - _windowHeight) / 2;
        }

        SDL_RenderSetViewport(_renderer, ref viewport);
    }

    public static IntPtr GetRenderer() => _renderer;
    public static SDL_Color GetDrawColor() => _drawColor;

    public static void SetDrawColor(byte r, byte g, byte b, byte a)
    {
        SDL_Color color = new() { r = r, g = g, b = b, a = a };

        _drawColor = color;
        SDL_SetRenderDrawColor(_renderer, r, g, b ,a);
    }

    public static void UpdateViewportRect()
    {
        SDL_Rect viewport = new() { x = 0, y = 0, w = _windowWidth, h = _windowHeight};
        SDL_Color color = GetDrawColor();
        SetDrawColor(color.r, color.g, color.b, color.a);

        SDL_RenderFillRect(_renderer, ref viewport);
        SDL_RenderDrawRect(_renderer, ref viewport);
    }
}