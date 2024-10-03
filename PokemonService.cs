using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace pokefos
{
    public class PokemonService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // Fetch Pokémon data from API
        public async Task<PokemonData> GetPokemonAsync(string pokemonNameOrId)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{pokemonNameOrId.ToLower()}";
            var response = await httpClient.GetStringAsync(url);
            var pokemonData = JsonConvert.DeserializeObject<PokemonData>(response);
            return pokemonData;
        }

        // Display Pokémon moves and store them in a list
        public async Task<List<MoveWithDamage>> DisplayPokemonMovesAsync(int apid, int dpid, Pokemon[] pokemon, Fight fight, PokemonDBContext DB)
        {
            List<MoveWithDamage> attackerMovesWithDamage = new List<MoveWithDamage>();

            // Get attacker Pokémon
            string attackerName = pokemon[apid].Name;
            PokemonData attackerData = await GetPokemonAsync(attackerName);

            foreach (var move in attackerData.Moves)
            {
                // Generate random damage for each move
                int randomDamage = new Random().Next(10, 51); // Random damage between 10 and 100

                // Create a MoveWithDamage object
                MoveWithDamage moveWithDamage = new MoveWithDamage
                {
                    MoveName = move.Move.Name,
                    Damage = randomDamage
                };

                // Add to the list of moves with damage
                attackerMovesWithDamage.Add(moveWithDamage);
            }

            string defenderName = pokemon[dpid].Name;
            PokemonData defenderData = await GetPokemonAsync(defenderName);

            foreach (var move in defenderData.Moves)
            {
                // Generate random damage for each move
                int randomDamage = new Random().Next(10, 101); // Random damage between 10 and 100
            }

            Console.WriteLine($"Attacker: {attackerName} Defender: {defenderName}");
            attackerData.Type = "Attacker";
            defenderData.Type = "Defender";

            fight.Defender = defenderData;
            fight.Attacker = attackerData;
            DB.SaveChanges();
            // Return the list of moves with damage for the attacker
            return attackerMovesWithDamage;
        }
        public void Attack(List<MoveWithDamage> attackerMovesWithDamage, PokemonData attackerData, PokemonData defenderData, FightRound fightround, PokemonDBContext DB)
        {
            List<MoveWithDamage> helperMoveWithDamages = new List<MoveWithDamage>();
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                int randIndex = random.Next(0, attackerMovesWithDamage.Count() - 1);
                helperMoveWithDamages.Add(attackerMovesWithDamage[randIndex]);
            }

            int helperIndex = 0;
            int temporaryDefenderHP = 0;



            for (int i = 0; i < helperMoveWithDamages.Count; i++)
            {
                temporaryDefenderHP = defenderData.HP - attackerData.Moves[helperIndex].Move.Power;
                helperIndex += 1;
                fightround.Attacks += 1;

                if (temporaryDefenderHP <= 0)
                {
                    Console.WriteLine($"The defender ({defenderData.Name}) has been knocked out by the attacker ({attackerData.Name}) using these three moves: " +
                    $"({helperMoveWithDamages[0].MoveName}," +
                    $"{helperMoveWithDamages[1].MoveName}," +
                    $"{helperMoveWithDamages[2].MoveName})");
                    fightround.FightState = "Lost";
                    break;
                }

                else if (temporaryDefenderHP >= 0 && helperIndex == 2)
                {
                    Console.WriteLine($"Defender won with the remaining health of: {temporaryDefenderHP}");
                    fightround.FightState = "Won";
                    break;
                }

                fightround.RemainingHP = temporaryDefenderHP;
                DB.SaveChanges();
            }
        }
    }
}
