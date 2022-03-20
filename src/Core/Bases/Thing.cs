namespace BombDetect.Core;

public class Thing
{
    public string Name { get; }

    public Thing? Parent { get; }

    public bool Started { get; private set; }

    public Thing(string name, Thing? parent = null)
    {
        Name = name;
        Parent = parent;
    }

    public virtual void Start()
    {
        Started = true;
    }

    // event functions, according to Engine
    public virtual void OnUpdate(float deltaTime)
    {

    }

    // stop
    public virtual void Stop()
    {
        
    }

    // destroy the thing
    public virtual void Destroy()
    {
        Stop();
    }
}