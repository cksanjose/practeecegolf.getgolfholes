using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practeece.GolfHoles.models
{
    public class GolfHole
    {
        public byte HoleId { get; set; }

        public int Distance { get; set; }

        public byte Par { get; set; }

        public string Skill { get; set; }

        public string Hazard { get; set; }

        public byte AverageSwingsToGreen { get; set; }

    }
}
