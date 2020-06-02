using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WorkshopCustomDataStructures
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
            this.count = 0;
        }

        public int Count =>  this.count;

        public void Push(T element)
        {
            this.Resize();
            this.items[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            ThrowWhenEmpty();
            var elementToReturn = this.items[this.count - 1];
            this.count--;
            return elementToReturn;
        }

        public T Peek()
        {
            ThrowWhenEmpty();
            return this.items[this.count-1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.count-1; i >=0; i--)
            {
                action(this.items[i]);
            }
        }

        private void ThrowWhenEmpty()
        {
            if (this.count==0)
            {
                throw new Exception("Stack is empty");
            }
        }
        private void Resize()
        {
            if (this.items.Length > this.count)
            {
                return;
            }
            var resizedArray = new T[2 * this.items.Length];
            Array.Copy(this.items, 0, resizedArray, 0, this.items.Length);
            this.items = resizedArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count-1; i>=0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
