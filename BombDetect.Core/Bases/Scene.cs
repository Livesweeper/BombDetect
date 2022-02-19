using System.Numerics;
using static SDL2.SDL;

namespace BombDetect.Core;

// a scene with things on it
public class Scene
{
    public List<Thing> Things { get; } = new();

    public Scene()
    {
        
    }

    // start the scene
    public void Start()
    {
        // start all things
        foreach (var thing in Things)
        {
            thing.Start();
        }
    }

    // update the scene
    public void Update(float deltaTime)
    {
        // update all things
        foreach (var thing in Things)
        {
            thing.OnUpdate(deltaTime);
        }
    }

    // render the scene if we have any 2D things
    public void Render()
    {
        foreach (var thing in Things)
        {
            if (thing is Thing2D thing2D)
            {
                thing2D.OnRender();
            }
        }
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