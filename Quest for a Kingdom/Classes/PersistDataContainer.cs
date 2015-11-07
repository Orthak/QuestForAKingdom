using System;
using System.Collections.Generic;

namespace Quest_for_a_Kingdom
{
    /// <summary>
    /// This class is used to store all of the information that is to be saved out to a file
    /// </summary>
    [Serializable]
    class PersistDataContainer
    {
        public Stocks Stocks { get; set; }
        public List<Achievement> AchievementsList { get; set; }
        public List<Worker> WorkersList { get; set; }
        public List<Building> BuildingsList { get; set; }
        public List<KeyValuePair<int, string>> ShopButtons { get; set; }
        public string GameEventDisplay { get; set; }
        public float TotalResources { get; set; }
        public bool StopWorkers { get; set; }
        public bool GoalReached { get; set; }
        public int WorkerPool { get; set; }
    }
}
