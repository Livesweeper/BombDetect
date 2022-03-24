namespace BombDetect.Core;

// scene manager
public static class SceneManager
{
    public static Dictionary<string, Scene> Scenes { get; } = new();
    public static Scene? CurrentScene { get; private set; }

    public static void AddScene(string name, Scene scene)
    {
        if (Scenes.ContainsKey(name))
        {
            throw new Exception($"Scene {name} already exists");
        }

        Scenes.Add(name, scene);

        // first one? set it as current
        if (CurrentScene == null)
        {
            SetScene(name);
        }
    }

    public static void SetScene(string name, bool destroy = false)
    {
        if (CurrentScene != null)
        {
            if (destroy)
            {
                CurrentScene.Destroy();
            }
            else
            {
                CurrentScene.Stop();
            }
        }

        CurrentScene = Scenes[name];
        CurrentScene.Start();
    }

    public static void RemoveScene(string name)
    {
        if (!Scenes.ContainsKey(name))
        {
            throw new Exception($"Scene {name} does not exist");
        }

        Scenes[name].Destroy();
        Scenes.Remove(name);
    }
}