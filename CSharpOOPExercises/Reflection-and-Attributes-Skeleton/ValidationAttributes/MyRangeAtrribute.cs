namespace ValidationAttributes
{
    using System;

    public class MyRangeAtrribute : MyValidationAttribute
    {
        private int minAge;
        private int maxAge;

        public MyRangeAtrribute(int minAge, int maxAge)
        {
            this.minAge = minAge;
            this.maxAge = maxAge;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int valueAsInt)
            {
                if (valueAsInt>=minAge && valueAsInt<=maxAge)
                {
                    return true;
                }

                return false;
            }

            throw new ArgumentOutOfRangeException($"Age must be between {this.minAge} and {this.maxAge}");
        }
    }
}
