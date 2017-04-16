using System.Diagnostics;
using Core.Models;
using Microsoft.Extensions.Options;

namespace Core.Players
{
    public class OmxPlayer
    {
        private readonly OmxPlayerOptions _options;
        private Process _process;

        public OmxPlayer(IOptions<OmxPlayerOptions> options)
        {
            _options = options.Value;
        }

        public void Play(string path)
        {
            if (_process == null)
            {
                _process = Process.Start("omxplayer", string.Join(" ", _options.Arguments, path));
            }
        }

        public void Pause()
        {
            if (_process != null)
            {
                SendCommand("p");
            }
        }

        public void Stop()
        {
            SendCommand("q");
            _process.WaitForExit();
            _process.Dispose();
            _process = null;
        }

        private void SendCommand(string command)
        {
            _process.StandardInput.WriteLine(command);
        }
    }
}