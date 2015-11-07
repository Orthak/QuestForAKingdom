﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest_for_a_Kingdom
{
    class Farmers
    {
        public Farmers()
        {
            Number = 0;
            UpgradeLevel = 2;

            WoodCost = 15;
            StoneCost = 10;

            WoodUpgradeCost = 200;
            StoneUpgradeCost = 130;
        }

        public float Number             { get; set; }
        public float UpgradeLevel       { get; set; }

        public double WoodCost          { get; set; }
        public double StoneCost         { get; set; }

        public double WoodUpgradeCost   { get; set; }
        public double StoneUpgradeCost  { get; set; }
    }
}
