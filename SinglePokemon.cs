using System.Collections.Generic;
using System.Linq;

namespace pokefos
{
    public class PokemonMove
    {
        public MoveInfo Move { get; set; }
    }

    public class MoveInfo
    {
        public int Id { get; set; } // Add ID
        public string Name { get; set; } // Move name
        public int Power { get; set; } // Move power, if available
    }

    public class PokemonStat
    {
        public int BaseStat { get; set; }
        public StatInfo Stat { get; set; }
    }

    public class StatInfo
    {
        public string Name { get; set; }
    }

    public class PokemonData
    {
        public string Name { get; set; }
        public List<PokemonStat> Stats { get; set; }

        // Property to get HP
        public int HP => Stats.FirstOrDefault(stat => stat.Stat.Name.ToLower() == "hp")?.BaseStat ?? 0;

        public List<PokemonMove> Moves { get; set; } // List of moves
    }
}
