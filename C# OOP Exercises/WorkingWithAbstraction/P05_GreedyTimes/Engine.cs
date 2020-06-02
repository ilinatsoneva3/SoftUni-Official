namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<string, Dictionary<string, long>> bag;
        private long gold;
        private long gems;
        private long cash;

        public Engine()
        {
            this.bag = new Dictionary<string, Dictionary<string, long>>();
            this.gold = 0;
            this.gems = 0;
            this.cash = 0;
        }

        public void Run()
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < input.Length; i += 2)
            {
                string name = input[i];
                long amount = long.Parse(input[i + 1]);

                string typeOfItem = this.CheckTypeOfItem(name);

                bool isValidTypeOFItem = this.CheckValidTypeOfItem(typeOfItem, amount, capacity);

                if (isValidTypeOFItem)
                {
                    continue;
                }

                var hasKeptRules = ChangeAmount(typeOfItem, amount);

                if (hasKeptRules)
                {
                    continue;
                }

                CreateRecord(typeOfItem, name);

                this.bag[typeOfItem][name] += amount;

                IncreaseAmount(typeOfItem, amount);
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private bool CheckValidTypeOfItem(string typeOfItem, long amount, long capacity)
        {
            bool isValidTypeOfItem = false;

            if (typeOfItem == "")
            {
                isValidTypeOfItem = true;
            }
            else if (capacity < this.bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
            {
                isValidTypeOfItem = true;
            }

            return isValidTypeOfItem;
        }

        private void IncreaseAmount(string typeOfItem, long amount)
        {
            if (typeOfItem == "Gold")
            {
                this.gold += amount;
            }
            else if (typeOfItem == "Gem")
            {
                this.gems += amount;
            }
            else if (typeOfItem == "Cash")
            {
                this.cash += amount;
            }
        }

        private void CreateRecord(string typeOfItem, string name)
        {
            if (!this.bag.ContainsKey(typeOfItem))
            {
                this.bag[typeOfItem] = new Dictionary<string, long>();
            }

            if (!this.bag[typeOfItem].ContainsKey(name))
            {
                this.bag[typeOfItem][name] = 0;
            }

        }

        private bool ChangeAmount(string typeOfItem, long amount)
        {
            var shouldContinue = false;

            switch (typeOfItem)
            {
                case "Gem":
                    if (!this.bag.ContainsKey(typeOfItem))
                    {
                        if (this.bag.ContainsKey("Gold"))
                        {
                            if (amount > this.bag["Gold"].Values.Sum())
                            {
                                shouldContinue = true;
                            }
                        }
                        else
                        {
                            shouldContinue = true;
                        }
                    }
                    else if (this.bag[typeOfItem].Values.Sum() + amount > this.bag["Gold"].Values.Sum())
                    {
                        shouldContinue = true;
                    }
                    break;
                case "Cash":
                    if (!this.bag.ContainsKey(typeOfItem))
                    {
                        if (this.bag.ContainsKey("Gem"))
                        {
                            if (amount > this.bag["Gem"].Values.Sum())
                            {
                                shouldContinue = true;
                            }
                        }
                        else
                        {
                            shouldContinue = true;
                        }
                    }
                    else if (this.bag[typeOfItem].Values.Sum() + amount > this.bag["Gem"].Values.Sum())
                    {
                        shouldContinue = true;
                    }
                    break;
            }

            return shouldContinue;
        }

        private string CheckTypeOfItem(string name)
        {
            string typeOfItem = string.Empty;

            if (name.Length == 3)
            {
                typeOfItem = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                typeOfItem = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                typeOfItem = "Gold";
            }

            return typeOfItem;
        }
    }
}
