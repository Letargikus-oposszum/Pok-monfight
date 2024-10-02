using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokefos
{
    public class MoveTypeInfo
    {
        public string DmgClassName { get; set; }
    }

    public class MoveDetail
    {
        public MoveTypeInfo DamageClass { get; set; }  // This represents if the move is physical, special, or status
    }
}
