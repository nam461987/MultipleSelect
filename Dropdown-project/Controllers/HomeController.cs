using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dropdown_project.Models;

namespace Dropdown_project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static readonly string[] StaticOptions = { "Option 1", "Option 2", "Option 3" };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new MultiSelectModel
        {
            Options = StaticOptions.ToList(),
            SelectedOptions = new List<string>()
        };

        return View(model);
    }

    [HttpPost]
    public ActionResult ProcessSelectedOptions(List<string> selectedOptions)
    {
        // You can access selected options from the 'selectedOptions' parameter
        var model = new MultiSelectModel()
        {
            Options = StaticOptions.ToList(),
            SelectedOptions = selectedOptions
        };


        return View("Index", model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class MultiSelectModel
{
    public List<string>? Options { get; set; }
    public List<string>? SelectedOptions { get; set; }
}

