using Newtonsoft.Json;
using pokefos;

var url = "https://pokeapi.co/api/v2/pokemon?limit=1302"; // Adjust limit as needed
var httpClient = new HttpClient();
var response = await httpClient.GetStringAsync(url);
var pokemonRoot = JsonConvert.DeserializeObject<Rootobject>(response); // Assuming Rootobject has been defined


PokemonService pokemonService = new PokemonService();
Fight fight = new Fight();
FightRound fightRound = new FightRound();
PokemonDBContext DB = new PokemonDBContext();

Console.WriteLine("Enter the index of the attacker Pokémon: ");
int attackerIndex = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the index of the defender Pokémon: ");
int defenderIndex = Convert.ToInt32(Console.ReadLine());

// Display Pokémon moves

var attackerMovesWithDamage = await pokemonService.DisplayPokemonMovesAsync(attackerIndex-1, defenderIndex - 1, pokemonRoot.Results, fight, DB);
PokemonData attackerData = await pokemonService.GetPokemonAsync(pokemonRoot.Results[attackerIndex-1].Name);
PokemonData defenderData = await pokemonService.GetPokemonAsync(pokemonRoot.Results[defenderIndex - 1].Name);

// Create an instance of your Attack class (or whatever class contains the Attack method)

// Call the Attack method
pokemonService.Attack(attackerMovesWithDamage, attackerData, defenderData, fightRound, DB);