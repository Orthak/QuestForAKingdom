using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Quest_for_a_Kingdom.Helpers;

namespace Quest_for_a_Kingdom
{
    public partial class MainForm : Form
    {
        MainHelper mainHelper;

        // Used for storing the saved and loaded data
        private List<Achievement> saveAchievementsList = new List<Achievement>();
        private List<Worker> saveWorkersList = new List<Worker>();
        private List<Building> saveBuildingList = new List<Building>();
        private List<KeyValuePair<int, string>> saveShopButtonsList = new List<KeyValuePair<int, string>>();

        public MainForm()
        {
            InitializeComponent();
            mainHelper = new MainHelper(this);
            mainHelper.SetStartingValues();
        }

        // Set mouse focus on the object 
        // on mouse enter
        private void upgradesTabPage_MouseEnter(object sender, EventArgs e)
        {
            upgradesTabPage.Focus();
        }

        private void buildingsTabPage_MouseEnter(object sender, EventArgs e)
        {
            buildingsTabPage.Focus();
        }

        private void workersTabPage_MouseEnter(object sender, EventArgs e)
        {
            workersTabPage.Focus();
        }

        private void gameEventDisplay_MouseEnter(object sender, EventArgs e)
        {
            gameEventDisplay.Focus();
        }

        /// <summary>
        /// Stop or start the workers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseWorkers_Click(object sender, EventArgs e)
        {
            if (!mainHelper.stopWorkers)
            {
                mainHelper.stopWorkers = true;
                pauseWorkers.Text = "Start Workers";
                gameEventDisplay.Text += "Workers paused!" + Environment.NewLine;
            }
            else if (mainHelper.stopWorkers)
            {
                mainHelper.stopWorkers = false;
                pauseWorkers.Text = "Pause Workers";
                gameEventDisplay.Text += "Workers started!" + Environment.NewLine;
            }
        }

        #region Generate Resources Buttons
        private void generateWood_Click(object sender, EventArgs e)
        {
            if (mainHelper.stocks.Wood < mainHelper.stocks.StockCap)
            {
                mainHelper.GenerateResource("wood");
            }
        }
        private void generateStone_Click(object sender, EventArgs e)
        {
            if (mainHelper.stocks.Stone < mainHelper.stocks.StockCap)
            {
                mainHelper.GenerateResource("stone");
            }
        }
        private void generateCopper_Click(object sender, EventArgs e)
        {
            if (mainHelper.stocks.Copper < mainHelper.stocks.StockCap)
            {
                mainHelper.GenerateResource("copper");
            }
        }
        private void generateIron_Click(object sender, EventArgs e)
        {
            if (mainHelper.stocks.Iron < mainHelper.stocks.StockCap)
            {
                mainHelper.GenerateResource("iron");
            }
        }
        #endregion Generate Resources Buttons

        #region Shop Buttons
        // Purchase Workers
        private void purchaseWoodcutter_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseWoodcutters(mainHelper.woodcutter, purchaseWoodcutter, woodcuttersNumberLabel);
        }
        private void purchaseMiner_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseMiners(mainHelper.miner, purchaseMiner, minersNumberLabel);
        }
        private void purchaseFarmer_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseFarmers(mainHelper.farmer, purchaseFarmers, farmersNumberLabel);
        }
        private void purchaseHunter_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseHunters(mainHelper.hunter, purchaseHunters, huntersNumberLabel);
        }
        private void purchaseMetalWorker_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseMetalWorkers(mainHelper.metalworker, purchaseMetalWorkers, metalworkersNumberLabel);
        }

        // Purchase Upgrades
        private void purchaseWoodcutterUpgrade_Click(object sender, EventArgs e)
        {
            mainHelper.shop.WoodcutterUpgrade(mainHelper.woodcutter, purchaseWoodcutterUpgrade, woodcuttersLabel);
        }
        private void purchaseMinerUpgrade_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseMinerUpgrade(mainHelper.miner, purchaseMinerUpgrade, minersLabel);
        }
        private void purchaseCopperMiner_Click(object sender, EventArgs e)
        {
            mainHelper.shop.CopperMinerUpgrade(mainHelper.miner, purchaseCopperMiner, minersLabel);
        }
        private void purchaseIronMiner_Click(object sender, EventArgs e)
        {
            mainHelper.shop.IronMinerUpgrade(mainHelper.miner, purchaseIronMiner, minersLabel);
        }
        private void purchaseFarmersUpgrade_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseFarmersUpgrade(mainHelper.farmer, purchaseFarmersUpgrade, farmersLabel);
        }
        private void purchaseHuntersUpgrade_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseHuntersUpgrade(mainHelper.hunter, purchaseHuntersUpgrade, huntersLabel);
        }
        private void purchaseMetalWorkerUpgrade_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseMetalWorkersUpgrade(mainHelper.metalworker, purchaseMetalWorkersUpgrade, metalWorkerLabel);
        }
        private void purchaseStockUpgrade_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseStocksUpgrade(purchaseStockUpgrade, stockpileUpgradeLabel, rationsCapLabel);
        }
        private void purchaseSelfUpgrade_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseSelfUpgrade(mainHelper.self, purchaseSelfUpgrade);
        }

        // Sell Workers
        private void sellWoodcutters_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellWoodcutters(mainHelper.woodcutter, purchaseWoodcutter, woodcuttersNumberLabel);
        }
        private void sellMiners_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellMiners(mainHelper.miner, purchaseMiner, minersNumberLabel);
        }
        private void sellFarmers_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellFarmers(mainHelper.farmer, purchaseFarmers, farmersNumberLabel);
        }
        private void sellHunters_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellHunters(mainHelper.hunter, purchaseHunters, huntersNumberLabel);
        }
        private void sellMetalWorker_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellMetalworkers(mainHelper.metalworker, sellMetalWorker, metalworkersNumberLabel);
        }

        // Purchase Buildings
        private void purchaseTentsButton_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseTents(mainHelper.tent, purchaseTentsButton, tentsNumberLabel);
        }
        private void purchaseHutsButton_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseHuts(mainHelper.hut, purchaseHutsButton, hutsNumberLabel);
        }
        private void purchaseCabinsButton_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseCabins(mainHelper.cabin, purchaseCabinsButton, cabinsNumberLabel);
        }
        private void purchaseBarracksButton_Click(object sender, EventArgs e)
        {
            mainHelper.shop.PurchaseBarracks(mainHelper.barracks, purchaseBarracksButton, barracksNumberLabel);
        }

        // Sell Buildings
        private void tentsNumberLabel_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellTents(mainHelper.tent, purchaseTentsButton, tentsNumberLabel);
        }
        private void hutsNumberLabel_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellHuts(mainHelper.hut, purchaseHutsButton, hutsNumberLabel);
        }
        private void cabinsNumberLabel_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellCabins(mainHelper.cabin, purchaseCabinsButton, cabinsNumberLabel);
        }
        private void barracksNumberLabel_Click(object sender, EventArgs e)
        {
            mainHelper.shop.SellBarracks(mainHelper.barracks, purchaseBarracksButton, barracksNumberLabel);
        }
        #endregion Shop Buttons

        #region Worker Allocation
        private void woodcutterPlus_Click(object sender, EventArgs e)
        {
            mainHelper.AddWoodcutter(mainHelper.woodcutter);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void woodcutterMinus_Click(object sender, EventArgs e)
        {
            mainHelper.SubtractWoodcutter(mainHelper.woodcutter);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void minerPlus_Click(object sender, EventArgs e)
        {
            mainHelper.AddMiner(mainHelper.miner);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void minerMinus_Click(object sender, EventArgs e)
        {
            mainHelper.SubtractMiner(mainHelper.miner);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void farmerPlus_Click(object sender, EventArgs e)
        {
            mainHelper.AddFarmer(mainHelper.farmer);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void farmerMinus_Click(object sender, EventArgs e)
        {
            mainHelper.SubtractFarmer(mainHelper.farmer);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void hunterPlus_Click(object sender, EventArgs e)
        {
            mainHelper.AddHunter(mainHelper.hunter);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void hunterMinus_Click(object sender, EventArgs e)
        {
            mainHelper.SubtractHunter(mainHelper.hunter);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void metalworkerPlus_Click(object sender, EventArgs e)
        {
            mainHelper.AddMetalworker(mainHelper.metalworker);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        private void metalworkerMinus_Click(object sender, EventArgs e)
        {
            mainHelper.SubtractMetalworker(mainHelper.metalworker);
            workersPoolNumberLabel.Text = mainHelper.workersPool.ToString();
        }
        #endregion
        
        #region Save and Load Data
        // Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainHelper.stopWorkers = true;
            saveFileDialog1.ShowDialog();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            PersistDataContainer container = new PersistDataContainer();
            PopulateLists();
            container.Stocks = mainHelper.stocks;
            container.AchievementsList = saveAchievementsList;
            container.WorkersList = saveWorkersList;
            container.BuildingsList = saveBuildingList;
            container.ShopButtons = saveShopButtonsList;
            container.TotalResources = mainHelper.totalResources;
            container.StopWorkers = mainHelper.stopWorkers;
            container.GoalReached = mainHelper.goalReached;
            container.GameEventDisplay = gameEventDisplay.Text;
            container.WorkerPool = mainHelper.workersPool;
            SaveAndLoadData.SaveData(saveFileDialog1, container);

            MessageBox.Show("Data Saved");
            mainHelper.stopWorkers = false;
        }
        private void PopulateLists()
        {
            // Achievements
            saveAchievementsList = new List<Achievement>();
            foreach (Achievement a in mainHelper.achievements)
                saveAchievementsList.Add(a);

            // Workers
            saveWorkersList.Add(mainHelper.worker);
            saveWorkersList.Add(mainHelper.woodcutter);
            saveWorkersList.Add(mainHelper.miner);
            saveWorkersList.Add(mainHelper.farmer);
            saveWorkersList.Add(mainHelper.hunter);
            saveWorkersList.Add(mainHelper.metalworker);
            saveWorkersList.Add(mainHelper.self);

            // Buildings
            saveBuildingList.Add(mainHelper.tent);
            saveBuildingList.Add(mainHelper.hut);
            saveBuildingList.Add(mainHelper.cabin);
            saveBuildingList.Add(mainHelper.barracks);

            // Shop Buttons
            saveShopButtonsList.Add(new KeyValuePair<int, string>(1, purchaseWoodcutter.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(2, purchaseMiner.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(3, purchaseFarmers.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(4, purchaseHunters.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(5, purchaseMetalWorkers.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(6, purchaseWoodcutterUpgrade.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(7, purchaseMinerUpgrade.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(8, purchaseCopperMiner.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(9, purchaseIronMiner.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(10, purchaseFarmersUpgrade.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(11, purchaseHuntersUpgrade.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(12, purchaseMetalWorkersUpgrade.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(13, purchaseStockUpgrade.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(14, purchaseSelfUpgrade.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(15, purchaseTentsButton.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(16, purchaseHutsButton.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(17, purchaseCabinsButton.Text));
            saveShopButtonsList.Add(new KeyValuePair<int, string>(18, purchaseBarracksButton.Text));
        }

        // Load
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainHelper.stopWorkers = true;
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog1.FileName;

            if (File.Exists(fileName))
            {
                PersistDataContainer container = SaveAndLoadData.LoadData(openFileDialog1, fileName);

                mainHelper.stocks = container.Stocks;
                saveAchievementsList = container.AchievementsList;
                saveWorkersList = container.WorkersList;
                saveBuildingList = container.BuildingsList;
                saveShopButtonsList = container.ShopButtons;
                mainHelper.totalResources = container.TotalResources;
                mainHelper.goalReached = container.GoalReached;
                mainHelper.stopWorkers = container.StopWorkers;
                gameEventDisplay.Text = container.GameEventDisplay;
                mainHelper.workersPool = container.WorkerPool;

                SetRestoredData();

                MessageBox.Show("Data Loaded");
                mainHelper.stopWorkers = false;
            }
        }
        private void SetRestoredData()
        {
            // Achievements
            mainHelper.achievements = new List<Achievement>();
            foreach (Achievement a in saveAchievementsList)
                mainHelper.achievements.Add(a);

            // Workers
            mainHelper.worker = saveWorkersList.Where(w => w.Name == "worker").SingleOrDefault();
            mainHelper.woodcutter = saveWorkersList.Where(w => w.Name == "woodcutter").SingleOrDefault();
            mainHelper.miner = saveWorkersList.Where(w => w.Name == "miner").SingleOrDefault();
            mainHelper.farmer = saveWorkersList.Where(w => w.Name == "farmer").SingleOrDefault();
            mainHelper.hunter = saveWorkersList.Where(w => w.Name == "hunter").SingleOrDefault();
            mainHelper.metalworker = saveWorkersList.Where(w => w.Name == "metalworker").SingleOrDefault();
            mainHelper.self = saveWorkersList.Where(w => w.Name == "self").SingleOrDefault();

            // Buildings
            mainHelper.tent = saveBuildingList.Where(b => b.Name == "tent").SingleOrDefault();
            mainHelper.hut = saveBuildingList.Where(b => b.Name == "hut").SingleOrDefault();
            mainHelper.cabin = saveBuildingList.Where(b => b.Name == "cabin").SingleOrDefault();
            mainHelper.barracks = saveBuildingList.Where(b => b.Name == "barracks").SingleOrDefault();

            // Shop Buttons
            purchaseWoodcutter.Text = saveShopButtonsList.First(kvp => kvp.Key == 1).Value;
            purchaseMiner.Text = saveShopButtonsList.First(kvp => kvp.Key == 2).Value;
            purchaseFarmers.Text = saveShopButtonsList.First(kvp => kvp.Key == 3).Value;
            purchaseHunters.Text = saveShopButtonsList.First(kvp => kvp.Key == 4).Value;
            purchaseMetalWorkers.Text = saveShopButtonsList.First(kvp => kvp.Key == 5).Value;
            purchaseWoodcutterUpgrade.Text = saveShopButtonsList.First(kvp => kvp.Key == 6).Value;
            purchaseMinerUpgrade.Text = saveShopButtonsList.First(kvp => kvp.Key == 7).Value;
            purchaseCopperMiner.Text = saveShopButtonsList.First(kvp => kvp.Key == 8).Value;
            purchaseIronMiner.Text = saveShopButtonsList.First(kvp => kvp.Key == 9).Value;
            purchaseFarmersUpgrade.Text = saveShopButtonsList.First(kvp => kvp.Key == 10).Value;
            purchaseHuntersUpgrade.Text = saveShopButtonsList.First(kvp => kvp.Key == 11).Value;
            purchaseMetalWorkersUpgrade.Text = saveShopButtonsList.First(kvp => kvp.Key == 12).Value;
            purchaseStockUpgrade.Text = saveShopButtonsList.First(kvp => kvp.Key == 13).Value;
            purchaseSelfUpgrade.Text = saveShopButtonsList.First(kvp => kvp.Key == 14).Value;
            purchaseTentsButton.Text = saveShopButtonsList.First(kvp => kvp.Key == 15).Value;
            purchaseHutsButton.Text = saveShopButtonsList.First(kvp => kvp.Key == 16).Value;
            purchaseCabinsButton.Text = saveShopButtonsList.First(kvp => kvp.Key == 17).Value;
            purchaseBarracksButton.Text = saveShopButtonsList.First(kvp => kvp.Key == 18).Value;

            mainHelper.textHelper.UpdateStockTexts();
            mainHelper.textHelper.UpdateWorkersNumberText();
            mainHelper.textHelper.UpdateWorkersCapText();
            mainHelper.textHelper.UpdateBuildingTexts();

            // Refresh the achievements list, with the re-added achievements
            mainHelper.UpdateAchievements();
        }
        #endregion Save and Load Data
    }
}