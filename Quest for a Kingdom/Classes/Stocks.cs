using System;
using System.Windows.Forms;

namespace Quest_for_a_Kingdom
{
    /// <summary>
    /// This class contains the data for the stocks.
    /// </summary>
    [Serializable]
    public class Stocks
    {
        public Stocks()
        {
            StockCap = 100;
            RationsCap = 200;
            UpgradeLevel = 1;

            Wood = 0;
            Stone = 0;
            Leather = 0;
            Copper = 0;
            Iron = 0;
            Steel = 0;
            Rations = 100;

            WoodUpgradeCost = 50;
            StoneUpgradeCost = 50;
            CopperUpgradeCost = 50;
            IronUpgradeCost = 50;
        }

        public void PropertyChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            MessageBox.Show("Data Loaded");
        }

        public int StockCap                 { get; set; }
        public int RationsCap               { get; set; }
        public int UpgradeLevel             { get; set; }

        public double Wood                  { get; set; }
        public double Stone                 { get; set; }
        public double Copper                { get; set; }
        public double Iron                  { get; set; }
        public double Steel                 { get; set; }
        public double Leather                { get; set; }
        public double Rations               { get; set; }

        public double WoodUpgradeCost       { get; set; }
        public double StoneUpgradeCost      { get; set; }
        public double CopperUpgradeCost     { get; set; }
        public double IronUpgradeCost       { get; set; }
    }
}
