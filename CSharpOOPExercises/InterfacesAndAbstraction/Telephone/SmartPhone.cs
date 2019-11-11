using System;

namespace Telephone
{
    public class SmartPhone : ICallable, IBrowsable
    {
        public string Browse(string URL)
        {
            var isLettersOnly = this.CheckForNumbersInURL(URL);

            if (isLettersOnly)
            {
                return $"Browsing: {URL}!";
            }
            else
            {
                return "Invalid URL!";
            }

        }
               
        public string Call(string number)
        {
            var isNumbersOnly = this.CheckForLettersInNumber(number);

            if (isNumbersOnly)
            {
                return $"Calling... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }

        private bool CheckForLettersInNumber(string number)
        {
            foreach (var symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckForNumbersInURL(string URL)
        {
            foreach (var letter in URL)
            {
                if (char.IsDigit(letter))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
