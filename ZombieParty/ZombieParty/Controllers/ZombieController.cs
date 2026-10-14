using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class ZombieController : Controller
    {
        public IActionResult Index()
        {
            //this.ViewBag.MaListe = new List<Zombie>();
            //Ce code sert à récupérer tous les zombies de la base de données et à les envoyer à la vue Index.cshtml pour les afficher sur la page Web. 
            this.ViewBag.MaListe = _baseDonnees.Zombies.ToList();
            return View();
        }

        //Ce code sert à donner accès à la base de données (BaseDonnees) au ZombieController grâce à l'injection de dépendances.
        private BaseDonnees _baseDonnees { get; set; }

        public ZombieController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        //Elle sert à afficher le formulaire lorsque tu visites /Zombie/Create.
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ZombieTypes = new SelectList(
                _baseDonnees.ZombieTypes.ToList(),"Id","TypeName",null
            );

            return View();
        }


        //Elle sert à recevoir les informations lorsque tu cliques sur le bouton Create.
        //Elle sert à recevoir les informations du formulaire, vérifier si elles sont valides et ajouter un nouveau zombie dans la base de données.

        //Create GET : affiche le formulaire pour créer un zombie.
        // Create POST : reçoit les informations après que l'utilisateur a cliqué sur « Créer ».
        [HttpPost]
        //Ce code sert à créer une liste déroulante (dropdown) contenant les types de zombies dans le formulaire de création d'un nouveau zombie.
        public IActionResult Create(Zombie zombie)
        {
            //ViewBag.ZombieTypes = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName", null);
            //return View();
            //Si le modèle est valide le zombie est ajouté et nous sommes redirigés vers index.
            if (ModelState.IsValid)
            {
                _baseDonnees.Zombies.Add(zombie);
                TempData["Success"] = $"Zombie {zombie.Name} added";
                return this.RedirectToAction("Index");
            }
            //Il faut repopuler le zombieType dans le ViewBag
            //Allez chercher le ZombieType sélectionné, rappel 2W5 Linq
            ZombieType selectedZombieType = _baseDonnees.ZombieTypes.Where(zt => zt.Id == zombie.ZombieTypeId).SingleOrDefault();
            zombie.ZombieType = selectedZombieType;

            ViewBag.ZombieTypes = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName", selectedZombieType);

            return View(zombie);

        }

    }
}
