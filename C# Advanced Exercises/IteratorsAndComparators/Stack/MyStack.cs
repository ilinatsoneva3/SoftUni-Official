namespace Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> data;

        public MyStack()
        {
            this.data = new List<T>();
        }

        public MyStack(List<T> input)
        {
            this.data = input;
        }

        public void Push(T element)
        {
            this.data.Add(element);
        }

        public void Pop()
        {
            if (this.data.Count != 0)
            {
                var item = this.data[this.data.Count - 1];
                this.data.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
