using Core.Players;
using Microsoft.AspNetCore.Mvc;

namespace omxplayer_remote_aspnetcore.Controllers
{
    [Produces("application/json")]
    [Route("api/OmxPlayer")]
    public class OmxPlayerController : PlayerController
    {
        public OmxPlayerController(OmxPlayer player) : base(player)
        {
        }
    }
}