using Models;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Audio.MyAudio
{
    public class SocketIoAudioReceiver : IAudioReceiver
    {
        private Action<byte[]> handler;
        private readonly Socket socket;

        public SocketIoAudioReceiver(Socket socket)
        {
            this.socket = socket;
            socket.On("live audio", (data) => {
                var map = Utils.GetMapFromData(data);
                AudioLive audioLive = AudioLive.FromJson(map["audio"].ToString());
                handler?.Invoke(audioLive.Buffer);
            });
        }

        public void Dispose()
        {
           // socket?.Close();
        }

        public void OnReceived(Action<byte[]> onAudioReceivedAction)
        {
            handler = onAudioReceivedAction;
        }
    }
}