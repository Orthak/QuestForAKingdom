using System;

namespace Quest_for_a_Kingdom
{
    /// <summary>
    /// This class contains the generic information that is needed to crate the workers. 
    /// </summary>
    [Serializable]
    public class Worker
    {
        #region Properties
        public string Name                  { get; set; }

        public float Number                 { get; set; }
        public float UpgradeLevel           { get; set; }
        public int UpgradeText              { get; set; }

        public double WoodCost              { get; set; }
        public double StoneCost             { get; set; }
        public double LeatherCost           { get; set; }
        public double CopperCost            { get; set; }
        public double IronCost              { get; set; }
        public double SteelCost             { get; set; }

        public double WoodUpgradeCost       { get; set; }
        public double StoneUpgradeCost      { get; set; }
        public double LeatherUpgradeCost    { get; set; }
        public double CopperUpgradeCost     { get; set; }
        public double IronUpgradeCost       { get; set; }
        public double SteelUpgradeCost      { get; set; }
        
        public bool IsCopper                { get; set; }
        public double CopperWoodCost        { get; set; }
        public double CopperStoneCost       { get; set; }
        public double CopperCopperCost      { get; set; }

        public bool IsIron                  { get; set; }
        public double IronWoodCost          { get; set; }
        public double IronStoneCost         { get; set; }
        public double IronCopperCost        { get; set; }
        public double IronIronCost          { get; set; }
        
        public int WorkersCap               { get; set; }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Set the initial cost values for the worker.
        /// </summary>
        /// <param name="wood">The wood cost.</param>
        /// <param name="stone">The stone cost.</param>
        /// <param name="leather">The leather cost.</param>
        /// <param name="copper">The copper cost.</param>
        /// <param name="iron">The iron cost.</param>
        /// <param name="steel">The steel cost.</param>
        public Worker(string name, double wood = 0, double stone = 0, double leather = 0, double copper = 0, double iron = 0, double steel = 0)
        {
            Name = name;

            WoodCost = wood;
            StoneCost = stone;
            LeatherCost = leather;
            CopperCost = copper;
            IronCost = iron;
            SteelCost = steel;

            Number = 0;
            UpgradeLevel = 1;
        }

        /// <summary>
        /// This constructor is used to create an instance that can be referred to for the max amount of workers available for purchase.
        /// </summary>
        /// <param name="theCap">Sets the starting cap of the workers.</param>
        public Worker(string name, int theCap)
        {
            Name = name;
            WorkersCap = theCap;
        }
        #endregion

        #region Class Methods
        /// <summary>
        /// Sets the upgrade costs for the worker.
        /// </summary>
        /// <param name="wood">The wood cost.</param>
        /// <param name="stone">The stone cost.</param>
        /// <param name="leather">The leather cost.</param>
        /// <param name="copper">The copper cost.</param>
        /// <param name="iron">The iron cost.</param>
        /// <param name="steel">The steel cost.</param>
        public void SetUpgradeCosts(double wood = 0, double stone = 0, double leather = 0, double copper = 0, double iron = 0, double steel = 0)
        {
            WoodUpgradeCost = wood;
            StoneUpgradeCost = stone;
            LeatherUpgradeCost = leather;
            CopperUpgradeCost = copper;
            IronUpgradeCost = iron;
            SteelUpgradeCost = steel;
        }
        public void SetCopperUpgradeCosts(double wood, double stone, double copper)
        {
            CopperWoodCost = wood;
            CopperStoneCost = stone;
            CopperCopperCost = copper;
        }
        public void SetIronUpgradeCosts(double wood, double stone, double copper, double iron)
        {
            IronWoodCost = wood;
            IronStoneCost = stone;
            IronCopperCost = copper;
            IronIronCost = iron;
        }
        #endregion
    }
}
