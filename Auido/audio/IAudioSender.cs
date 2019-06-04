using System;

namespace Audio.MyAudio
{
    public interface IAudioSender : IDisposable
    {
        void Send(byte[] payload);
    }
}