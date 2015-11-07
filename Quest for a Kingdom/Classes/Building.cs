using System;

namespace Quest_for_a_Kingdom
{
    /// <summary>
    /// This class contains the generic information needed to create the buildings. 
    /// </summary>
    [Serializable]
    public class Building
    {
        /// <summary>
        /// Creates a building with the cost specified.
        /// </summary>
        /// <param name="woodCost">The cost of wood.</param>
        /// <param name="stoneCost">The cost of stone.</param>
        /// <param name="leatherCost">The cost of leather.</param>
        /// <param name="copperCost">The cost of copper.</param>
        /// <param name="ironCost">The cost of iron.</param>
        /// <param name="steelCost">The cost of steel.</param>
        public Building(string name, double woodCost = 0, double stoneCost = 0, double leatherCost = 0, double copperCost = 0, double ironCost = 0, double steelCost = 0)
        {
            Name = name;

            WoodCost = woodCost;
            StoneCost = stoneCost;
            LeatherCost = leatherCost;
            CopperCost = copperCost;
            IronCost = ironCost;
            SteelCost = steelCost;

            NumberOf = 0;
        }

        public string Name          { get; set; }

        public double WoodCost      { get; set; }
        public double StoneCost     { get; set; }
        public double LeatherCost    { get; set; }
        public double CopperCost    { get; set; }
        public double IronCost      { get; set; }
        public double SteelCost     { get; set; }
        
        public int NumberOf         { get; set; }
    }
}
