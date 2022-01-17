namespace homework
{
    public static class MyRandom
    {
        public static System.Random RandomProp { get; set; } = new System.Random();

        public static int RandomInteger(int min = 1, int max = 1000000) => RandomProp.Next(min, max);

        public static double RandomDouble() => RandomProp.NextDouble();

        public static string RandomString(int length)
        {
            var data = new System.Text.StringBuilder();

            for (int i = 0; i < length; i++)
            {
                data.Append(RandomProp.Next() % 10);
            }

            return data.ToString();
        }
    }
}