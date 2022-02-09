namespace BombDetect;
public class Engine
{
    private bool _running;
    private static Engine _engine = new();

    public static void Initialize(string title, int x, int y, int w, int h, uint flags)
    {
        Get().IInitialize(title, x, y, w, h, flags);
    }

    public static void Run(string sceneName)
    {
        Get().IRun(sceneName);
    }

    public static void Quit()
    {
        Get().IQuit();
    }

    public static void Terminate(string message)
    {
        Get().ITerminate(message);
    }

    private Engine()
    {

    }

    private static Engine Get() => _engine;

    private void Events()
    {

    }

    private void Update(float dt)
    {

    }

    private void Render()
    {

    }

    private void Destroy()
    {

    }

    private void IInitialize(string title, int x, int y, int w, int h, uint flags)
    {

    }

    private void IRun(string sceneName)
    {

    }

    private void IQuit()
    {

    }

    private void ITerminate(string message)
    {

    }
}
