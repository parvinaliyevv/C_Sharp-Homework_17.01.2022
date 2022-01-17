using System;

namespace homework
{
    public static class Hash
    {
        private static short _hashNum;

        static Hash() => _hashNum = Convert.ToInt16(MyRandom.RandomInteger(1, short.MaxValue));

        public static string HashString(string data)
        {
            if (data is null) throw new ArgumentNullException(nameof(data));

            string newData = "";

            for (int i = 0; i < data.Length; i++)
            {
                newData += Convert.ToChar(data[i] + _hashNum);
            }

            return newData;
        }
    }
}
