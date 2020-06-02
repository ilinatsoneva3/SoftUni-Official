using System;
using System.Collections.Generic;
using System.Text;

namespace RhombusOfStars
{
    public class Rhombus
    {
        private StringBuilder finalFigure;

        public Rhombus()
        {
            this.finalFigure = new StringBuilder();
        }

        private void DrawUpPart(int n)
        {
            for (int i = 0; i < n; i++)
            {
                this.finalFigure.Append(new string(' ', n - i));

                for (int j = 0; j <= i; j++)
                {
                    this.finalFigure.Append("* ");
                }
                this.finalFigure.AppendLine();
            }
        }

        private void DrawBottomPart(int n)
        {
            for (int i = n - 2; i >= 0; i--)
            {
                this.finalFigure.Append(new string(' ', n - i));

                for (int j = 0; j <= i; j++)
                {
                    this.finalFigure.Append("* ");
                }
                this.finalFigure.AppendLine();
            }
        }

        public string DrawRhombus(int n)
        {
            this.DrawUpPart(n);
            this.DrawBottomPart(n);
            return this.finalFigure.ToString();
        }
    }
}
