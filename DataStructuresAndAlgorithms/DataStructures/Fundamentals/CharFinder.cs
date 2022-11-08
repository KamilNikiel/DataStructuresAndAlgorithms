namespace DataStructuresAndAlgorithms.DataStructures.Fundamentals
{
    internal class CharFinder
    {
        public char FindFirstNonRepeatingChar(string str)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                    dict[str[i]]++;
                else
                    dict[str[i]] = 1;
            }

            for (int i = 0; i < str.Length; i++)
                if (dict[str[i]] == 1)
                    return str[i];

            return char.MinValue;
        }
        public char FindFirstRepeatingChar(string str)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                    return str[i];

                dict.Add(str[i], 1);
            }
            return char.MinValue;
        }
    }
}
