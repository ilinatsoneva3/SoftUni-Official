namespace GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T data)
        {
            this.Data = data;
        }
        public T Data { get; set; }

        public override string ToString()
        {
            var result = this.Data.GetType() + ": " + this.Data;
            return result;
        }
    }
}
