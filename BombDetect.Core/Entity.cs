namespace BombDetect.Core;

public class Entity
{
    public EntityManager? Manager = null;
    public Entity? Parent = null;

    public List<Entity> Children = new();
    public string Name;

    private bool _enabled;
    private Dictionary<string, Component> Components = new();

    // construction
    public Entity(string name)
    {
        Name = name;
    }

    public void Update(float dt)
    {

    }

    public void Render()
    {

    }

    public void AddComponent<T>(T component) where T : Component
    {
        Components.Add(component.Name, component);
    }

    public Component? GetComponent<T>(string name) where T : Component
    {
        return Components.ContainsKey(name) ? Components[name] : null;
    }
}