namespace BombDetect.Core;

public class Component
{
    public string Name;
    public Entity? Owner;

    private bool _active;

    public Component(string name)
    {
        Name = name;
    }

    public virtual void Start() { }
    public virtual void Update(float dt) { }
    public virtual void Render() { }
    public virtual void Destroy() { }

    public virtual void OnStateChange(bool state) { }

    public bool IsActive() => _active;
    public void SetActive(bool state)
    {
        _active = state;
    }
}