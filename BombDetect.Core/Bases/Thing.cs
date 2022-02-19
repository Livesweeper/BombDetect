namespace BombDetect.Core;

public class Thing
{
    public string Name { get; }

    public Thing? Parent { get; }

    public Thing(string name, Thing? parent = null)
    {
        Name = name;
        Parent = parent;
    }

    public virtual void Start()
    {

    }

    // event functions, according to Engine
    public virtual void OnUpdate(float deltaTime)
    {

    }

    // destroy the thing
    public virtual void Destroy()
    {

    }
}