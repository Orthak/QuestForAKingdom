using System.Windows.Forms;
using Quest_for_a_Kingdom.Helpers;

namespace Quest_for_a_Kingdom
{
    /// <summary>
    /// This class takes care of all of the purchasing and selling of the workers, upgrades, and buldings. 
    /// </summary>
    public class Shop
    {
        private MainForm main;
        private MainHelper mainHelper;
        private LabelTextHelper textHelper;
        private Stocks stocks;
        private Worker worker;
        private ShopHelper helper;
        

        internal Shop(Stocks _stocks, MainForm _main, MainHelper _mainHelper, LabelTextHelper _textHelper, Worker _workers)
        {
            main = _main;
            mainHelper = _mainHelper;
            stocks = _stocks;
            textHelper = _textHelper;
            worker = _workers;
            helper = new ShopHelper(stocks, main, mainHelper);
        }

        // Purchase Workers
        internal void PurchaseWoodcutters(Worker woodcutter, Button wcPurchase, Label wcNumberLabel)
        {
            // Check if we can add workers
            if (woodcutter.Number < worker.WorkersCap)
                // Check if we have the funds
                if (helper.CanAfford(woodcutter, "wood") && helper.CanAfford(woodcutter, "stone"))
                {
                    // Add one worker
                    woodcutter.Number++;

                    // Subtract the resources needed from the stockpile
                    helper.UpdateStocks(woodcutter.WoodCost, "wood");
                    helper.UpdateStocks(woodcutter.StoneCost, "stone");

                    // Update the new cost of the next worker
                    helper.UpdateCost(woodcutter, "wood", "*", 1.7f);
                    helper.UpdateCost(woodcutter, "stone", "*", 1.6f);

                    // Update the button and label text
                    wcPurchase.Text = "Woodcutter\nWood-" + woodcutter.WoodCost +
                        " Stone-" + woodcutter.StoneCost;

                    wcNumberLabel.Text = woodcutter.Number.ToString();

                    helper.ActionDisplay("buy", "woodcutter");

                    if (mainHelper.isFirstPurchase == false)
                        mainHelper.isFirstPurchase = true;
                }
        }

        internal void PurchaseMiners(Worker miner, Button mnrPurchase, Label mnrNumberLabel)
        {
            // Check if we have room for more
            if (miner.Number < worker.WorkersCap)
                // Check if we have the funds
                if (helper.CanAfford(miner, "wood") && helper.CanAfford(miner, "stone"))
                {
                    // Add the worker
                    miner.Number++;

                    // Subtract the resources needed from the stockpile
                    helper.UpdateStocks(miner.WoodCost, "wood");
                    helper.UpdateStocks(miner.StoneCost, "stone");

                    // Update the cost for the next worker
                    helper.UpdateCost(miner, "wood", "*", 1.7f);
                    helper.UpdateCost(miner, "stone", "*", 1.6f);

                    // Update the buton and label text
                    mnrPurchase.Text = "Miner\nWood-" + miner.WoodCost +
                        " Stone-" + miner.StoneCost;

                    mnrNumberLabel.Text = miner.Number.ToString();

                    helper.ActionDisplay("buy", "miner");

                    if (mainHelper.isFirstPurchase == false)
                        mainHelper.isFirstPurchase = true;
                }
        }

        internal void PurchaseFarmers(Worker farmer, Button purchaseFarmers, Label farmersNumberLabel)
        {
            if (farmer.Number < worker.WorkersCap)
                if (helper.CanAfford(farmer, "wood") && helper.CanAfford(farmer, "stone"))
                {
                    // Add worker
                    farmer.Number++;

                    // Pay the cost
                    helper.UpdateStocks(farmer.WoodCost, "wood");
                    helper.UpdateStocks(farmer.StoneCost, "stone");

                    //Update the cost
                    helper.UpdateCost(farmer, "wood", "*", 1.7f);
                    helper.UpdateCost(farmer, "stone", "*", 1.6);

                    //Update text
                    purchaseFarmers.Text = "Farmer\nWood-" + farmer.WoodCost +
                        " Stone-" + farmer.StoneCost;

                    farmersNumberLabel.Text = farmer.Number.ToString();

                    helper.ActionDisplay("buy", "farmer");

                    if (mainHelper.isFirstPurchase == false)
                        mainHelper.isFirstPurchase = true;
                }
        }

        internal void PurchaseHunters(Worker hunter, Button purchaseHunters, Label huntersNumberLabel)
        {
            if (hunter.Number < worker.WorkersCap)
                if (helper.CanAfford(hunter, "wood") && helper.CanAfford(hunter, "stone") && helper.CanAfford(hunter, "copper"))
                {
                    // Add the worker
                    hunter.Number++;

                    // Pay the resources
                    helper.UpdateStocks(hunter.WoodCost, "wood");
                    helper.UpdateStocks(hunter.StoneCost, "stone");
                    helper.UpdateStocks(hunter.CopperCost, "copper");

                    // Update the cost
                    helper.UpdateCost(hunter, "wood", "*", 1.6f);
                    helper.UpdateCost(hunter, "stone", "*", 1.6f);
                    helper.UpdateCost(hunter, "copper", "*", 1.8f);

                    // Update the text
                    purchaseHunters.Text = "Hunter\nWood-" + hunter.WoodCost +
                        " Stone-" + hunter.StoneCost + " Copper-" + hunter.CopperCost;

                    huntersNumberLabel.Text = hunter.Number.ToString();

                    helper.ActionDisplay("buy", "hunter");

                    if (mainHelper.isFirstPurchase == false)
                        mainHelper.isFirstPurchase = true;
                }
        }

        internal void PurchaseMetalWorkers(Worker metalWorker, Button purchaseMetalWorkers, Label metalWorkersNumberLabel)
        {
            if (metalWorker.Number < worker.WorkersCap)
                if (helper.CanAfford(metalWorker, "wood") && helper.CanAfford(metalWorker, "stone") && helper.CanAfford(metalWorker, "copper") &&
                    helper.CanAfford(metalWorker, "iron"))
                {
                    // Add the worker
                    metalWorker.Number++;

                    // Pay the resources
                    helper.UpdateStocks(metalWorker.WoodCost, "wood");
                    helper.UpdateStocks(metalWorker.StoneCost, "stone");
                    helper.UpdateStocks(metalWorker.CopperCost, "copper");
                    helper.UpdateStocks(metalWorker.IronCost, "iron");

                    // Update the cost
                    helper.UpdateCost(metalWorker, "wood", "*", 1.6f);
                    helper.UpdateCost(metalWorker, "stone", "*", 1.7f);
                    helper.UpdateCost(metalWorker, "copper", "*", 1.7f);
                    helper.UpdateCost(metalWorker, "iron", "*", 1.8f);

                    // Update the text
                    purchaseMetalWorkers.Text = "MetalWorkers\nWood-" + metalWorker.WoodCost +
                        " Stone-" + metalWorker.StoneCost +
                        " Copper-" + metalWorker.CopperCost +
                        " Iron-" + metalWorker.IronCost;

                    metalWorkersNumberLabel.Text = metalWorker.Number.ToString();

                    helper.ActionDisplay("buy", "metalworker");

                    if (mainHelper.isFirstPurchase == false)
                        mainHelper.isFirstPurchase = true;
                }
        }

        // Sell Workers
        internal void SellWoodcutters(Worker woodcutters, Button purchaseWoodcutters, Label woodcuttersNumberLabel)
        {
            // Check if the number of workers is above zero
            if (woodcutters.Number > 0)
            {
                // Subtract one worker from the group
                woodcutters.Number--;

                // Refund the player the spent resources
                helper.UpdateStocks(woodcutters.WoodCost, 1.7f, "wood");
                helper.UpdateStocks(woodcutters.StoneCost, 1.6f, "stone");

                // Roll-back the cost of the next worker
                helper.UpdateCost(woodcutters, "wood", "/", 1.7f);
                helper.UpdateCost(woodcutters, "stone", "/", 1.6f);

                // Update the button's text
                purchaseWoodcutters.Text = "Woodcutter\nWood-" + woodcutters.WoodCost +
                        " Stone-" + woodcutters.StoneCost;

                // Update the workers number label
                woodcuttersNumberLabel.Text = woodcutters.Number + "/" + worker.WorkersCap;

                helper.ActionDisplay("sell", "woodcutter");

                mainHelper.workersSold++;
            }
        }

        internal void SellMiners(Worker miners, Button purchaseMiner, Label minersNumberLabel)
        {
            // Check if the number of workers is above zero
            if (miners.Number > 0)
            {
                // Subtract one worker from the group
                miners.Number--;

                // Refund the player the spent resources
                helper.UpdateStocks(miners.WoodCost, 1.7f, "wood");
                helper.UpdateStocks(miners.StoneCost, 1.6f, "stone");

                // Roll-back the cost of the next worker
                helper.UpdateCost(miners, "wood", "/", 1.7f);
                helper.UpdateCost(miners, "stone", "/", 1.6f);

                // Update the button's text
                purchaseMiner.Text = "Miner\nWood-" + miners.WoodCost +
                        " Stone-" + miners.StoneCost;

                // Update the workers number label
                minersNumberLabel.Text = miners.Number + "/" + worker.WorkersCap;

                helper.ActionDisplay("sell", "miner");

                mainHelper.workersSold++;
            }
        }

        internal void SellFarmers(Worker farmers, Button purchaseFarmers, Label farmersNumberLabel)
        {
            // Check if the number of workers is above zero
            if (farmers.Number > 0)
            {
                // Subtract one worker from the group
                farmers.Number--;

                // Refund the player the spent resources
                helper.UpdateStocks(farmers.WoodCost, 1.7f, "wood");
                helper.UpdateStocks(farmers.StoneCost, 1.6f, "stone");

                // Roll-back the cost of the next worker
                helper.UpdateCost(farmers, "wood", "/", 1.7f);
                helper.UpdateCost(farmers, "stone", "/", 1.6f);

                // Update the button's text
                purchaseFarmers.Text = "Farmer\nWood-" + farmers.WoodCost +
                        " Stone-" + farmers.StoneCost;

                // Update the workers number label
                farmersNumberLabel.Text = farmers.Number + "/" + worker.WorkersCap;

                helper.ActionDisplay("sell", "farmer");

                mainHelper.workersSold++;
            }
        }

        internal void SellHunters(Worker hunters, Button purchaseHunters, Label huntersNumberLabel)
        {
            // Check if the number of workers is above zero
            if (hunters.Number > 0)
            {
                // Subtract one worker from the group
                hunters.Number--;

                // Refund the player the spent resources
                helper.UpdateStocks(hunters.WoodCost, 1.6f, "wood");
                helper.UpdateStocks(hunters.StoneCost, 1.6f, "stone");
                helper.UpdateStocks(hunters.CopperCost, 1.8f, "copper");

                // Roll-back the cost of the next worker
                helper.UpdateCost(hunters, "wood", "/", 1.6f);
                helper.UpdateCost(hunters, "stone", "/", 1.6f);
                helper.UpdateCost(hunters, "copper", "/", 1.8f);

                // Update the button's text
                purchaseHunters.Text = "Hunter\nWood-" + hunters.WoodCost +
                        " Stone-" + hunters.StoneCost +
                        " Copper-" + hunters.CopperCost;

                // Update the workers number label
                huntersNumberLabel.Text = hunters.Number + "/" + worker.WorkersCap;

                helper.ActionDisplay("sell", "hunter");

                mainHelper.workersSold++;
            }
        }

        internal void SellMetalworkers(Worker metalWorkers, Button purchaseMetalWorkers, Label metalWorkersNumberLabel)
        {
            // If we have workers to sell
            if (metalWorkers.Number > 0)
            {
                // Subtract the worker
                metalWorkers.Number--;

                // Refund the player
                helper.UpdateStocks(metalWorkers.WoodCost, 1.6f, "wood");
                helper.UpdateStocks(metalWorkers.StoneCost, 1.7f, "stone");
                helper.UpdateStocks(metalWorkers.CopperCost, 1.7f, "copper");
                helper.UpdateStocks(metalWorkers.IronCost, 1.8f, "iron");

                // Update the Cost
                helper.UpdateCost(metalWorkers, "wood", "/", 1.6f);
                helper.UpdateCost(metalWorkers, "stone", "/", 1.7f);
                helper.UpdateCost(metalWorkers, "copper", "/", 1.7f);
                helper.UpdateCost(metalWorkers, "iron", "/", 1.8f);

                // Update the text
                purchaseMetalWorkers.Text = "MetalWorkers\nWood-" + metalWorkers.WoodCost +
                    " Stone-" + metalWorkers.StoneCost +
                    " Copper-" + metalWorkers.CopperCost +
                    " Iron-" + metalWorkers.IronCost;

                metalWorkersNumberLabel.Text = metalWorkers.Number + "/" + worker.WorkersCap;

                helper.ActionDisplay("sell", "metalworker");

                mainHelper.workersSold++;
            }
        }

        //Purchase Buildings
        internal void PurchaseTents(Building tent, Button purchaseTents, Label tentsNumberLabel)
        {
            if (helper.CanAfford(tent, "wood") && helper.CanAfford(tent, "stone") && helper.CanAfford(tent, "leather"))
            {
                // Increase the number, and workers' cap
                tent.NumberOf++;
                worker.WorkersCap++;

                // Pay the cost
                helper.UpdateStocks(tent.WoodCost, "wood");
                helper.UpdateStocks(tent.StoneCost, "stone");
                helper.UpdateStocks(tent.LeatherCost, "leather");

                // Update the cost
                helper.UpdateCost(tent, "wood", "*", 1.7f);
                helper.UpdateCost(tent, "stone", "*", 1.8f);
                helper.UpdateCost(tent, "leather", "*", 1.6f);

                // Update the text
                purchaseTents.Text = "Tents\nWood-" + tent.WoodCost +
                    " Stone-" + tent.StoneCost + " leather-" + tent.LeatherCost;

                tentsNumberLabel.Text = tent.NumberOf.ToString();
                textHelper.UpdateWorkersCapText();
                helper.ActionDisplay("buy", "tent");

                if (mainHelper.isFirstPurchase == false)
                    mainHelper.isFirstPurchase = true;
            }
        }

        internal void PurchaseHuts(Building hut, Button purchaseHuts, Label hutsNumberLabel)
        {
            if (helper.CanAfford(hut, "wood") && helper.CanAfford(hut, "stone") && helper.CanAfford(hut, "leather") &&
                helper.CanAfford(hut, "copper"))
            {
                // Increase the number, and the workers' cap
                hut.NumberOf++;
                worker.WorkersCap += 2;

                // Pay the cost
                helper.UpdateStocks(hut.WoodCost, "wood");
                helper.UpdateStocks(hut.StoneCost, "stone");
                helper.UpdateStocks(hut.LeatherCost, "leather");
                helper.UpdateStocks(hut.CopperCost, "copper");

                // Update the cost
                helper.UpdateCost(hut, "wood", "*", 1.7f);
                helper.UpdateCost(hut, "stone", "*", 1.7f);
                helper.UpdateCost(hut, "leather", "*", 1.6f);
                helper.UpdateCost(hut, "copper", "*", 1.6f);

                // Update the text
                purchaseHuts.Text = "Huts\nWood-" + hut.WoodCost +
                    " Stone-" + hut.StoneCost + " leather-" + hut.LeatherCost +
                    " Copper-" + hut.CopperCost;

                hutsNumberLabel.Text = hut.NumberOf.ToString();
                textHelper.UpdateWorkersCapText();
                helper.ActionDisplay("buy", "hut");

                if (mainHelper.isFirstPurchase == false)
                    mainHelper.isFirstPurchase = true;
            }
        }

        internal void PurchaseCabins(Building cabin, Button purchaseCabins, Label cabinsNumberLabel)
        {
            if (helper.CanAfford(cabin, "wood") && helper.CanAfford(cabin, "stone") && helper.CanAfford(cabin, "leather") &&
                helper.CanAfford(cabin, "copper") && helper.CanAfford(cabin, "iron"))
            {
                // Increase the number, and the workers' cap
                cabin.NumberOf++;
                worker.WorkersCap += 4;

                // Pay the cost
                helper.UpdateStocks(cabin.WoodCost, "wood");
                helper.UpdateStocks(cabin.StoneCost, "stone");
                helper.UpdateStocks(cabin.LeatherCost, "leather");
                helper.UpdateStocks(cabin.CopperCost, "copper");
                helper.UpdateStocks(cabin.CopperCost, "iron");

                // Update the cost
                helper.UpdateCost(cabin, "wood", "*", 1.8f);
                helper.UpdateCost(cabin, "stone", "*", 1.7f);
                helper.UpdateCost(cabin, "leather", "*", 1.6f);
                helper.UpdateCost(cabin, "copper", "*", 1.5f);
                helper.UpdateCost(cabin, "iron", "*", 1.6f);

                // Update the text
                purchaseCabins.Text = "Tents\nWood-" + cabin.WoodCost +
                    " Stone-" + cabin.StoneCost + " leather-" + cabin.LeatherCost +
                    " Copper-" + cabin.CopperCost + " Iron-" + cabin.IronCost;

                cabinsNumberLabel.Text = cabin.NumberOf.ToString();
                textHelper.UpdateWorkersCapText();
                helper.ActionDisplay("buy", "cabin");

                if (mainHelper.isFirstPurchase == false)
                    mainHelper.isFirstPurchase = true;
            }
        }

        internal void PurchaseBarracks(Building barrack, Button purchaseBarracks, Label barracksNumberLabel)
        {
            if (helper.CanAfford(barrack, "wood") && helper.CanAfford(barrack, "stone") && helper.CanAfford(barrack, "leather") &&
                helper.CanAfford(barrack, "copper") && helper.CanAfford(barrack, "iron") && helper.CanAfford(barrack, "steel"))
            {
                // Increase the number, and the workers' cap
                barrack.NumberOf++;
                worker.WorkersCap += 8;

                // Pay the cost
                helper.UpdateStocks(barrack.WoodCost, "wood");
                helper.UpdateStocks(barrack.StoneCost, "stone");
                helper.UpdateStocks(barrack.LeatherCost, "leather");
                helper.UpdateStocks(barrack.CopperCost, "copper");
                helper.UpdateStocks(barrack.CopperCost, "iron");
                helper.UpdateStocks(barrack.CopperCost, "steel");

                // Update the cost
                helper.UpdateCost(barrack, "wood", "*", 1.8f);
                helper.UpdateCost(barrack, "stone", "*", 1.8f);
                helper.UpdateCost(barrack, "leather", "*", 1.7f);
                helper.UpdateCost(barrack, "copper", "*", 1.7f);
                helper.UpdateCost(barrack, "iron", "*", 1.6f);
                helper.UpdateCost(barrack, "steel", "*", 1.6f);

                // Update the text
                purchaseBarracks.Text = "Tents\nWood-" + barrack.WoodCost +
                    " Stone-" + barrack.StoneCost + " leather-" + barrack.LeatherCost +
                    " Copper-" + barrack.CopperCost + " Iron-" + barrack.IronCost +
                    " Steel- " + barrack.SteelCost;

                barracksNumberLabel.Text = barrack.NumberOf.ToString();
                textHelper.UpdateWorkersCapText();
                helper.ActionDisplay("buy", "barracks");

                if (mainHelper.isFirstPurchase == false)
                    mainHelper.isFirstPurchase = true;
            }
        }

        // Sell Buildings
        internal void SellTents(Building tents, Button purchaseTents, Label tentsNumberLabel)
        {
            if (tents.NumberOf > 0)
            {
                tents.NumberOf--;

                helper.UpdateStocks(tents.WoodCost, 1.7f, "wood");
                helper.UpdateStocks(tents.StoneCost, 1.8f, "stone");
                helper.UpdateStocks(tents.LeatherCost, 1.6f, "leather");

                helper.UpdateCost(tents, "wood", "/", 1.7f);
                helper.UpdateCost(tents, "stone", "/", 1.8f);
                helper.UpdateCost(tents, "leather", "/", 1.6f);

                purchaseTents.Text = "Tents\nWood- " + tents.WoodCost +
                    " Stone-" + tents.StoneCost +
                    " leather-" + tents.LeatherCost;

                tentsNumberLabel.Text = tents.NumberOf.ToString();

                helper.ActionDisplay("sell", "tent");
            }
        }

        internal void SellHuts(Building huts, Button purchaseHuts, Label hutsNumberLabel)
        {
            if (huts.NumberOf > 0)
            {
                huts.NumberOf--;

                helper.UpdateStocks(huts.WoodCost, 1.7f, "wood");
                helper.UpdateStocks(huts.StoneCost, 1.7f, "stone");
                helper.UpdateStocks(huts.LeatherCost, 1.6f, "leather");
                helper.UpdateStocks(huts.CopperCost, 1.6f, "copper");

                helper.UpdateCost(huts, "wood", "/", 1.7f);
                helper.UpdateCost(huts, "stone", "/", 1.7f);
                helper.UpdateCost(huts, "leather", "/", 1.6f);
                helper.UpdateCost(huts, "copper", "/", 1.6f);

                purchaseHuts.Text = "huts\nWood- " + huts.WoodCost +
                    " Stone-" + huts.StoneCost +
                    " leather-" + huts.LeatherCost +
                    " Copper-" + huts.CopperCost;

                hutsNumberLabel.Text = huts.NumberOf.ToString();

                helper.ActionDisplay("sell", "hut");
            }
        }

        internal void SellCabins(Building cabins, Button purchaseCabins, Label cabinsNumberLabel)
        {
            if (cabins.NumberOf > 0)
            {
                cabins.NumberOf--;

                helper.UpdateStocks(cabins.WoodCost, 1.8f, "wood");
                helper.UpdateStocks(cabins.StoneCost, 1.7f, "stone");
                helper.UpdateStocks(cabins.LeatherCost, 1.6f, "leather");
                helper.UpdateStocks(cabins.CopperCost, 1.5f, "copper");
                helper.UpdateStocks(cabins.IronCost, 1.6f, "iron");

                helper.UpdateCost(cabins, "wood", "/", 1.8f);
                helper.UpdateCost(cabins, "stone", "/", 1.7f);
                helper.UpdateCost(cabins, "leather", "/", 1.6f);
                helper.UpdateCost(cabins, "copper", "/", 1.5f);
                helper.UpdateCost(cabins, "iron", "/", 1.6f);

                purchaseCabins.Text = "cabins\nWood- " + cabins.WoodCost +
                    " Stone-" + cabins.StoneCost +
                    " leather-" + cabins.LeatherCost +
                    " Copper-" + cabins.CopperCost +
                    " Iron-" + cabins.IronCost;

                cabinsNumberLabel.Text = cabins.NumberOf.ToString();

                helper.ActionDisplay("sell", "cabin");
            }
        }

        internal void SellBarracks(Building barracks, Button purchaseBarracks, Label barracksNumberLabel)
        {
            if (barracks.NumberOf > 0)
            {
                barracks.NumberOf--;

                helper.UpdateStocks(barracks.WoodCost, 1.7f, "wood");
                helper.UpdateStocks(barracks.StoneCost, 1.8f, "stone");
                helper.UpdateStocks(barracks.LeatherCost, 1.6f, "leather");
                helper.UpdateStocks(barracks.CopperCost, 1.6f, "copper");
                helper.UpdateStocks(barracks.IronCost, 1.6f, "iron");
                helper.UpdateStocks(barracks.SteelCost, 1.6f, "steel");

                helper.UpdateCost(barracks, "wood", "/", 1.7f);
                helper.UpdateCost(barracks, "stone", "/", 1.8f);
                helper.UpdateCost(barracks, "leather", "/", 1.6f);
                helper.UpdateCost(barracks, "copper", "/", 1.6f);
                helper.UpdateCost(barracks, "iron", "/", 1.6f);
                helper.UpdateCost(barracks, "steel", "/", 1.6f);

                purchaseBarracks.Text = "barracks\nWood- " + barracks.WoodCost +
                    " Stone-" + barracks.StoneCost +
                    " leather-" + barracks.LeatherCost +
                    " Copper-" + barracks.CopperCost + 
                    " Iron-" + barracks.IronCost +
                    " Steel-" + barracks.SteelCost;

                barracksNumberLabel.Text = barracks.NumberOf.ToString();

                helper.ActionDisplay("sell", "barrack");
            }
        }

        // Upgrades
        internal void WoodcutterUpgrade(Worker woodcutters, Button woodcutterUpgrade, Label woodcuttersLabel)
        {
            if (helper.CanAffordUpgrade(woodcutters, "wood") && helper.CanAffordUpgrade(woodcutters, "stone"))
            {
                woodcutters.UpgradeLevel++;

                helper.UpdateStocks(woodcutters.WoodUpgradeCost, "wood");
                helper.UpdateStocks(woodcutters.StoneUpgradeCost, "stone");

                helper.UpdateUpgradeCost(woodcutters, "wood", "*", 1.8f);
                helper.UpdateUpgradeCost(woodcutters, "stone", "*", 1.7f);

                woodcutterUpgrade.Text = "Woodcutter Upgrade\nWood-" + woodcutters.WoodUpgradeCost +
                    " Stone-" + woodcutters.StoneUpgradeCost;

                woodcuttersLabel.Text = "Woodcutters +" + woodcutters.UpgradeLevel;

                helper.ActionDisplay("buy", "woodcutter", true);
            }
        }

        internal void PurchaseMinerUpgrade(Worker miners, Button purchaseMinerUpgrade, Label minersLabel)
        {
            if (helper.CanAffordUpgrade(miners, "wood") &&
                helper.CanAffordUpgrade(miners, "stone") &&
                helper.CanAffordUpgrade(miners, "copper") &&
                helper.CanAffordUpgrade(miners, "iron"))
            {
                miners.UpgradeLevel++;

                helper.UpdateStocks(miners.WoodUpgradeCost, "wood");
                helper.UpdateStocks(miners.StoneUpgradeCost, "stone");
                helper.UpdateStocks(miners.CopperUpgradeCost, "copper");
                helper.UpdateStocks(miners.IronUpgradeCost, "iron");

                helper.UpdateUpgradeCost(miners, "wood", "*", 1.7f);
                helper.UpdateUpgradeCost(miners, "stone", "*", 1.6f);
                helper.UpdateUpgradeCost(miners, "copper", "*", 1.8f);
                helper.UpdateUpgradeCost(miners, "iron", "*", 1.9f);

                purchaseMinerUpgrade.Text = "Miner Upgrade\nWood-" + miners.WoodUpgradeCost +
                    " Stone-" + miners.StoneUpgradeCost +
                    " Copper-" + miners.CopperUpgradeCost +
                    " Iron-" + miners.IronUpgradeCost;

                minersLabel.Text = "Miners +" + miners.UpgradeLevel;

                helper.ActionDisplay("buy", "base miner", true);
            }
        }

        internal void CopperMinerUpgrade(Worker miners, Button copperMinerUpgrade, Label minersLabel)
        {
            if (stocks.Wood >= miners.CopperWoodCost && stocks.Stone >= miners.CopperStoneCost && stocks.Copper >= miners.CopperCopperCost)
            {
                miners.IsCopper = true;

                helper.UpdateStocks(miners.CopperWoodCost, "wood");
                helper.UpdateStocks(miners.CopperStoneCost, "stone");
                helper.UpdateStocks(miners.CopperCopperCost, "copper");

                minersLabel.Text = "Copper\nMiners";

                copperMinerUpgrade.Hide();

                helper.ActionDisplay("buy", "copper miner", true);
            }
        }

        internal void IronMinerUpgrade(Worker miners, Button ironMinerUpgrade, Label minersLabel)
        {
            if (stocks.Wood >= miners.IronWoodCost &&
                stocks.Stone >= miners.IronStoneCost &&
                stocks.Copper >= miners.IronCopperCost &&
                stocks.Iron >= miners.IronIronCost)
            {
                miners.IsIron = true;

                helper.UpdateStocks(miners.IronWoodCost, "wood");
                helper.UpdateStocks(miners.IronStoneCost, "stone");
                helper.UpdateStocks(miners.IronCopperCost, "copper");
                helper.UpdateStocks(miners.IronIronCost, "iron");

                minersLabel.Text = "Iron\nMiners";

                ironMinerUpgrade.Hide();

                helper.ActionDisplay("buy", "iron miner", true);
            }
        }

        internal void PurchaseFarmersUpgrade(Worker farmers, Button purchaseFarmersUpgrade, Label farmersLabel)
        {
            if (helper.CanAffordUpgrade(farmers, "wood") && helper.CanAffordUpgrade(farmers, "stone"))
            {
                farmers.UpgradeLevel++;
                farmers.UpgradeText++;

                helper.UpdateStocks(farmers.WoodUpgradeCost, "wood");
                helper.UpdateStocks(farmers.StoneUpgradeCost, "stone");

                helper.UpdateUpgradeCost(farmers, "wood", "*", 1.9f);
                helper.UpdateUpgradeCost(farmers, "stone", "*", 1.7f);

                purchaseFarmersUpgrade.Text = "Farmers Upgrade\nWood-" + farmers.WoodUpgradeCost +
                    " Stone-" + farmers.StoneUpgradeCost;

                farmersLabel.Text = "Farmers +" + farmers.UpgradeText;

                helper.ActionDisplay("buy", "farmer", true);
            }
        }

        internal void PurchaseHuntersUpgrade(Worker hunters, Button purchaseHuntersUpgrade, Label huntersLabel)
        {
            if (helper.CanAffordUpgrade(hunters, "wood") && helper.CanAffordUpgrade(hunters, "stone") && helper.CanAffordUpgrade(hunters, "copper"))
            {
                hunters.UpgradeLevel++;
                hunters.UpgradeText++;

                helper.UpdateStocks(hunters.WoodUpgradeCost, "wood");
                helper.UpdateStocks(hunters.StoneUpgradeCost, "stone");

                helper.UpdateUpgradeCost(hunters, "wood", "*", 1.9f);
                helper.UpdateUpgradeCost(hunters, "stone", "*", 1.7f);

                purchaseHuntersUpgrade.Text = "hunters Upgrade\nWood-" + hunters.WoodUpgradeCost +
                    " Stone-" + hunters.StoneUpgradeCost;

                huntersLabel.Text = "Hunters +" + hunters.UpgradeText;

                helper.ActionDisplay("buy", "hunter", true);
            }
        }

        internal void PurchaseMetalWorkersUpgrade(Worker metalWorkers, Button purchaseMetalWorkersUpgrade, Label metalWorkersLabel)
        {
            // Can we afford it?
            if (helper.CanAffordUpgrade(metalWorkers, "wood") &&
                helper.CanAffordUpgrade(metalWorkers, "stone") &&
                helper.CanAffordUpgrade(metalWorkers, "copper") &&
                helper.CanAffordUpgrade(metalWorkers, "iron"))
            {
                // Improve the level
                metalWorkers.UpgradeLevel++;

                // Subtract the amount from the stocks.
                helper.UpdateStocks(metalWorkers.WoodUpgradeCost, "wood");
                helper.UpdateStocks(metalWorkers.StoneUpgradeCost, "stone");
                helper.UpdateStocks(metalWorkers.CopperUpgradeCost, "copper");
                helper.UpdateStocks(metalWorkers.IronUpgradeCost, "iron");

                // Update the cost for the next purchase.
                helper.UpdateCost(metalWorkers, "wood", "*", 1.5f);
                helper.UpdateCost(metalWorkers, "stone", "*", 1.6f);
                helper.UpdateCost(metalWorkers, "copper", "*", 1.9f);
                helper.UpdateCost(metalWorkers, "iron", "*", 1.8f);

                // Update the text
                purchaseMetalWorkersUpgrade.Text = "Miner Upgrade\nWood-" + metalWorkers.WoodUpgradeCost +
                    " Stone-" + metalWorkers.StoneUpgradeCost +
                    " Copper-" + metalWorkers.CopperUpgradeCost +
                    " Iron-" + metalWorkers.IronUpgradeCost;

                metalWorkersLabel.Text = "MetalWorkers +" + metalWorkers.UpgradeLevel;

                helper.ActionDisplay("buy", "metalworker", true);
            }
        }

        internal void PurchaseStocksUpgrade(Button stocksUpgrade, Label stocksLevel, Label rationsLabel)
        {
            // Do we have the funds?
            if (stocks.Wood >= stocks.WoodUpgradeCost &&
                stocks.Stone >= stocks.StoneUpgradeCost &&
                stocks.Copper >= stocks.CopperUpgradeCost &&
                stocks.Iron >= stocks.IronUpgradeCost)
            {
                // Update the stock cap, and the stock upgrade text
                stocks.StockCap *= 2;
                stocks.RationsCap *= 2;

                stocksLevel.Text = helper.StockUpgradeTitle(stocks.UpgradeLevel) + "(Cap-" + stocks.StockCap + ")";
                rationsLabel.Text = "/" + stocks.RationsCap;

                // Subtract the nessessary funds
                helper.UpdateStocks(stocks.WoodUpgradeCost, "wood");
                helper.UpdateStocks(stocks.StoneUpgradeCost, "stone");
                helper.UpdateStocks(stocks.CopperUpgradeCost, "copper");
                helper.UpdateStocks(stocks.IronUpgradeCost, "iron");

                // Update the cost for the next purchase
                stocks.WoodUpgradeCost = helper.RoundIt(stocks.WoodUpgradeCost, "*", 2f);
                stocks.StoneUpgradeCost = helper.RoundIt(stocks.StoneUpgradeCost, "*", 2f);
                stocks.CopperUpgradeCost = helper.RoundIt(stocks.CopperUpgradeCost, "*", 2f);
                stocks.IronUpgradeCost = helper.RoundIt(stocks.IronUpgradeCost, "*", 2f);

                // Update the button text
                stocksUpgrade.Text = "Stocks Upgrade\nWood-" + stocks.WoodUpgradeCost +
                    " Stone-" + stocks.StoneUpgradeCost +
                    " Copper-" + stocks.CopperUpgradeCost +
                    " Iron-" + stocks.IronUpgradeCost;

                if (stocks.UpgradeLevel == 3)
                {
                    stocksUpgrade.Hide();
                }
                stocks.UpgradeLevel++;

                helper.ActionDisplay("buy", "stocks", true);
            }
        }

        internal void PurchaseSelfUpgrade(Worker self, Button purchaseSelfUpgrade)
        {
            // Can we afford it?
            if (helper.CanAffordUpgrade(self, "wood") &&
                helper.CanAffordUpgrade(self, "stone") &&
                helper.CanAffordUpgrade(self, "copper") &&
                helper.CanAffordUpgrade(self, "iron"))
            {
                // Subtract the amount from the stocks
                helper.UpdateStocks(self.WoodUpgradeCost, "wood");
                helper.UpdateStocks(self.StoneUpgradeCost, "stone");
                helper.UpdateStocks(self.CopperUpgradeCost, "copper");
                helper.UpdateStocks(self.IronUpgradeCost, "iron");

                // Update the cost for the next purchase
                helper.UpdateCost(self, "wood", "*", 1.8f);
                helper.UpdateCost(self, "stone", "*", 1.7f);
                helper.UpdateCost(self, "copper", "*", 1.7f);
                helper.UpdateCost(self, "iron", "*", 1.9);

                // Update the text
                purchaseSelfUpgrade.Text = "Self Upgrade\nWood-" + self.WoodUpgradeCost +
                    " Stone-" + self.StoneUpgradeCost +
                    " Copper-" + self.CopperUpgradeCost +
                    " Iron-" + self.IronUpgradeCost;

                helper.ActionDisplay("buy", "self", true);
            }
        }
    }
}