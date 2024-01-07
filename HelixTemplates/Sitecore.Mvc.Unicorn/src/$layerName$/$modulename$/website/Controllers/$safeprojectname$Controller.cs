namespace $modulenamespace$.Controllers
{
  using System.Web.Mvc;

  /// <summary>
  /// This is description of $safeprojectname$Controller
  /// </summary>
  public class $safeprojectname$Controller : Controller
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="$safeprojectname$Controller"/> class.
    /// </summary>
    public $safeprojectname$Controller()
    {
      // Put controller logic here
    }

    /// <summary>
    /// Generate rendering view
    /// </summary>
    /// <returns>Rendering view</returns>
    public ActionResult SampleView()
    {
      return View("~/Views/$safeprojectname$/$safeprojectname$SampleView.cshtml");
    }
  }
}   