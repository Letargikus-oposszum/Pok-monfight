using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace pokefos
{
    public class PokemonService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // Fetch Pokemon data from API
        public async Task<PokemonData> GetPokemonAsync(string pokemonNameOrId)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{pokemonNameOrId.ToLower()}";
            var response = await httpClient.GetStringAsync(url);
            var pokemonData = JsonConvert.DeserializeObject<PokemonData>(response);
            return pokemonData;
        }

        public async Task ChosenPokemonAsync(int apid, int dpid, Pokemon[] pokemon, List<MoveTypeInfo> StatusMove, List<MoveTypeInfo> DmgMove)
        {
            string AttackerPokemonName = pokemon[apid].Name;
            string DefenderPokemonName = pokemon[dpid].Name;

            // Fetch data for both attacker and defender Pokémon
            PokemonData attackerPokemonData = await GetPokemonAsync(AttackerPokemonName);
            PokemonData defenderPokemonData = await GetPokemonAsync(DefenderPokemonName);

            List<PokemonMove> attackerPokemonMoves = attackerPokemonData.Moves;
            var attackerPokemonMove = attackerPokemonMoves[apid + 1].Move;
            var attackerPokemonmoveName = attackerPokemonMove.Name;

            MoveDetail moveDetail = await GetMoveDetailsAsync(attackerPokemonmoveName);
            if (moveDetail.DamageClass.DmgClassName == "status")
            {
                StatusMove.Add(moveDetail.DamageClass);
            }
            else
            {
                DmgMove.Add(moveDetail.DamageClass);
            }
        }
        public async Task<MoveDetail> GetMoveDetailsAsync(string moveName)
        {
            var url = $"https://pokeapi.co/api/v2/move/{moveName.ToLower()}";
            var response = await httpClient.GetStringAsync(url);
            var moveDetail = JsonConvert.DeserializeObject<MoveDetail>(response);
            return moveDetail;
        }
    }
}
