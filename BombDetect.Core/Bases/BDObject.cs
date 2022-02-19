namespace BombDetect.Core;

public class BDObject
{
    public string Name { get; }

    public BDObject? Parent { get; }

    public BDObject(string name, BDObject? parent = null)
    {
        Name = name;
        Parent = parent;
    }
}