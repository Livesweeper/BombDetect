using BombDetect.UI;

namespace BombDetect.Core;

// a scene with things on it
public class Scene
{
    public List<Thing> Things { get; } = new();
    private bool _isRunning;

    // only 1 UIContainer
    public UIContainer UIContainer { get; } = new();

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

    // update
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

    // render things
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
        // ui renders on top of everything else
        UIContainer.Render();
    }

    // stop
    public void Stop()
    {
        _isRunning = false;
    }

    // destroy everything!
    public void Destroy()
    {
        // destroy all things
        foreach (var thing in Things)
        {
            thing.Destroy();
        }
        // destroy the ui too, they're important
        UIContainer.Destroy();
    }

    // get the thing with the given name
    public Thing? GetThing(string name)
    {
        return Things.FirstOrDefault(t => t.Name == name);
    }
}