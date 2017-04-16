using Core.Players;
using Microsoft.AspNetCore.Mvc;

namespace omxplayer_remote_aspnetcore.Controllers
{
    [Produces("application/json")]
    [Route("api/OmxPlayer")]
    public class OmxPlayerController : Controller
    {
        private readonly OmxPlayer _omxPlayer;

        public OmxPlayerController(OmxPlayer omxPlayer)
        {
            _omxPlayer = omxPlayer;
        }

        [HttpPost, Route("/play")]
        public void Play(string path)
        {
            _omxPlayer.Play(path);
        }

        [HttpPost, Route("/pause")]
        public void Pause()
        {
            _omxPlayer.Pause();
        }

        [HttpPost, Route("/stop")]
        public void Stop()
        {
            _omxPlayer.Stop();
        }
    }
}