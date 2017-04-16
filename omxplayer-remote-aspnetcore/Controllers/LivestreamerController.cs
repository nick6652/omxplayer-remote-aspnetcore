using Core.Players;
using Microsoft.AspNetCore.Mvc;

namespace omxplayer_remote_aspnetcore.Controllers
{
    [Produces("application/json")]
    [Route("api/livestreamer")]
    public class LivestreamerController : PlayerController
    {
        public LivestreamerController(LivestreamerPlayer player) : base(player)
        {
        }
    }

}