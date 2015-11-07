using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest_for_a_Kingdom
{
    class Hunters
    {
        public Hunters()
        {
            Number = 0;
            UpgradeLevel = 1;

            WoodCost = 40;
            StoneCost = 40;
            CopperCost = 50;

            WoodUpgradeCost = 100;
            StoneUpgradeCost = 130;
            CopperUpgradeCost = 180;
        }

        public float Number              { get; set; }
        public float UpgradeLevel        { get; set; }
                                         
        public double WoodCost           { get; set; }
        public double StoneCost          { get; set; }
        public double CopperCost         { get; set; }
                                         
        public double WoodUpgradeCost    { get; set; }
        public double StoneUpgradeCost   { get; set; }
        public double CopperUpgradeCost  { get; set; }
    }
}
