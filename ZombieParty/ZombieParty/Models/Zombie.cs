using System.Diagnostics.Metrics;
using System.Drawing;

namespace ZombieParty.Models
{
    public class Zombie
    {
        public string Name { get; set; }
        //public string Type { get; set; }
        public int ZombieTypeId { get; set; }


        //Mettre un point d'arrêt (Breakpoint) if (ModelState.IsValid) et Place ta souris sur ModelState.IsValid. (Voir ModelState.IsValid = false)
        //Dans ta classe Zombie.cs, tu as probablement :
        //        public class Zombie
        //        {
        //            public string Name { get; set; }
        //            public int Point { get; set; }

        //            public int ZombieTypeId { get; set; }
        //            public ZombieType ZombieType { get; set; }
        //        }


        //        Le problème vient de :
        //public ZombieType ZombieType { get; set; }


        //        Quand tu remplis le formulaire, tu sélectionnes un ZombieTypeId, mais l'objet ZombieType lui-même n'est pas envoyé par le formulaire.
        //        Donc :
        //ZombieTypeId = 1
        //        ZombieType = null
        //Donc considère normalement ZombieType comme obligatoire.
        //On ajoute donc le ? qui signifie que la propriété peut contenir null.
        public ZombieType? ZombieType { get; set; }
        public int Point { get; set; }
    }
}
