using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using iWishApp.Models;
using iWishApp.Data;
using iWishApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenAI_API;




namespace iWishApp.Controllers;

public class HomeController : Controller
{
    private static string userAffirmation = "";
    private static string Actions = "";
    private static string Reflections = "";
    private static string Goals = "";
    private readonly ChatbotService _chatbotService;
    private ApplicationDbContext _context;

    //private readonly ILogger<HomeController> _logger;
    //private ApplicationDbContext _context;

    //public HomeController(ILogger<HomeController> logger)

    //{
    //    _logger = logger;
    //}

    //public HomeController(ApplicationDbContext context)
    //{

    //    _context = context;
    //    string apiKey = "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";
    //    _chatbotService = new ChatbotService(apiKey);
    //}

    public HomeController(ApplicationDbContext context, ChatbotService chatbotService)
    {
        _context = context;
        string apiKey = "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";
        _chatbotService = new ChatbotService(apiKey); _chatbotService = chatbotService;
    }


    public async Task<IActionResult> Chatbot(string userInput)
    {


        

        if (!string.IsNullOrEmpty(userInput))
        {
            var response = await _chatbotService.GetChatbotResponse(userInput);
            ViewBag.ChatbotResponse = response;
        }


        return View("Chatbot");

        
    }





    public IActionResult Index()
    {

        ViewBag.UserAffirmation = userAffirmation;
        ViewBag.Actions = Actions;
        ViewBag.Reflections = Reflections;
        ViewBag.Goals = Goals;
        return View();


    }

    public IActionResult JournalEntry()
    {
        var viewModel = new AddJournalEntry
        {
            Journals = _context.Journals.ToList()
        };

        return View(viewModel);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    

    [HttpPost]
    public IActionResult AddJournalEntry(AddJournalEntry viewModel)
    {


        if (viewModel.Actions == null || viewModel.Goals == null || viewModel.Reflections == null)
        {
            viewModel.Actions = "";
            viewModel.Reflections = "";
            viewModel.Goals = "";


        }


        var journalEntry = new Journals
        {
            //Affirmation = viewModel.UserAffirmation,
            Goals = viewModel.Goals,

            Reflections = viewModel.Reflections,

            Actions = viewModel.Actions
        };

        _context.Journals.Add(journalEntry);
        _context.SaveChanges();

        return RedirectToAction("JournalEntry");
    }

    [HttpPost]
    public IActionResult AddAffirmation(string affirmationText)
    {
        userAffirmation = affirmationText;
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult AddActions(string actionsText)
    {
        
            Actions = actionsText;
        

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddReflections(string reflectionsText)
    {
        
            Reflections = reflectionsText;
        

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddGoals(string goalsText)
    {
       
            Goals = goalsText;
       

        return RedirectToAction("Index");
    }


   
    
}






