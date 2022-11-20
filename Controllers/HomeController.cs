using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMedicine.Models;
using Microsoft.EntityFrameworkCore;
using MyMedicine.Data;
namespace MyMedicine.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _context;


    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }


    
    public IActionResult Index()
    {
        return View();
    }
    
        
        // using (var db = new ApplicationDbContext())
        //     {
        //         foreach(var u in db.users)
        //         {
            //     if((u.Email==login.Email) && (u.Password==login.Password)){
            //     u.enable=true;
            //     return RedirectToAction("Index");
            //     }}

            //     return View(login);
            // }
        
        
    

    [HttpGet]
     public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> SignUp(RegistrationViewModel model)
        {
 
            if (ModelState.IsValid)
            {
                Userdetails user = new Userdetails
                {
                    Name=model.Name,
                    Email=model.Email,
                    Password=model.Password,
                    enable=true
                    // Mobile=model.Mobile
 
                };
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View("SignUp");
            }
            
        }
    
    public IActionResult About()
    {
        return View();
    }

     public async Task<IActionResult>  Profile()

    {
        var meds = await _context.meds.ToListAsync();
        List<med> medtwo = new List<med>();
        var idd = 9999;
        foreach(var u in _context.users){
            if(u.enable==true){
                 idd=u.Id;
                    }
        }
        Console.WriteLine(idd);
        foreach(var m in meds){
            if(m.userId==idd){
                medtwo.Add(m);
            }
        }
        foreach (var u in _context.users){
        
            if (u.enable==true) 
            {

                Console.WriteLine("here");

                return View(medtwo);

            }

        }
        return RedirectToAction("LogIn");
    }

    

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }


    public async Task<IActionResult> Card()
    {
        var meds = await _context.meds.ToListAsync();
        
        return View(meds);
    }

    [HttpGet]
    public IActionResult Form(){
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> Form(med med)
    {
        // validate that our model meets the requirement
        if (ModelState.IsValid)
        {
            try
            {
                var idd=9999;
                var name="";
                foreach(var u in _context.users){
                    if(u.enable==true){
                         idd=u.Id;
                         name=u.Name;

                    }
                }
                var mednew= new med{
                    Name=med.Name,
                    Address=med.Address,
                    Dosage=med.Dosage,
                    
                    Urgency=med.Urgency,
                    ArrivalDate=med.ArrivalDate,
                    Destination=med.Destination,
                    userId=idd,
                    UserName=name

                };
               
                // update the ef core context in memory 
                _context.Add(mednew);

                // sync the changes of ef code in memory with the database
                await _context.SaveChangesAsync();

                return RedirectToAction("Card");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
            }
        }

        ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

        // We return the object back to view
        return View(med );
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        var exist = await _context.meds.Where(x => x.Id == Id).FirstOrDefaultAsync();

        return View(exist);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(med m)
    {
        // validate that our model meets the requirement
        
            try
            {
                // Check if the contact exist based on the id
                var exist = _context.meds.Where(x => x.Id == m.Id).FirstOrDefault();

                // if the contact is not null we update the information
                if (exist != null)
                {
                    // exist.Name = med.Name;
                    // exist.Name=m.Name;
                    // exist.Address=m.Address;
                    // exist.Dosage=m.Dosage;
                    // exist.Urgency=m.Urgency;
                    
                    exist.ArrivalDate = m.ArrivalDate;
                    exist.Destination = m.Destination;
                    exist.UserPhoneNumber=m.UserPhoneNumber;
                    exist.handled="Request is handled";

                    // we save the changes into the db
                    await _context.SaveChangesAsync();
                    // var id=exist.Id;
                
                    return RedirectToAction("Card");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
            }
        

        ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");
        Console.WriteLine("nottttttttt workingggggg");
        return View(m);
    }


    
    [HttpGet]
    public async Task<IActionResult> EditPost(int Id)
    {
        Console.WriteLine("EditPost HttpGet ");
        var exist = await _context.meds.Where(x => x.Id == Id).FirstOrDefaultAsync();

        return View(exist);
    }

    [HttpPost]
    public async Task<IActionResult> EditPost(med m)
    {
        Console.WriteLine("EditPost HttpPost ");

        // validate that our model meets the requirement
        
            try
            {
                // Check if the contact exist based on the id
                var exist = _context.meds.Where(x => x.Id == m.Id).FirstOrDefault();

        Console.WriteLine("EditPost HttpPost var exist");

                // if the contact is not null we update the information
                if (exist != null)
                {

        Console.WriteLine("EditPost HttpPost var exist exist != null");

                    exist.Name=m.Name;
                    exist.Address=m.Address;
                    exist.Dosage=m.Dosage;
                    exist.Urgency=m.Urgency;

        Console.WriteLine("EditPost HttpPost var exist updated");

                    
                    // exist.ArrivalDate = m.ArrivalDate;
                    // exist.Destination = m.Destination;
                    // exist.UserPhoneNumber=m.UserPhoneNumber;
                    // exist.handled="Handled";

                    // we save the changes into the db
                    await _context.SaveChangesAsync();
        Console.WriteLine("EditPost HttpPost var exist SaveChangesAsync");

                    // var id=exist.Id;
                //     _context.Remove(exist);
                // await _context.SaveChangesAsync();
                
                    return RedirectToAction("Profile");

        Console.WriteLine("EditPost HttpPost var exist return Profile");


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
            }
        

        ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");
        Console.WriteLine("nottttttttt workingggggg");
        return View(m);
    }


    [HttpGet]
    

    [HttpGet]
    public IActionResult LogIn()
    {

        foreach (var u in _context.users){
        
            if (u.enable==true) 
            {
                return RedirectToAction("Index");

            }}

        return View();
    }

    [HttpPost]
    public async  Task<IActionResult> LogIn(LoginViewModel login)
    {

        foreach(var u in _context.users){
            if(u.enable==true){
                u.enable=false;
                await _context.SaveChangesAsync();
            }
        }
        foreach(var u in _context.users){
                if((u.Email==login.Email) && (u.Password==login.Password)){
                    Console.WriteLine("runnnn");
                    u.enable=true;
                     await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
                }}

                return View(login);
            }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var exist = _context.meds.Where(x => x.Id ==id).FirstOrDefault();

            if (exist != null)
            {
                _context.Remove(exist);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile");
            }
        }
        catch (Exception ex)
        {

        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> SignOut(){
        foreach (var u in _context.users)

        {
            if(u.enable==true){
                u.enable=false;
                await _context.SaveChangesAsync();
            }
        }
        return RedirectToAction("LogIn");
    }
}
