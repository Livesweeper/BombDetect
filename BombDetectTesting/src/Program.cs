using BombDetect;
using BombDetect.Core;
using static SDL2.SDL;

namespace BombDetectTesting;

internal static class Program
{
	private static void Main(string[] args)
	{
		Engine.Initialize("BombDetect Testing", 0, 0, 800, 600, SDL_WindowFlags.SDL_WINDOW_SHOWN);

		// add all scenes to avoid null reference
		SceneManager.AddScene("MyScene", new MyScene());

		Engine.Run();
	}
}
