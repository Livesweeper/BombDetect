using static SDL2.SDL;

namespace BombDetect;

public static class Timer
{
    public static float DeltaTime { get; private set; }
    
    private static ulong _now;
    private static ulong _last;
    
    public static void Tick()
    {
        _last = _now;
        _now = SDL_GetPerformanceCounter();

        DeltaTime = (float)((_now - _last) * 1000 / SDL_GetPerformanceFrequency());
    }
}