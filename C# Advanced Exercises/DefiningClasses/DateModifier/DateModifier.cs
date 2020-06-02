namespace DateModifier
{
    using System;
    using System.Globalization;

    public class DateModifier
    {
        public int CalculateDate(string dateOne, string dateTwo)
        {
            DateTime firstDate = DateTime.ParseExact(dateOne, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);
            var difference = Math.Abs((firstDate - secondDate).Days);
            return difference;
        }
    }
}
