using static SDL2.SDL;

namespace BombDetect;

public static class Timer
{
    private static float _deltaTime;
    private static ulong _now;
    private static ulong _last;
    
    public static void Tick()
    {
        _last = _now;
        _now = SDL_GetPerformanceCounter();

        _deltaTime = (float)((_now - _last) * 1000 / SDL_GetPerformanceFrequency());
    }

    public static float GetDeltaTime() => _deltaTime;
}