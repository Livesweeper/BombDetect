using static SDL2.SDL;
using static SDL2.SDL_mixer;
using static SDL2.SDL_ttf;
using static SDL2.SDL_image;

using BombDetect.Core;

namespace BombDetect;
public static class Engine
{
    public static bool Running = false;
    public static void Initialize(string title, int x, int y, int w, int h, SDL_WindowFlags flags)
    {
        Console.WriteLine("Initializing...");
        if (SDL_Init(SDL_INIT_EVERYTHING) < 0)
        {
            Console.WriteLine("Failed to init graphics, returning");
            return;
        }

        if (Mix_OpenAudio(44100, MIX_DEFAULT_FORMAT, 2, 2048) < 0)
        {
            Console.WriteLine("Failed to init audio, returning");
            return;
        }

        if (TTF_Init() < 0)
        {
            Console.WriteLine("Failed to init fonts, returning");
            return;
        }

        if (IMG_Init(IMG_InitFlags.IMG_INIT_PNG) < 0)
        {
            Console.WriteLine("Failed to init image rendering, returning");
            return;
        }

        Window.Initialize(title, x, y, w, h, flags);
        Renderer.Initialize();

        // make ctrl + shift + q quit the game
        Keyboard.KeyDown += (sender, e) =>
        {
            if (e.Key == SDL_Keycode.SDLK_q && e.Mod == (SDL_Keymod.KMOD_LCTRL | SDL_Keymod.KMOD_LSHIFT))
                Running = false;
        };

        Running = true;
        Console.WriteLine("Ready");
    }

    public static void Run()
    {
        Console.WriteLine("Trying to run");
        if (Running)
        {
            Console.WriteLine(SDL_GetError());
            try
            {
                Console.WriteLine("Running");
                while (Running)
                {
                    // background color thing
                    Renderer.SetDrawColor(Window.BackgroundColor);
                    SDL_RenderClear(Renderer.GetRenderer());

                    Timer.Tick();
                    UpdateEvents();
                    Update(Timer.DeltaTime);
                    Render();
                }
            }
            catch (Exception e)
            {
                Running = false;
                Console.WriteLine("This app just ran into a problem and it has to close.");
                Console.WriteLine("Please report the info below to the nearest developer:");
                Console.WriteLine("\n" + e.ToString());
                Console.WriteLine("\nPress any key to get out of this mess.");
                Console.ReadKey();
            }
        }

        Quit();
    }

    public static void Quit()
    {
        Console.WriteLine("Quitting...");
        Running = false;
        Destroy();
        Mix_Quit();
        IMG_Quit();
        TTF_Quit();
        SDL_Quit();
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
        
        SDL_RenderPresent(Renderer.GetRenderer());
    }

    public static void Destroy()
    {
        Console.WriteLine("Destroying everything");
        // destroy all scenes in SceneManager
        foreach (var scene in SceneManager.Scenes)
        {
            scene.Value.Destroy();
        }

        SDL_DestroyRenderer(Renderer.GetRenderer());
        SDL_DestroyWindow(Window.GetWindow());
    }
}
