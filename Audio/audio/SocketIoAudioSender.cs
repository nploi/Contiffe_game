using Models;
using Quobject.SocketIoClientDotNet.Client;
using System.Net;

namespace Audio.MyAudio
{
    public class SocketIoAudioSender : IAudioSender
    {
        private readonly Socket sender;
        private AudioLive audioLive = new AudioLive();
        public SocketIoAudioSender(Socket socket)
        {
            sender = socket;
        }

        public void Send(byte[] payload)
        {
            audioLive.Buffer = payload;
            sender.Emit("live audio", audioLive.ToJson());
        }

        public void Dispose()
        {
           // sender?.Close();
        }
    }
}