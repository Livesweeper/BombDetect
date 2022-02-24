namespace BombDetect.Core;

// scene manager
public static class SceneManager
{
    public static Dictionary<string, Scene> Scenes { get; } = new();
    public static Scene CurrentScene { get; private set; }

    public static void AddScene(string name, Scene scene)
    {
        if (Scenes.ContainsKey(name))
        {
            throw new Exception($"Scene {name} already exists");
        }

        Scenes.Add(name, scene);
        //scene.Start();
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
}