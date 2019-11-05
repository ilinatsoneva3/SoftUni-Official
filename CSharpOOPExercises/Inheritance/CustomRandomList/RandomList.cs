namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            this.rnd = new Random();
        }

        public string RandomString()
        {
            int rndIndexToRemove = this.rnd.Next(0, this.Count);
            string result = this[rndIndexToRemove];
            this.RemoveAt(rndIndexToRemove);
            return result;
        }
    }
}
