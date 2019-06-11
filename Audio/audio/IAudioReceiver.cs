using System;

namespace Audio.MyAudio
{
    public interface IAudioReceiver : IDisposable
    {
        void OnReceived(Action<byte[]> handler);
    }
}