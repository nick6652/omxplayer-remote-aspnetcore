using Core.SourceLists;
using Microsoft.AspNetCore.Mvc;

namespace omxplayer_remote_aspnetcore.Controllers
{
  public class SourceController : Controller
  {
    private readonly ISourceList _filmsSourceList;
    private readonly ISourceList _recentSourceList;

    public SourceController(FileSourceList filmsSourceList, RecentSourceList recentSourceList)
    {
      _filmsSourceList = filmsSourceList;
      _recentSourceList = recentSourceList;
    }

    public IActionResult Films()
    {
      return Json(_filmsSourceList.Get());
    }

    public IActionResult RecentStreams()
    {
      return Json(_recentSourceList.Get());
    }
  }
}
