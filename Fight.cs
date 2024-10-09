using pokefos;
using System.ComponentModel.DataAnnotations.Schema;

public class Fight
{
    public int Id { get; set; }

    // Use ForeignKey attribute to specify the FK relationship
    [ForeignKey("Attacker")]
    public int AttackerId { get; set; } // Make this an int property
    public PokemonData Attacker { get; set; }

    [ForeignKey("Defender")]
    public int DefenderId { get; set; } // Make this an int property
    public PokemonData Defender { get; set; }

    public string Date { get; set; } = DateTime.Now.ToString();
}
