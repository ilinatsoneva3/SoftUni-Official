namespace BoxOfT
{
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T>
    {
        private Stack<T> list;
        private int count;

        public Box()
        {
            this.list = new Stack<T>();
        }
        public int Count => this.list.Count();
        public void Add(T item)
        {
            list.Push(item);
        }

        public T Remove()
        {
            return list.Pop();
        }
    }
}
