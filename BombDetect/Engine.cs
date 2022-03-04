using static SDL2.SDL;
using static SDL2.SDL_mixer;
using static SDL2.SDL_ttf;
using static SDL2.SDL_image;

using BombDetect.Core;

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

        if (IMG_Init(IMG_InitFlags.IMG_INIT_PNG) < 0)
        {
            Console.WriteLine("failed to init IMG, returning");
            return;
        }

        Window.Initialize(title, x, y, w, h, flags);
        Renderer.Initialize();

        Running = true;
    }

    public static void Run()
    {
        if (Running)
        {
            try
            {
                while (Running)
                {
                    Timer.Tick();
                    UpdateEvents();
                    Update(Timer.GetDeltaTime());
                    Render();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        Destroy();
    }

    public static void Quit()
    {
        Running = false;
        Destroy();
        SDL_Quit();
        Mix_Quit();
        IMG_Quit();
        TTF_Quit();
    }

    public static void UpdateEvents()
    {
        Events.Update();
    }

    public static void Update(float dt)
    {
        if (SceneManager.CurrentScene != null)
        {
            SceneManager.CurrentScene.Update(dt);
        }
    }

    public static void Render()
    {
        if (SceneManager.CurrentScene != null)
        {
            SceneManager.CurrentScene.Render();
        }
    }

    public static void Destroy()
    {
        // destroy all scenes in SceneManager
        foreach (var scene in SceneManager.Scenes)
        {
            scene.Value.Destroy();
        }
        
        SDL_DestroyRenderer(Renderer.GetRenderer());
        SDL_DestroyWindow(Window.GetWindow());
    }
}
