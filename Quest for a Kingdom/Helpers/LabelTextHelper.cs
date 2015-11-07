
namespace Quest_for_a_Kingdom.Helpers
{
    public class LabelTextHelper
    {
        private MainForm main;
        private MainHelper helper;

        public LabelTextHelper(MainForm _main, MainHelper _helper)
        {
            main = _main;
            helper = _helper;
        }

        /// <summary>
        /// Updates the workers cap text
        /// </summary>
        public void UpdateWorkersCapText()
        {
            main.workersCap0.Text = helper.worker.WorkersCap.ToString();
            main.workersCap1.Text = helper.worker.WorkersCap.ToString();
            main.workersCap2.Text = helper.worker.WorkersCap.ToString();
            main.workersCap3.Text = helper.worker.WorkersCap.ToString();
            main.workersCap4.Text = helper.worker.WorkersCap.ToString();
        }
        /// <summary>
        /// Update the number of the currently owned workers
        /// </summary>
        public void UpdateWorkersNumberText()
        {
            main.woodcuttersNumberLabel.Text = helper.woodcutter.Number.ToString();
            main.minersNumberLabel.Text = helper.miner.Number.ToString();
            main.farmersNumberLabel.Text = helper.farmer.Number.ToString();
            main.huntersNumberLabel.Text = helper.hunter.Number.ToString();
            main.metalworkersNumberLabel.Text = helper.metalworker.Number.ToString();
        }
        /// <summary>
        /// Update the number of the currently owned buildings
        /// </summary>
        public void UpdateBuildingTexts()
        {
            main.tentsNumberLabel.Text = helper.tent.NumberOf.ToString();
            main.hutsNumberLabel.Text = helper.hut.NumberOf.ToString();
            main.cabinsNumberLabel.Text = helper.cabin.NumberOf.ToString();
            main.barracksNumberLabel.Text = helper.barracks.NumberOf.ToString();
        }
        /// <summary>
        /// Update the amount of the current stocks
        /// </summary>
        public void UpdateStockTexts()
        {
            main.woodAmount.Text = helper.stocks.Wood.ToString();
            main.stoneAmount.Text = helper.stocks.Stone.ToString();
            main.leatherAmount.Text = helper.stocks.Leather.ToString();
            main.copperAmount.Text = helper.stocks.Copper.ToString();
            main.ironAmount.Text = helper.stocks.Iron.ToString();
            main.steelAmount.Text = helper.stocks.Steel.ToString();
            main.rationsAmount.Text = helper.stocks.Rations.ToString();
            UpdateWorkersNumberText();
        }
    }
}
