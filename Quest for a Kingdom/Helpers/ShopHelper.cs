using System;

namespace Quest_for_a_Kingdom.Helpers
{
    /// <summary>
    /// This class contains all of the helper methods tyhat are used by the Shop class.
    /// </summary>
    class ShopHelper
    {
        private Stocks stocks;
        private MainForm main;
        private MainHelper mainHelper;

        public ShopHelper(Stocks theStock, MainForm theMain, MainHelper _mainHelper)
        {
            stocks = theStock;
            main = theMain;
            mainHelper = _mainHelper;
        }

        /// <summary>
        /// Can we afford the worker?
        /// </summary>
        /// <param name="building">The worker to use.</param>
        /// <param name="resourse">The resourse to compare.</param>
        /// <returns></returns>
        internal bool CanAfford(Worker worker, string resource)
        {
            double theStock = 0f;
            double theCost = 0f;

            switch (resource)
            {
                case "wood":
                    theStock = stocks.Wood;
                    theCost = worker.WoodCost;
                    break;
                case "stone":
                    theStock = stocks.Stone;
                    theCost = worker.StoneCost;
                    break;
                case "leather":
                    theStock = stocks.Leather;
                    theCost = worker.LeatherCost;
                    break;
                case "copper":
                    theStock = stocks.Copper;
                    theCost = worker.CopperCost;
                    break;
                case "iron":
                    theStock = stocks.Iron;
                    theCost = worker.IronCost;
                    break;
                case "steel":
                    theStock = stocks.Steel;
                    theCost = worker.SteelCost;
                    break;
            }

            if (theStock >= theCost)
            {
                return true;
            }

            else { return false; }
        }
        /// <summary>
        /// Can we afford the building?
        /// </summary>
        /// <param name="worker">The building to use.</param>
        /// <param name="resourse">The resourse to compare.</param>
        /// <returns></returns>
        internal bool CanAfford(Building building, string resource)
        {
            double theStock = 0f;
            double theCost = 0f;

            switch (resource)
            {
                case "wood":
                    theStock = stocks.Wood;
                    theCost = building.WoodCost;
                    break;
                case "stone":
                    theStock = stocks.Stone;
                    theCost = building.StoneCost;
                    break;
                case "leather":
                    theStock = stocks.Leather;
                    theCost = building.LeatherCost;
                    break;
                case "copper":
                    theStock = stocks.Copper;
                    theCost = building.CopperCost;
                    break;
                case "iron":
                    theStock = stocks.Iron;
                    theCost = building.IronCost;
                    break;
                case "steel":
                    theStock = stocks.Steel;
                    theCost = building.SteelCost;
                    break;
            }

            if (theStock >= theCost)
            {
                return true;
            }

            else { return false; }
        }
        /// <summary>
        /// Can we afford the upgrade?
        /// </summary>
        /// <param name="worker">The worker to use.</param>
        /// <param name="resource">The resourse to compare.</param>
        /// <returns></returns>
        internal bool CanAffordUpgrade(Worker worker, string resource)
        {
            double theStock = 0f;
            double theCost = 0f;

            switch (resource)
            {
                case "wood":
                    theStock = stocks.Wood;
                    theCost = worker.WoodUpgradeCost;
                    break;
                case "stone":
                    theStock = stocks.Stone;
                    theCost = worker.StoneUpgradeCost;
                    break;
                case "leather":
                    theStock = stocks.Leather;
                    theCost = worker.LeatherUpgradeCost;
                    break;
                case "copper":
                    theStock = stocks.Copper;
                    theCost = worker.CopperUpgradeCost;
                    break;
                case "iron":
                    theStock = stocks.Iron;
                    theCost = worker.IronUpgradeCost;
                    break;
                case "steel":
                    theStock = stocks.Steel;
                    theCost = worker.SteelUpgradeCost;
                    break;
            }

            if (theStock >= theCost)
            {
                return true;
            }

            else { return false; }
        }
        /// <summary>
        /// Updates the given Worker cost with the multiplyer supplied.
        /// </summary>
        /// <param name="worker">The worker to use.</param>
        /// <param name="resource">The resourse to modify.</param>
        /// <param name="math">Do we multiply or divide?</param>
        /// <param name="multiplyer">The amount to multiply by.</param>
        internal void UpdateCost(Worker worker, string resource, string math, double multiplyer)
        {
            if(math == "*")
                switch (resource)
                {
                    case "wood":
                        worker.WoodCost = RoundIt(worker.WoodCost, "*", multiplyer);
                        break;
                    case "stone":
                        worker.StoneCost = RoundIt(worker.StoneCost, "*", multiplyer);
                        break;
                    case "leather":
                        worker.LeatherCost = RoundIt(worker.LeatherCost, "*", multiplyer);
                        break;
                    case "copper":
                        worker.CopperCost = RoundIt(worker.CopperCost, "*", multiplyer);
                        break;
                    case "iron":
                        worker.IronCost = RoundIt(worker.IronCost, "*", multiplyer);
                        break;
                    case "steel":
                        worker.SteelCost = RoundIt(worker.SteelCost, "*", multiplyer);
                        break;
                }
            else if(math == "/")
                switch (resource)
                {
                    case "wood":
                        worker.WoodCost = RoundIt(worker.WoodCost, "/", multiplyer);
                        break;
                    case "stone":
                        worker.StoneCost = RoundIt(worker.StoneCost, "/", multiplyer);
                        break;
                    case "leather":
                        worker.LeatherCost = RoundIt(worker.LeatherCost, "/", multiplyer);
                        break;
                    case "copper":
                        worker.CopperCost = RoundIt(worker.CopperCost, "/", multiplyer);
                        break;
                    case "iron":
                        worker.IronCost = RoundIt(worker.IronCost, "/", multiplyer);
                        break;
                    case "steel":
                        worker.SteelCost = RoundIt(worker.SteelCost, "/", multiplyer);
                        break;
                }
        }
        /// <summary>
        /// Updates the given Building cost with the multiplyer supplied.
        /// </summary>
        /// <param name="building">The building to use.</param>
        /// <param name="resource">The resourse to Modify.</param>
        /// <param name="math">Do we multiply or divide?</param>
        /// <param name="multiplyer">The multiplyer to use.</param>
        internal void UpdateCost(Building building, string resource, string math, double multiplyer)
        {
            if(math == "*")
                switch (resource)
                {
                    case "wood":
                        building.WoodCost = RoundIt(building.WoodCost, "*", multiplyer);
                        break;
                    case "stone":
                        building.StoneCost = RoundIt(building.StoneCost, "*", multiplyer);
                        break;
                    case "leather":
                        building.LeatherCost = RoundIt(building.LeatherCost, "*", multiplyer);
                        break;
                    case "copper":
                        building.CopperCost = RoundIt(building.CopperCost, "*", multiplyer);
                        break;
                    case "iron":
                        building.IronCost = RoundIt(building.IronCost, "*", multiplyer);
                        break;
                    case "steel":
                        building.SteelCost = RoundIt(building.SteelCost, "*", multiplyer);
                        break;
                }
            else if(math == "/")
                switch (resource)
                {
                    case "wood":
                        building.WoodCost = RoundIt(building.WoodCost, "/", multiplyer);
                        break;
                    case "stone":
                        building.StoneCost = RoundIt(building.StoneCost, "/", multiplyer);
                        break;
                    case "leather":
                        building.LeatherCost = RoundIt(building.LeatherCost, "/", multiplyer);
                        break;
                    case "copper":
                        building.CopperCost = RoundIt(building.CopperCost, "/", multiplyer);
                        break;
                    case "iron":
                        building.IronCost = RoundIt(building.IronCost, "/", multiplyer);
                        break;
                    case "steel":
                        building.SteelCost = RoundIt(building.SteelCost, "/", multiplyer);
                        break;
                }
        }
        /// <summary>
        /// Used to update the upgrade costs of the given worker.
        /// </summary>
        /// <param name="worker">The worker to use.</param>
        /// <param name="resource">The resourse to alter.</param>
        /// <param name="math">Multiply or divide?</param>
        /// <param name="multiplyer">Increase/decrease by how much?</param>
        internal void UpdateUpgradeCost(Worker worker, string resource, string math, double multiplyer)
        {
            switch (resource)
            {
                case "wood":
                    worker.WoodUpgradeCost = RoundIt(worker.WoodUpgradeCost, "*", multiplyer);
                    break;
                case "stone":
                    worker.StoneUpgradeCost = RoundIt(worker.StoneUpgradeCost, "*", multiplyer);
                    break;
                case "leather":
                    worker.LeatherUpgradeCost = RoundIt(worker.LeatherUpgradeCost, "*", multiplyer);
                    break;
                case "copper":
                    worker.CopperUpgradeCost = RoundIt(worker.CopperUpgradeCost, "*", multiplyer);
                    break;
                case "iron":
                    worker.IronUpgradeCost = RoundIt(worker.IronUpgradeCost, "*", multiplyer);
                    break;
                case "steel":
                    worker.SteelUpgradeCost = RoundIt(worker.SteelUpgradeCost, "*", multiplyer);
                    break;
            }
        }
        /// <summary>
        /// Used to update the upgrade costs of the given building.
        /// </summary>
        /// <param name="worker">The building to use.</param>
        /// <param name="resource">The resourse to alter.</param>
        /// <param name="math">Multiply or divide?</param>
        /// <param name="multiplyer">Increase/decrease by how much?</param>
        internal void UpdateUpgradeCost(Building building, string resource, string math, double multiplyer)
        {
            //switch (resource)
            //{
            //    case "wood":
            //        building.WoodUpgradeCost = RoundIt(building.WoodUpgradeCost, "*", multiplyer);
            //        break;
            //    case "stone":
            //        building.StoneUpgradeCost = RoundIt(building.StoneUpgradeCost, "*", multiplyer);
            //        break;
            //    case "leather":
            //        building.leatherUpgradeCost = RoundIt(building.leatherUpgradeCost, "*", multiplyer);
            //        break;
            //    case "copper":
            //        building.CopperUpgradeCost = RoundIt(building.CopperUpgradeCost, "*", multiplyer);
            //        break;
            //    case "iron":
            //        building.IronUpgradeCost = RoundIt(building.IronUpgradeCost, "*", multiplyer);
            //        break;
            //    case "steel":
            //        building.SteelUpgradeCost = RoundIt(building.SteelUpgradeCost, "*", multiplyer);
            //        break;
            //}
        }// TODO: Add building upgrades
        /// <summary>
        /// Removes the amount provided from the given stock area. 
        /// </summary>
        /// <param name="stocks">The stock to take from.</param>
        /// <param name="cost">The cost to remove.</param>
        /// <param name="resource">The resource to update.</param>
        internal void UpdateStocks(double cost, string resource)
        {
            switch (resource)
            {
                case "wood":
                    stocks.Wood -= cost;
                    break;
                case "stone":
                    stocks.Stone -= cost;
                    break;
                case "leather":
                    stocks.Leather -= cost;
                    break;
                case "copper":
                    stocks.Copper -= cost;
                    break;
                case "iron":
                    stocks.Iron -= cost;
                    break;
                case "steel":
                    stocks.Steel -= cost;
                    break;
            }

            mainHelper.UpdateResource(resource);
        }
        /// <summary>
        /// Overload method for UpdateStocks. This adds the funds back to the stocks.
        /// </summary>
        /// <param name="stocks">The stock to add to.</param>
        /// <param name="multiplyer">The multiplyer to use.</param>
        /// <param name="cost">The cost of the resources.</param>
        /// <param name="resource">The resourse to update.</param>
        internal void UpdateStocks(double cost, double multiplyer, string resource)
        {
            switch (resource)
            {
                case "wood":
                    stocks.Wood += RoundIt(cost, "/", multiplyer);
                    break;
                case "stone":
                    stocks.Stone += RoundIt(cost, "/", multiplyer);
                    break;
                case "leather":
                    stocks.Leather += RoundIt(cost, "/", multiplyer);
                    break;
                case "copper":
                    stocks.Copper += RoundIt(cost, "/", multiplyer);
                    break;
                case "iron":
                    stocks.Iron += RoundIt(cost, "/", multiplyer);
                    break;
                case "steel":
                    stocks.Steel += RoundIt(cost, "/", multiplyer);
                    break;
            }
            mainHelper.UpdateResource(resource);
        }
        /// <summary>
        /// Rounds the results of the given value. 
        /// </summary>
        /// <param name="cost">The cost.</param>
        /// <param name="multiplyer">Multiplyer to use.</param>
        /// <returns></returns>
        internal double RoundIt(double cost, string math, double multiplyer)
        {
            double rounded = 0f;

            switch (math)
            {
                case "*":
                    rounded = Math.Round(cost * multiplyer, 0, MidpointRounding.AwayFromZero);
                    break;
                case "/":
                    rounded = Math.Round(cost / multiplyer, 0, MidpointRounding.AwayFromZero);
                    break;
            }

            return rounded;
        }
        /// <summary>
        /// Used for the text above the stocks.
        /// </summary>
        /// <param name="level">The stock's level.</param>
        /// <returns></returns>
        internal string StockUpgradeTitle(int level)
        {
            string newTitle = "";

            switch (level.ToString())
            {
                case "1":
                    newTitle = "Boxes";
                    break;
                case "2":
                    newTitle = "Barrels";
                    break;
                case "3":
                    newTitle = "Crates";
                    break;
            }

            return newTitle;
        }
        /// <summary>
        /// Sends text to the gameEventDisplay of purchases, sells, or other things.
        /// </summary>
        /// <param name="theAction">The action taken</param>
        /// <param name="thePurchase">The pruchase made</param>
        /// <param name="isUpgrade">Is it an upgrade purchase?</param>
        internal void ActionDisplay(string theAction, string thePurchase, bool isUpgrade = false)
        {
            switch (theAction)
            {
                case "buy":
                    main.gameEventDisplay.Text += "Purchased " + thePurchase + (isUpgrade ? " upgrade!" : "!") + 
                        " @ " + DateTime.Now + Environment.NewLine + Environment.NewLine;
                    break;
                case "sell":
                    main.gameEventDisplay.Text += "Sold " + thePurchase + "! @ " + 
                        DateTime.Now + Environment.NewLine + Environment.NewLine;
                    break;
            }
        }
    }
}
