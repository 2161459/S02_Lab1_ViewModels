//Puisque l’on a besoin d’informations provenant de plus d’un modèle, il faut un ViewModel.
//La View présente un ZombieType en particulier : ça prend donc le Id du zombieType afin de trouver le bon. Puis la liste des zombies qui ont ce ZombieType Id.


//Puisque l’on a besoin d’informations provenant de plus d’un modèle, il faut un ViewModel.
//La View présente un ZombieType en particulier : ça prend donc le Id du zombieType afin de trouver le bon. Puis la liste des zombies qui ont ce ZombieType Id.

using ZombieParty.Models;

namespace ZombieParty.ViewModels
{
    public class ZombieTypeVM
    {
        public ZombieType ZombieType { get; set; }
        public List<Zombie> ZombiesList { get; set; } = new List<Zombie>();

        //Présenter le nombre de zombies et la moyenne des points de la liste de zombies pour chaque ZombieType
        public int ZombiesCount { get; set; }
        public double PointsAverage { get; set; }


    }
}
