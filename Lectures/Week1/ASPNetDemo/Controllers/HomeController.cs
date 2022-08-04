using Microsoft.AspNetCore.Mvc;
// Inherit from abstract base controller class
// inherits helpful methods for handling HTTP req/res cycle
public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("/videos")]
    public IActionResult Videos()
    {
        List<string> youtubeVideoIds = new List<string>
        {
            "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI"
        }; 

        ViewBag.YoutubeVideoIds = youtubeVideoIds;
        ViewBag.Title = $"Here are {ViewBag.YoutubeVideoIds.Count} of my favorite videos";
        return View("Videos");
    }

    [HttpGet("/showingModel")]
    public IActionResult ModelDisplay()
    {
        List<int> myNums = new List<int>(){1,2,3};
        MyModel someModel = new MyModel("squirtle", myNums);

        ViewBag.MyModel = someModel;
        return View();
    }
}