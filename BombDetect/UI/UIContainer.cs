namespace BombDetect.UI;

// a container for UI elements, kinda like a scene
public class UIContainer
{
    // the elements
    public List<Element> Elements { get; } = new();

    // add an element
    public void AddElement(Element element)
    {
        Elements.Add(element);
    }

    // render all elements
    public void Render()
    {
        foreach (var element in Elements)
        {
            element.OnRender();
        }
    }

    // destroy
    public void Destroy()
    {
        foreach (var element in Elements)
        {
            element.Destroy();
        }
    }
}