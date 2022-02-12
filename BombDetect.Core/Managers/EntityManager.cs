namespace BombDetect.Core;

public class EntityManager
{
    public Camera Camera;
    public Dictionary<string, Entity> Entities = new();

    public void Update(float dt)
    {

    }

    public void Render()
    {

    }

    public void AddEntity(Entity entity)
    {

    }

    public Entity? GetEntity<T>(string name) where T : Entity => Entities.ContainsKey(name) ? Entities[name] : null;
}