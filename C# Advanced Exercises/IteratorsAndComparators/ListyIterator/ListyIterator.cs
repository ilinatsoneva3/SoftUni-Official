namespace ListyIterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index;

        public ListyIterator(List<T> input)
        {
            this.data = input;
            this.index = 0;
        }

        public bool Move()
        {
            bool hasNext = this.HasNext();

            if (hasNext)
            {
                this.index++;
            }

            return hasNext;
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.data.Count)
            {
                return true;
            }

            return false;
        }

        public T Print()
        {
            if (this.data.Any())
            {
                return this.data[index];
            }
            else
            {
                throw new InvalidOperationException("Invalid operation!");
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
