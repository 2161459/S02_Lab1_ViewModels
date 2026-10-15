using Microsoft.AspNetCore.Mvc;
namespace ZombieParty.Models;
public class WeaponController : Controller
{
    private static List<Weapon> weapons = new(); //sert à créer une liste d'armes (Weapon) qui sera partagée et conservée en mémoire pendant l'exécution de l'application.
    public IActionResult Index()
    {

        //return View();
        // Afficher la liste des armes
        return View(weapons);
    }
    // Afficher le formulaire
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    //Ajouter une nouvelle arme
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Weapon weapon)
    {
        if (ModelState.IsValid)
        {
            weapons.Add(weapon);

            TempData["Success"] = $"Weapon {weapon.Name} added";

            return RedirectToAction("Index");
        }

        return View();
    }
}
