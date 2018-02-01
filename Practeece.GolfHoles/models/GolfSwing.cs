using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practeece.GolfHoles.models
{
    public class GolfSwing
    {
        public GolfHole GolfHole { get; set; }

        public byte SwingCount { get; set; }

        public string SkillLevel { get; set; }
    }
}
