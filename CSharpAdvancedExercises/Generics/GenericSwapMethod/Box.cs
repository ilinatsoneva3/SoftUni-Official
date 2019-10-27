namespace GenericSwapMethod
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.List = new List<T>();
        }
        public List<T> List { get; set; }

        public void Swap(int a, int b)
        {
            if (!ValidateIndex(a, b))
            {
                throw new ArgumentOutOfRangeException();
            }

            T temp = this.List[a];
            this.List[a] = this.List[b];
            this.List[b] = temp;
        }

        public int FindCountOfGreaterItems(T compararer)
        {
            int count = 0;

            foreach (var item in this.List)
            {
                if (item.CompareTo(compararer) == 1)
                {
                    count++;
                }
            }

            return count;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.List)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private bool ValidateIndex(int a, int b)
        {
            if (a >= 0 && a < this.List.Count
                && b >= 0 && b < this.List.Count)
            {
                return true;
            }

            return false;
        }
    }
}
