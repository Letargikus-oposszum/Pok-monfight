using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace pokefos
{
    public class Fight 
    {
        public int Id { get; set; }
        public PokemonData Attacker{ get; set; }
        public PokemonData Defender { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
}
}
