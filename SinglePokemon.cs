namespace pokefos
{
    public class PokemonMove
    {
        public MoveInfo Move { get; set; }
    }

    public class MoveInfo
    {
        public string Name { get; set; }
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
        public List<PokemonMove> Moves { get; set; }
    }
}
