using System.Numerics;
using static SDL2.SDL;

namespace BombDetect.Core;

// a scene with things on it
public class Scene
{
    public List<Thing> Things { get; } = new();
    private bool _isRunning;

    public Scene()
    {
        
    }

    // start the scene
    public void Start()
    {
        _isRunning = true;
        // start all things
        foreach (var thing in Things)
        {
            thing.Start();
        }
    }

    // update the scene
    public void Update(float deltaTime)
    {
        // update all things if running
        if (_isRunning)
        {
            foreach (var thing in Things)
            {
                thing.OnUpdate(deltaTime);
            }
        }
    }

    // render the scene if we have any 2D things and if the scene is running
    public void Render()
    {
        // render all things if running
        if (_isRunning)
        {
            foreach (var thing in Things)
            {
                if (thing is Thing2D thing2D)
                {
                    thing2D.OnRender();
                }
            }
        }
    }

    // stop
    public void Stop()
    {
        _isRunning = false;
    }

    // destroy the scene
    public void Destroy()
    {
        // destroy all things
        foreach (var thing in Things)
        {
            thing.Destroy();
        }
    }
}