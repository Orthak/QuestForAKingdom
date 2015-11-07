using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quest_for_a_Kingdom.Helpers
{
    /// <summary>
    /// Helper class that contains the methods used by MainForm.
    /// </summary>
    [Serializable]
    public class MainHelper
    {
        private MainForm main;

        public Stocks stocks = new Stocks();
        public Achievement Achieve = new Achievement();
        public List<Achievement> achievements;

        // Workers
        public Worker worker = new Worker("worker", 5);
        public Worker woodcutter = new Worker("woodcutter", 10, 15);
        public Worker miner = new Worker("miner", 35, 25);
        public Worker farmer = new Worker("farmer", 15, 10);
        public Worker hunter = new Worker("hunter", 30, 30, copper: 10);
        public Worker metalworker = new Worker("metalworker", 40, 40, copper: 50, iron: 60);
        public Worker self = new Worker("self");

        // Buildings
        public Building tent = new Building("tent", 10, 5, 10);
        public Building hut = new Building("hut", 50, 40, 20, 30);
        public Building cabin = new Building("cabin", 130, 100, 70, 90, 60);
        public Building barracks = new Building("barracks", 210, 150, 130, 120, 100, 50);

        public Shop shop;

        // Resource totals
        public float totalResources;
        public float manualResources;
        public float autoResources;

        public int totalDeaths;
        public int workersSold;
        public bool stopWorkers;
        public bool goalReached;
        public bool isFirstPurchase;
        public bool OneOfEach()
        {
            if (woodcutter.Number >= 1 
                && miner.Number >= 1
                && farmer.Number >= 1
                && hunter.Number >= 1
                && metalworker.Number >= 1)
                return true;
            else
                return false;
        }

        public int workersPool = 0;
        public LabelTextHelper textHelper;

        public MainHelper(MainForm _main)
        {
            main = _main;
            textHelper = new LabelTextHelper(main, this);
        }

        #region Workers
        // Woodcutters
        public void AddWoodcutter(Worker woodcutter)
        {
            if (woodcutter.Number < worker.WorkersCap &&
                workersPool != 0)
            {
                woodcutter.Number++;
                workersPool--;
                textHelper.UpdateWorkersNumberText();
            }
        }

        public void SubtractWoodcutter(Worker woodcutter)
        {
            if (woodcutter.Number != 0)
            {
                woodcutter.Number--;
                workersPool++;
                textHelper.UpdateWorkersNumberText();
            }
        }

        // Miners
        public void AddMiner(Worker miner)
        {
            if (miner.Number < worker.WorkersCap &&
                workersPool != 0)
            {
                miner.Number++;
                workersPool--;
                textHelper.UpdateWorkersNumberText();
            }
        }

        public void SubtractMiner(Worker miner)
        {
            if (miner.Number != 0)
            {
                miner.Number--;
                workersPool++;
                textHelper.UpdateWorkersNumberText();
            }
        }

        // Farmers
        public void AddFarmer(Worker farmer)
        {
            if (farmer.Number < worker.WorkersCap &&
                workersPool != 0)
            {
                farmer.Number++;
                workersPool--;
                textHelper.UpdateWorkersNumberText();
            }
        }

        public void SubtractFarmer(Worker farmer)
        {
            if (farmer.Number != 0)
            {
                farmer.Number--;
                workersPool++;
                textHelper.UpdateWorkersNumberText();
            }
        }

        // Hunters
        public void AddHunter(Worker hunter)
        {
            if (hunter.Number < worker.WorkersCap &&
                workersPool != 0)
            {
                hunter.Number++;
                workersPool--;
                textHelper.UpdateWorkersNumberText();
            }
        }

        public void SubtractHunter(Worker hunter)
        {
            if (hunter.Number != 0)
            {
                hunter.Number--;
                workersPool++;
                textHelper.UpdateWorkersNumberText();
            }
        }

        // Metalworkers
        public void AddMetalworker(Worker metalworker)
        {
            if (metalworker.Number < worker.WorkersCap &&
                workersPool != 0)
            {
                metalworker.Number++;
                workersPool--;
                textHelper.UpdateWorkersNumberText();
            }
        }

        public void SubtractMetalworker(Worker metalworker)
        {
            if (metalworker.Number != 0)
            {
                metalworker.Number--;
                workersPool++;
                textHelper.UpdateWorkersNumberText();
            }
        }
        #endregion

        /// <summary>
        /// Sets all of the initial vales when the game starts
        /// </summary>
        public void SetStartingValues()
        {
            achievements = Achieve.CreateAchievements();

            totalResources = 0;
            stopWorkers = false;
            goalReached = false;

            // Set the farmers to actually produce rations.
            farmer.UpgradeLevel = 2;

            SetUpgradeCosts();
            CreateTimers();

            textHelper.UpdateStockTexts();
            textHelper.UpdateWorkersNumberText();
            textHelper.UpdateBuildingTexts();

            shop = new Shop(stocks, main, this, textHelper, worker);

            foreach (TabPage tabPage in main.shopTabControl.TabPages)
            {
                tabPage.AutoScroll = true;
            }

            main.gameEventDisplay.Text = "Game Start!!" + Environment.NewLine +
                                    "Reach 3,000 resources!" +
                                    Environment.NewLine + Environment.NewLine;
        }

        /// <summary>
        /// This is called when the resource buttons are clicked. Adds the resource to the pool.
        /// </summary>
        /// <param name="resource">The resource to add.</param>
        public void GenerateResource(string resource)
        {
            switch (resource)
            {
                case "wood":
                    stocks.Wood += self.UpgradeLevel;
                    break;
                case "stone":
                    stocks.Stone += self.UpgradeLevel;
                    break;
                case "copper":
                    stocks.Copper += self.UpgradeLevel;
                    break;
                case "iron":
                    stocks.Iron += self.UpgradeLevel;
                    break;
            }
            totalResources += self.UpgradeLevel;
            manualResources += self.UpgradeLevel;
            UpdateResource(resource);
        }

        /// <summary>
        /// Updates the resources text
        /// </summary>
        /// <param name="resource"></param>
        public void UpdateResource(string resource)
        {
            switch (resource)
            {
                case "wood":
                    main.woodAmount.Text = stocks.Wood.ToString();
                    break;
                case "stone":
                    main.stoneAmount.Text = stocks.Stone.ToString();
                    break;
                case "copper":
                    main.copperAmount.Text = stocks.Copper.ToString();
                    break;
                case "iron":
                    main.ironAmount.Text = stocks.Iron.ToString();
                    break;
                case "steel":
                    main.steelAmount.Text = stocks.Steel.ToString();
                    break;
                case "leather":
                    main.leatherAmount.Text = stocks.Leather.ToString();
                    break;
                case "rations":
                    main.rationsAmount.Text = stocks.Rations.ToString();
                    break;
            }
        }   
        
        /// <summary>
        /// We need to update the UI to properly display the loaded achievements
        /// list.
        /// </summary>
        public void UpdateAchievements()
        {
            ListViewGroup Locked = main.achievementsListView.Groups[0];
            ListViewGroup Unlocked = main.achievementsListView.Groups[1];

            Achievement firstOfMany
                = achievements.Where(a => a.Name == "First of Many").SingleOrDefault();
            Achievement oneOfEach
                = achievements.Where(a => a.Name == "One of Each").SingleOrDefault();
            Achievement theFirstHundred
                = achievements.Where(a => a.Name == "The First Hundred").SingleOrDefault();
            Achievement oneK
                = achievements.Where(a => a.Name == "OneK").SingleOrDefault();
            Achievement milestoneMillion
                = achievements.Where(a => a.Name == "Milestone Million").SingleOrDefault();
            Achievement manualMaker
                = achievements.Where(a => a.Name == "Milestone Million").SingleOrDefault();
            Achievement autoMaker
                = achievements.Where(a => a.Name == "Auto Maker").SingleOrDefault();
            Achievement acceptableLosses
                = achievements.Where(a => a.Name == "Acceptable Losses").SingleOrDefault();
            Achievement awayWithTheUseless
                = achievements.Where(a => a.Name == "Away with the Useless").SingleOrDefault();
            Achievement justTheStart
                = achievements.Where(a => a.Name == "Just the Start").SingleOrDefault();

            if (firstOfMany.IsUnlocked == true)
            {
                main.achievementsListView.Items[0].Group = Unlocked;
                main.achievementsListView.Items[0].ToolTipText = firstOfMany.Description;
            }

            if (oneOfEach.IsUnlocked == true)
            {
                main.achievementsListView.Items[1].Group = Unlocked;
                main.achievementsListView.Items[1].ToolTipText = oneOfEach.Description;
            }

            if (theFirstHundred.IsUnlocked == true)
            {
                main.achievementsListView.Items[2].Group = Unlocked;
                main.achievementsListView.Items[2].ToolTipText = theFirstHundred.Description;
            }

            if (oneK.IsUnlocked == true)
            {
                main.achievementsListView.Items[3].Group = Unlocked;
                main.achievementsListView.Items[3].ToolTipText = oneK.Description;
            }

            if (milestoneMillion.IsUnlocked == true)
            {
                main.achievementsListView.Items[4].Group = Unlocked;
                main.achievementsListView.Items[4].ToolTipText = milestoneMillion.Description;
            }

            if (manualMaker.IsUnlocked == true)
            {
                main.achievementsListView.Items[5].Group = Unlocked;
                main.achievementsListView.Items[5].ToolTipText = manualMaker.Description;
            }

            if (autoMaker.IsUnlocked == true)
            {
                main.achievementsListView.Items[6].Group = Unlocked;
                main.achievementsListView.Items[6].ToolTipText = autoMaker.Description;
            }

            if (acceptableLosses.IsUnlocked == true)
            {
                main.achievementsListView.Items[7].Group = Unlocked;
                main.achievementsListView.Items[7].ToolTipText = acceptableLosses.Description;
            }

            if (awayWithTheUseless.IsUnlocked == true)
            {
                main.achievementsListView.Items[8].Group = Unlocked;
                main.achievementsListView.Items[8].ToolTipText = awayWithTheUseless.Description;
            }

            if (goalReached == true)
            {
                main.achievementsListView.Items[9].Group = Unlocked;
                main.achievementsListView.Items[9].ToolTipText = justTheStart.Description;
            }
        }

        /// <summary>
        /// This method manages the unlocking of achievements
        /// </summary>
        private void ManageAchievements()
        {
            ListViewGroup Locked = main.achievementsListView.Groups[0];
            ListViewGroup Unlocked = main.achievementsListView.Groups[1];

            Achievement firstOfMany 
                = achievements.Where(a => a.Name == "First of Many").SingleOrDefault();
            Achievement oneOfEach 
                = achievements.Where(a => a.Name == "One of Each").SingleOrDefault();
            Achievement theFirstHundred 
                = achievements.Where(a => a.Name == "The First Hundred").SingleOrDefault();
            Achievement oneK 
                = achievements.Where(a => a.Name == "OneK").SingleOrDefault();
            Achievement milestoneMillion 
                = achievements.Where(a => a.Name == "Milestone Million").SingleOrDefault();
            Achievement manualMaker 
                = achievements.Where(a => a.Name == "Milestone Million").SingleOrDefault();
            Achievement autoMaker 
                = achievements.Where(a => a.Name == "Auto Maker").SingleOrDefault();
            Achievement acceptableLosses
                = achievements.Where(a => a.Name == "Acceptable Losses").SingleOrDefault();
            Achievement awayWithTheUseless 
                = achievements.Where(a => a.Name == "Away with the Useless").SingleOrDefault();
            Achievement justTheStart 
                = achievements.Where(a => a.Name == "Just the Start").SingleOrDefault();

            if (isFirstPurchase)
                if (firstOfMany.IsUnlocked == false)
                {
                    firstOfMany.IsUnlocked = true;
                    main.achievementsListView.Items[0].Group = Unlocked;
                    main.achievementsListView.Items[0].ToolTipText = firstOfMany.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "First of Many" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (OneOfEach())
                if (oneOfEach.IsUnlocked == false)
                {
                    oneOfEach.IsUnlocked = true;
                    main.achievementsListView.Items[1].Group = Unlocked;
                    main.achievementsListView.Items[1].ToolTipText = oneOfEach.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "One of Each" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (totalResources >= 100)
                if (theFirstHundred.IsUnlocked == false)
                {
                    theFirstHundred.IsUnlocked = true;
                    main.achievementsListView.Items[2].Group = Unlocked;
                    main.achievementsListView.Items[2].ToolTipText = theFirstHundred.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "The First Hundred" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (totalResources >= 1000)
                if (oneK.IsUnlocked == false)
                {
                    oneK.IsUnlocked = true;
                    main.achievementsListView.Items[3].Group = Unlocked;
                    main.achievementsListView.Items[3].ToolTipText = oneK.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "OneK" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (totalResources >= 1000000)
                if (milestoneMillion.IsUnlocked == false)
                {
                    milestoneMillion.IsUnlocked = true;
                    main.achievementsListView.Items[4].Group = Unlocked;
                    main.achievementsListView.Items[4].ToolTipText = milestoneMillion.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "Milestone Million" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (manualResources >= 1000)
                if (manualMaker.IsUnlocked == false)
                {
                    manualMaker.IsUnlocked = true;
                    main.achievementsListView.Items[5].Group = Unlocked;
                    main.achievementsListView.Items[5].ToolTipText = manualMaker.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "Manual Maker" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (autoResources >= 1000)
                if (autoMaker.IsUnlocked == false)
                {
                    autoMaker.IsUnlocked = true;
                    main.achievementsListView.Items[6].Group = Unlocked;
                    main.achievementsListView.Items[6].ToolTipText = autoMaker.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "Auto Maker" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (totalDeaths >= 100)
                if (acceptableLosses.IsUnlocked == false)
                {
                    acceptableLosses.IsUnlocked = true;
                    main.achievementsListView.Items[7].Group = Unlocked;
                    main.achievementsListView.Items[7].ToolTipText = acceptableLosses.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + "Acceptable Losses" 
                        + Environment.NewLine + Environment.NewLine;
                }

            if (workersSold >= 10)
                if (awayWithTheUseless.IsUnlocked == false)
                {
                    awayWithTheUseless.IsUnlocked = true;
                    main.achievementsListView.Items[8].Group = Unlocked;
                    main.achievementsListView.Items[8].ToolTipText = awayWithTheUseless.Description;
                    main.gameEventDisplay.Text += "Achievement Unlocked!" 
                        + Environment.NewLine + awayWithTheUseless.Name 
                        + Environment.NewLine + Environment.NewLine;
                }

            // Have we reached the end goal?
            if (totalResources >= 3000)
                if (goalReached == false)
                {
                    goalReached = true;
                    main.gameEventDisplay.Text = "Reached 3,000 resources!! @" + DateTime.Now.ToShortTimeString() + Environment.NewLine + Environment.NewLine;
                    MessageBox.Show("You reached the goal amount of 3000 total resources generated!",
                        "Resource Gathering Simulator", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    justTheStart.IsUnlocked = true;
                    main.achievementsListView.Items[9].Group = Unlocked;
                    main.achievementsListView.Items[9].ToolTipText = justTheStart.Description;
                }
        }

        /// <summary>
        /// Sets the upgrade costs for the workers
        /// </summary>
        private void SetUpgradeCosts()
        {
            woodcutter.SetUpgradeCosts(100, 70);
            miner.SetUpgradeCosts(100, 150, copper: 200, iron: 150);
            miner.SetCopperUpgradeCosts(80, 60, 30);
            miner.SetIronUpgradeCosts(200, 220, 250, 300);
            farmer.SetUpgradeCosts(70, 50);
            hunter.SetUpgradeCosts(100, 130, copper: 180);
            metalworker.SetUpgradeCosts(400, 250, copper: 300, iron: 350);
            self.SetUpgradeCosts(200, 230, copper: 280, iron: 300);
        }

        /// <summary>
        /// Creates the timers for the session
        /// </summary>
        private void CreateTimers()
        {
            // Create Update timer for stock workers
            Timer updateResources = new Timer();
            updateResources.Interval = 1000;
            updateResources.Start();
            updateResources.Tick += new EventHandler(CallEverySecond);

            // Create update timer for 0 rations
            Timer killTimer = new Timer();
            killTimer.Interval = 3000;
            killTimer.Start();
            killTimer.Tick += new EventHandler(KillWorkers);
        }

        /// <summary>
        /// This method is used to have things happen every second.
        /// If it needs to happen each second, put it here. 
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void CallEverySecond(object myObject, EventArgs myEventArgs)
        {
            main.totalResourcesNumberLabel.Text = totalResources.ToString();

            AddResources();

            // Determine if we can purchase the Iron Miner upgrade
            if (totalResources >= 1000)
                if (main.purchaseCopperMiner.Visible == false)
                    main.purchaseIronMiner.Show();

            ManageAchievements();
        }

        /// <summary>
        /// Add the resources to the stocks
        /// </summary>
        private void AddResources()
        {
            if (!stopWorkers)
            {
                #region Wood
                if (woodcutter.Number >= 1)
                {
                    if (stocks.Wood < stocks.StockCap)
                    {
                        stocks.Wood += woodcutter.Number * woodcutter.UpgradeLevel;
                        totalResources += woodcutter.Number * woodcutter.UpgradeLevel;
                        autoResources += woodcutter.Number * woodcutter.UpgradeLevel;
                        UpdateResource("wood");
                    }

                    if (stocks.Wood > stocks.StockCap)
                    {
                        stocks.Wood = stocks.StockCap;
                        UpdateResource("wood");
                    }
                }
                #endregion

                #region Stone/Copper/Iron
                if (miner.Number >= 1)
                {
                    if (stocks.Stone < stocks.StockCap)
                    {
                        stocks.Stone += miner.Number * miner.UpgradeLevel;
                        totalResources += miner.Number * miner.UpgradeLevel;
                        autoResources += miner.Number * miner.UpgradeLevel;
                        UpdateResource("stone");
                    }

                    if (stocks.Stone > stocks.StockCap)
                    {
                        stocks.Stone = stocks.StockCap;
                        UpdateResource("stone");
                    }

                    if (miner.IsCopper)
                    {
                        if (stocks.Copper < stocks.StockCap)
                        {
                            stocks.Copper += miner.Number * miner.UpgradeLevel;
                            totalResources += miner.Number * miner.UpgradeLevel;
                            autoResources += miner.Number * miner.UpgradeLevel;
                            UpdateResource("copper");
                        }

                        if (stocks.Copper > stocks.StockCap)
                        {
                            stocks.Copper = stocks.StockCap;
                            UpdateResource("copper");
                        }
                    }

                    if (miner.IsIron)
                    {
                        if (stocks.Iron < stocks.StockCap)
                        {
                            stocks.Iron += miner.Number * miner.UpgradeLevel;
                            totalResources += miner.Number * miner.UpgradeLevel;
                            autoResources += miner.Number * miner.UpgradeLevel;
                            UpdateResource("iron");
                        }

                        if (stocks.Iron > stocks.StockCap)
                        {
                            stocks.Iron = stocks.StockCap;
                            UpdateResource("iron");
                        }
                    }
                }
                #endregion

                #region Steel
                if (metalworker.Number >= 1)
                {
                    if (stocks.Iron > 0)
                        if (stocks.Steel < stocks.StockCap)
                        {
                            stocks.Steel += metalworker.Number * metalworker.UpgradeLevel;
                            stocks.Iron -= metalworker.Number;
                            totalResources += metalworker.Number * metalworker.UpgradeLevel;
                            autoResources += metalworker.Number * metalworker.UpgradeLevel;
                            UpdateResource("iron");
                            UpdateResource("steel");
                        }

                    if (stocks.Steel > stocks.StockCap)
                    {
                        stocks.Steel = stocks.StockCap;
                        UpdateResource("steel");
                    }
                }
                #endregion

                #region leather
                if (hunter.Number >= 1)
                {
                    if (stocks.Leather < stocks.StockCap)
                    {
                        stocks.Leather += hunter.Number * hunter.UpgradeLevel;
                        totalResources += hunter.Number * hunter.UpgradeLevel;
                        autoResources += hunter.Number * hunter.UpgradeLevel;
                        UpdateResource("leather");
                    }
                    if (stocks.Leather > stocks.StockCap)
                    {
                        stocks.Leather = stocks.StockCap;
                        UpdateResource("leather");
                    }
                }
                #endregion

                #region Rations
                // Add Rations
                if (farmer.Number >= 1)
                {
                    if (stocks.Rations < stocks.RationsCap)
                    {
                        stocks.Rations += farmer.Number * farmer.UpgradeLevel;
                        UpdateResource("rations");
                    }
                    if (stocks.Rations > stocks.RationsCap)
                    {
                        stocks.Rations = stocks.RationsCap;
                        UpdateResource("rations");
                    }
                }

                // Subtract Rations
                if (stocks.Rations < stocks.RationsCap)
                {
                    stocks.Rations -= (woodcutter.Number + miner.Number + farmer.Number + hunter.Number + metalworker.Number);
                    UpdateResource("rations");
                }
                #endregion
            }
        }

        /// <summary>
        /// Kills the workers when the rations are empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KillWorkers(object sender, EventArgs e)
        {
            if (stocks.Rations <= 0)
                if (!stopWorkers)
                {
                    Random rand = new Random();
                    int chosen = rand.Next(1, 9);

                    switch (chosen.ToString())
                    {
                        case "1":
                        case "6":
                            if (woodcutter.Number > 0)
                            {
                                woodcutter.Number--;
                                main.gameEventDisplay.Text += "Woodcutter has perished! @ "
                                    + DateTime.Now.ToShortTimeString() 
                                    + Environment.NewLine;
                                totalDeaths++;
                            }
                            break;
                        case "2":
                        case "7":
                            if (miner.Number > 0)
                            {
                                miner.Number--;
                                main.gameEventDisplay.Text += "Miner has perished! @ " 
                                    + DateTime.Now.ToShortTimeString()
                                    + Environment.NewLine;
                                totalDeaths++;
                            }
                            break;
                        case "3":
                        case "8":
                            if (farmer.Number > 0)
                            {
                                farmer.Number--;
                                main.gameEventDisplay.Text += "Farmer has perished! @ " 
                                    + DateTime.Now.ToShortTimeString() 
                                    + Environment.NewLine;
                                totalDeaths++;
                            }
                            break;
                        case "4":
                        case "9":
                            if (hunter.Number > 0)
                            {
                                hunter.Number--;
                                main.gameEventDisplay.Text += "Hunter has perished! @ " 
                                    + DateTime.Now.ToShortTimeString() 
                                    + Environment.NewLine;
                                totalDeaths++;
                            }
                            break;
                        case "5":
                        case "10":
                            if (metalworker.Number > 0)
                            {
                                metalworker.Number--;
                                main.gameEventDisplay.Text += "Metalworker has Perished! @ " 
                                    + DateTime.Now.ToShortTimeString() 
                                    + Environment.NewLine;
                                totalDeaths++;
                            }
                            break;

                    }

                    textHelper.UpdateWorkersNumberText();
                }
        }
    }
}
