using pokefos;

Console.WriteLine("Give me the desired attacker pokemon: ");
int AttackerPokemonId = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Give me the desired attacker pokemon: ");
int DefenderPokemonId = Convert.ToInt32(Console.ReadLine());

Rootobject rootobject = new Rootobject();
PokemonService pokemonService = new PokemonService();
List<MoveTypeInfo> statusMove = new List<MoveTypeInfo>();
List<MoveTypeInfo> dmgMove = new List<MoveTypeInfo>();

pokemonService.ChosenPokemonAsync(AttackerPokemonId, DefenderPokemonId, rootobject.Pokemon, statusMove, dmgMove);