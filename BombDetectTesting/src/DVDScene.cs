using BombDetect;
using BombDetect.Core;
using BombDetect.Objects;
using System.Numerics;

using static SDL2.SDL;

namespace BombDetectTesting;

public class DVDScene : Scene
{
    public DVDScene()
    {
        Console.WriteLine("DVD Scene started");

        // some setup
        var logo = new DVDLogo();
        Things.Add(logo);

        Start();
    }
}
