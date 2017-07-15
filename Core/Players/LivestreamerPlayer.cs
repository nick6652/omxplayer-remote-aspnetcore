using Core.SourceLists;
using System.Diagnostics;

namespace Core.Players
{
    public class LivestreamerPlayer : OmxPlayer
    {
        private readonly RecentSourceList _recentSourceList;

        public LivestreamerPlayer(RecentSourceList recentSourceList)
        {
            _recentSourceList = recentSourceList;
        }

        public override Process StartProcess(string path)
        {
            var processStartInfo = new ProcessStartInfo("livestreamer", path);
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardInput = true;
            var process = Process.Start(processStartInfo);
            process.StandardInput.AutoFlush = true;
            return process;
        }

        public override void Play(string path)
        {
            base.Play(path);
            _recentSourceList.Add(path);
        }
    }
}