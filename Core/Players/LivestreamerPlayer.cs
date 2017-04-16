using System.Diagnostics;

namespace Core.Players
{
    public class LivestreamerPlayer : OmxPlayer
    {
        public override Process StartProcess(string path)
        {
            var processStartInfo = new ProcessStartInfo("livestreamer", path);
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            var process = Process.Start(processStartInfo);
            process.StandardInput.AutoFlush = true;
            return process;
        }
    }
}