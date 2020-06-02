namespace ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(Exceptions.LengthNegativeException);
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Exceptions.WidthNegativeException);
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Exceptions.HeightNegativeException);
                }

                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            double result = 2 * this.Length * this.Width + this.GetLateralSurfaceArea();

            return result;
        }

        public double GetLateralSurfaceArea()
        {
            double result = 2 * this.Length * this.Height + 2*this.Width * this.Height;

            return result;
        }

        public double GetVolume()
        {
            double result = this.Length * this.Width * this.Height;

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.GetVolume():F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
