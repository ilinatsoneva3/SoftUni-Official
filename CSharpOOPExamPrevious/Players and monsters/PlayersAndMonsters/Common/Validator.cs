namespace PlayersAndMonsters.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfObjectIsNull(object obj, string message = null)
        {
            if (obj==null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfIsBelowZero(int value, string message = null)
        {
            if (value<0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
