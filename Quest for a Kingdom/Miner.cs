using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest_for_a_Kingdom
{
    class Miners
    {
        public Miners()
        {
            Number = 0;
            UpgradeLevel = 1;

            WoodCost = 18;
            StoneCost = 22;

            WoodUpgradeCost = 100;
            StoneUpgradeCost = 150;
            CopperUpgradeCost = 200;
            IronUpgradeCost = 150;

            IsCopper = false;
            CopperWoodCost = 80;
            CopperStoneCost = 60;
            CopperCopperCost = 30;

            IsIron = false;
            IronWoodCost = 200;
            IronStoneCost = 220;
            IronCopperCost = 250;
            IronIronCost = 300;
        }

        public float Number                 { get; set; }
        public float UpgradeLevel           { get; set; }

        public double WoodCost              { get; set; }
        public double StoneCost             { get; set; }

        public double WoodUpgradeCost       { get; set; }
        public double StoneUpgradeCost      { get; set; }
        public double CopperUpgradeCost     { get; set; }
        public double IronUpgradeCost       { get; set; }
        
        public bool IsCopper                { get; set; }
        public double CopperWoodCost        { get; set; }
        public double CopperStoneCost       { get; set; }
        public double CopperCopperCost      { get; set; }

        public bool IsIron                  { get; set; }
        public double IronWoodCost          { get; set; }
        public double IronStoneCost         { get; set; }
        public double IronCopperCost        { get; set; }
        public double IronIronCost          { get; set; }
        
    }
}
