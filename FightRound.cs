using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokefos
{
    public class FightRound
    {

        public int Id { get; set; }
        public int RemainingHP { get; set; }
        public string FightState { get; set; }
        public int Attacks {  get; set; }
        public Fight Fight { get; set; }
    }
}
