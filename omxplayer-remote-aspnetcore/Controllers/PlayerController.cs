using Core.Models;
using Core.Players;
using Microsoft.AspNetCore.Mvc;

namespace omxplayer_remote_aspnetcore.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayer _player;

        public PlayerController(IPlayer player)
        {
            _player = player;
        }

        [HttpPost, Route("play")]
        public void Play([FromBody] PlayParameters parameters)
        {
            _player.Play(parameters.Path);
        }

        [HttpPost, Route("pause")]
        public void Pause()
        {
            _player.Pause();
        }

        [HttpPost, Route("stop")]
        public void Stop()
        {
            _player.Stop();
        }
    }
}