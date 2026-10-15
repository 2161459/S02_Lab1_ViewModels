using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ZombieParty.Models;

//public class Weapon
public class Weapon : IValidatableObject //Tu dois donc modifier ta classe pour implémenter IValidatableObject
{
    [Required]
    [StringLength(250, MinimumLength = 2)]
    public string Name { get; set; }

    [DisplayName("Weapon's Description")]
    [StringLength(2500)]
    [DataType(DataType.MultilineText)] //Indiquer qu'une propriété doit être affichée comme un champ de texte sur plusieurs lignes dans un formulaire Comme un BOX
    public string? Description { get; set; }

    [Required]
    [Range(typeof(decimal), "0", "500")]
    public decimal Force { get; set; }

    [Required]
    [Range(typeof(decimal), "0", "100000", ErrorMessage = "The {0} has to be between {1} and {2}")]
    [DataType(DataType.Currency)]  //Indiquer qu'une propriété représente une valeur monétaire (de l'argent) dans ASP.NET Core MVC.
    public decimal Price { get; set; }

    [DisplayName("Created Date")]
    [DataType(DataType.Date)] //indiquer qu'une propriété représente une date (sans l'heure) dans ASP.NET Core MVC. DateTime pour l'heure
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [DisplayName("Weapon's Image")]
    public string? ImageUrl { get; set; }
    public int Qty { get; set; }

    [DisplayName("Qty Bought")]
    public int QtyBought { get; set; }

    //Validation Personnalisee
    //Si l'utilisateur écrit une description, celle-ci doit contenir plus de 3 mots (donc au moins 4 mots).
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var item = validationContext.ObjectInstance as Weapon; //Récupérer l'objet Weapon
        if (item == null) yield break; //Item représente cet objet Weapon //yield break permet de terminer la méthode sans retourner d'autres résultats.
        if (string.IsNullOrWhiteSpace(item.Description)) yield break; //Vérifier si la description est vide
        if (item.Description.Split(" ").Length <= 3) //Sépare la description en plusieurs éléments à chaque espace. //"Very powerful sword".Split(" ") //.Lenght Compte le nombre d'éléments obtenus.
            yield return new ValidationResult("Description needs to have more than 3 words please.", new[] { "Description" }); //Retourne l'erreur
    }

}

