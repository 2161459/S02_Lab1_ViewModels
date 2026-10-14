using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        public IActionResult Index()
        {
            //this.ViewBag.MaListe = new List<ZombieType>()
            //{
            //    new ZombieType(){TypeName= "Virus", Id=1},
            //    new ZombieType(){TypeName= "Contact", Id=2}
            //};

            //Ce code sert à récupérer la liste des types de zombies dans BaseDonnees et à l'envoyer à la vue (Index.cshtml) pour les afficher sur la page Web.
            this.ViewBag.MaListe = _baseDonnees.ZombieTypes.ToList();
            return View();
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            //Vérifie si les données envoyées par l'utilisateur respectent les règles de validation du modèle.
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
               //Ce code sert à vérifier si les informations d'un nouveau type de zombie sont valides, puis à l'ajouter dans la base de données et à retourner à la page Index.
                _baseDonnees.ZombieTypes.Add(zombieType);

                //Cette action récupère la liste mise à jour pour l'afficher sur la page Web.
                return this.RedirectToAction("Index");
            }


            return this.View(zombieType);
        }

        //C'est le constructeur du contrôleur. Il reçoit un objet BaseDonnees en paramètre.
        private BaseDonnees _baseDonnees { get; set; }

        public ZombieTypeController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

    }
}
