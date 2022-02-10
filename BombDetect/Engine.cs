using static SDL2.SDL;
using static SDL2.SDL_mixer;
using static SDL2.SDL_ttf;

namespace BombDetect;
public static class Engine
{
    public static bool Running;
    public static void Initialize(string title, int x, int y, int w, int h, SDL_WindowFlags flags)
    {
        if (SDL_Init(SDL_INIT_EVERYTHING) < 0)
        {
            Console.WriteLine("failed to init SDL, returning");
            return;
        }

        if (Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048) < 0)
        {
            Console.WriteLine("failed to init mixer, returning");
            return;
        }

        if (TTF_Init() < 0)
        {
            Console.WriteLine("failed to init TTF, returning");
            return;
        }

        Window.Initialize(title, x, y, w, h, flags);
        Renderer.Initialize();

        Running = true;
    }

    public static void Run(string sceneName)
    {

    }

    public static void Quit()
    {

    }

    public static void UpdateEvents()
    {
        Events.Update();
    }

    public static void Update(float dt)
    {

    }

    public static void Render()
    {

    }

    public static void Destroy()
    {
        
    }

    public static void LogError(string message)
    {

    }
}
