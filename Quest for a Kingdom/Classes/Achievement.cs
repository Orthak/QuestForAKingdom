using System;
using System.Collections.Generic;

namespace Quest_for_a_Kingdom
{
    [Serializable]
    public class Achievement
    {
        public string Name          { get; set; }
        public bool IsUnlocked      { get; set; }
        public string ToUnlock      { get; set; }
        public string Description   { get; set; }
        public float Bonus          { get; set; }

        public List<Achievement> CreateAchievements()
        {
            List<Achievement> a = new List<Achievement>
            {
                new Achievement
                {
                    Name = "First of Many",
                    IsUnlocked = false,
                    ToUnlock = "Make the first purchase",
                    Description = "The longest games begin with the first purchase."
                },
                new Achievement
                {
                    Name = "One of Each",
                    IsUnlocked = false,
                    ToUnlock = "Have at least one of each worker and building",
                    Description = "Have to have all the bases covered."
                },
                new Achievement
                {
                    Name = "The First Hundred",
                    IsUnlocked = false,
                    ToUnlock = "Made a total of 100 resources",
                    Description = "A good start."
                },
                new Achievement
                {
                    Name = "OneK",
                    IsUnlocked = false,
                    ToUnlock = "Made a total of 1,000 resources",
                    Description = "The real work has only begun."
                },
                new Achievement
                {
                    Name = "Milestone Million",
                    IsUnlocked = false,
                    ToUnlock = "Made a total of 1,000,000 resources",
                    Description = "I must develop more!"
                },
                new Achievement
                {
                    Name = "Manual Maker",
                    IsUnlocked = false,
                    ToUnlock = "Click the resource buttons a total of 1,000 times.",
                    Description = "If you want something done right..."
                },
                new Achievement
                {
                    Name = "Auto Maker",
                    IsUnlocked = false,
                    ToUnlock = "Have your workers create a total of 1,000 resources.",
                    Description = "Eh...I'll let them deal with it."
                },
                new Achievement
                {
                    Name = "Acceptable Losses",
                    IsUnlocked = false,
                    ToUnlock = "Have over 100 workers die",
                    Description = "I can always hire more expendables."
                },
                //new Achievement
                //{
                //    Name = "Master of Fate",
                //    IsUnlocked = false,
                //    ToUnlock = "Re allocate workers 100 times.",
                //    Description = "You work where I tell you, when I tell you."
                //},
                new Achievement
                {
                    Name = "Away with the Useless",
                    IsUnlocked = false,
                    ToUnlock = "Sell workers over 100 times.",
                    Description = "I no longer find you of use."
                },
                new Achievement
                {
                    Name = "Just the Start",
                    IsUnlocked = false,
                    ToUnlock = "Reach the resource total goal of 3,000.",
                    Description = "There is more to see than what is just in front of you."
                },
            };

            return a;
        }
    }
}
