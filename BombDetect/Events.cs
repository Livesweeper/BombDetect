using static SDL2.SDL;
using static SDL2.SDL.SDL_EventType;

namespace BombDetect;

public static class Events
{
    public static void Update()
    {
        SDL_Event e;
        while (SDL_PollEvent(out e) == 1)
        {
            switch (e.type)
            {
                case SDL_QUIT:
                    Engine.Quit();
                    break;
                case SDL_KEYDOWN:
                case SDL_KEYUP:
                    Input.KeyEvent(e.key);
                    break;
                case SDL_MOUSEBUTTONDOWN:
                case SDL_MOUSEBUTTONUP:
                    Input.MouseButtonEvent(e.button);
                    break;
                case SDL_MOUSEWHEEL:
                    Input.MouseScrollWheelEvent(e.wheel);
                    break;
                case SDL_MOUSEMOTION:
                    Input.MouseMotionEvent(e.motion);
                    break;
            }
        }
    }
}