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
                var processStartInfo = new ProcessStartInfo("omxplayer", string.Join(" ", _options.Arguments, path));
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardInput = true;
                _process = Process.Start(processStartInfo);
                _process.StandardInput.AutoFlush = true;
            }
        }

        public void Pause()
        {
            if (_process == null)
                return;

            SendCommand('p');
        }

        public void Stop()
        {
            if (_process == null)
                return;

            SendCommand('q');
            _process.WaitForExit();
            _process.Dispose();
            _process = null;
        }

        private void SendCommand(char command)
        {
            _process.StandardInput.Write(command);
        }
    }
}