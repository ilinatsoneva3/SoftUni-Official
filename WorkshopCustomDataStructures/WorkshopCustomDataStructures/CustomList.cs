using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopCustomDataStructures
{
    public class CustomList<T>
    {
        private T[] items;
        private const int InitialCapacity = 2;
        public CustomList()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public void Add(T element)
        {
            this.Resize();
            this.items[this.Count] = element;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var element = this.items[index];
            this.ShiftToLeft(index);
            this.Count--;
            this.Shrink();
            return element;
        }

        public void InsertAt(int index, T element)
        {
            this.ValidateIndex(index);
            this.Count++;
            this.Resize();
            this.ShiftToRight(index);
            this.items[index] = element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap (int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);
            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public void Reverse()
        {
            for (int i = 0; i < this.Count/2; i++)
            {
                Swap(i, this.Count - i - 1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Count-1; i++)
            {
                sb.Append(this.items[i]+", ");
            }
            return sb.ToString().TrimEnd(' ', ',');
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void Resize()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }
            var resizedArray = new T[2 * this.items.Length];
            Array.Copy(this.items, 0, resizedArray, 0, this.items.Length);
            this.items = resizedArray;
        }

        private void Shrink()
        {
            if (this.Count * 4 >= this.items.Length)
            {
                return;
            }

            var resizedArray = new T[this.items.Length / 2];
            Array.Copy(this.items, resizedArray, this.items.Length);
            this.items = resizedArray;

        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
        }

        private void ShiftToRight(int index)
        {
            for (int i = this.Count - 1; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
