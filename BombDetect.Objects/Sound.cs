using BombDetect.Core;
using static SDL2.SDL_mixer;

namespace BombDetect.Objects;

// sound thing
public class Sound : Thing
{
    public string FileName { get; }
    public bool Loop { get; }
    public bool IsPlaying { get; private set; }
    public int Channel { get; set; }

    public Sound(string name, string fileName, bool loop, Thing? parent = null)
        : base(name, parent)
    {
        FileName = fileName;
        Loop = loop;
    }

    public override void Start()
    {
        base.Start();
        IsPlaying = true;
        Channel = Mix_PlayChannel(-1, Mix_LoadWAV(FileName), Loop ? -1 : 0);

        if (Channel == -1)
        {
            throw new Exception($"Failed to load sound {FileName}");
        }
    }

    // stop
    public override void Stop()
    {
        base.Stop();
        IsPlaying = false;
    }

    // update sound position only if the parent is a 2D thing, otherwise it plays in the middle of the screen
    public override void OnUpdate(float deltaTime)
    {
        if (IsPlaying)
        {
            if (Parent is Thing2D parent2D)
            {
                Mix_SetPosition(Channel, (short)parent2D.GlobalPosition.X, (byte)parent2D.GlobalPosition.Y);
            }
            else
            {
                Mix_SetPosition(Channel, 0, 0);
            }
        }
    }
}