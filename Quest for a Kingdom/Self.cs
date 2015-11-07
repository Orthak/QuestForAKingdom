using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest_for_a_Kingdom
{
    class Self
    {
        public Self()
        {
            UpgradeLevel = 1;

            WoodUpgradeCost = 200;
            StoneUpgradeCost = 230;
            CopperUpgradeCost = 280;
            IronUpgradeCost = 300;
        }

        public int UpgradeLevel     { get; set; }

        public double WoodUpgradeCost { get; set; }
        public double StoneUpgradeCost { get; set; }
        public double CopperUpgradeCost { get; set; }
        public double IronUpgradeCost { get; set; }
    }
}
