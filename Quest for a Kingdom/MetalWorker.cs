using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest_for_a_Kingdom
{
    class MetalWorkers
    {
        public MetalWorkers()
        {
            Number = 0;
            UpgradeLevel = 1;

            WoodCost = 40;
            StoneCost = 40;
            CopperCost = 50;
            IronCost = 60;
        }

        public int Number { get; set; }
        public int UpgradeLevel { get; set; }

        public double WoodCost { get; set; }
        public double StoneCost { get; set; }
        public double CopperCost { get; set; }
        public double IronCost { get; set; }

        public double WoodUpgradeCost { get; set; }
        public double StoneUpgradeCost { get; set; }
        public double CopperUpgradeCost { get; set; }
        public double IronUpgradeCost { get; set; }

    }
}
