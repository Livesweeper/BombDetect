using static SDL2.SDL_mixer;

using BombDetect.Core;
using System.Numerics;

namespace BombDetect.Objects;

// sound thing
public class Sound : Thing
{
    public IntPtr SoundPointer;
    public string Path;
    public bool Loop;
    public int Volume; // 0-128??????? why

    // channel is set when playing
    public int Channel;

    // should we follow the parent?
    public bool FollowParent; // panning

    public bool Playing;

    public Sound(string name, string path, Thing? parent = null)
        : base(name, parent)
    {
        Path = path;
        SoundPointer = Mix_LoadWAV(Path); // better not be music or i will commit several crimes
        if (SoundPointer == IntPtr.Zero)
        {
            throw new Exception("Failed to load sound effect: " + Mix_GetError());
        }
    }

    // override Update() to set panning (if we're following the parent (and if it's a Thing2D))
    // ...and if we're actually playing the sound to not raise an error because the channel doesn't exist
    public override void OnUpdate(float deltaTime)
    {
        if (Playing)
        {
            Mix_Volume(Channel, Volume);
            if (FollowParent && Parent is Thing2D thing)
            {
                // calculate panning based on parent's position (left/right channels, max is 255)
                var panning = (byte)(thing.Position.X / thing.Size.X * 255);
                if (panning > 255) panning = 255;
                if (panning < 0) panning = 0;
                
                Mix_SetPanning(Channel, panning, (byte)(255 - panning));
            }
        }
    }

    // play
    public void Play()
    {
        if (Playing) return;

        Channel = Mix_PlayChannel(-1, SoundPointer, Loop ? -1 : 0);

        if (Channel == -1)
        {
            throw new Exception("Failed to play sound effect: " + Mix_GetError());
        }
        Playing = true;
    }

    // hey look it's an actual use for the stop virtual function
    public override void Stop()
    {
        if (!Playing) return;
        Mix_HaltChannel(Channel);
        Playing = false;
    }

    // destroy
    public override void Destroy()
    {
        Stop();
        Mix_FreeChunk(SoundPointer);
    }
}