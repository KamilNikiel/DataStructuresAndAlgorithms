using System.Text;
using System.Text.RegularExpressions;

namespace DataStructuresAndAlgorithms.StringManipulation
{
    internal static class StringUtils
    {
        public static int CountVowels(string str)
        {
            if (str == null)
                return 0;

            var count = 0;
            var vowels = "aeiou";
            foreach (var ch in str.ToLower())
                if (vowels.IndexOf(ch) != -1)
                    count++;

            return count;
        }

        public static string Reverse(string str)
        {
            if (str == null)
                return "";

            var reversed = new StringBuilder();
            for (var i = str.Length - 1; 0 <= i; i--)
                reversed.Append(str[i]);

            return reversed.ToString();
        }

        public static string ReverseWords(string sentence)
        {
            if (sentence == null)
                return "";

            var words = sentence.Split(' ');

            //var reversed = String.Join(' ', words.Reverse());
            //return reversed;

            var reversed = new StringBuilder();
            for (var i = words.Length - 1; i >= 0; i--)
            {
                reversed.Append(words[i] + ' ');
            }

            return reversed.ToString().Trim();
        }

        public static bool AreRotations(string str1, string str2)
        {
            return (str1.Length == str2.Length && (str1 + str1).Contains(str2));
        }

        public static string RemoveDuplicates(string str)
        {
            if (str == null)
                return "";

            var output = new StringBuilder();
            var set = new HashSet<char>();
            for (var i = 0; i < str.Length; i++)
            {
                if (!set.Contains(str[i]))
                {
                    set.Add(str[i]);
                    output.Append(str[i].ToString());
                }
            }

            return output.ToString();
        }

        public static char MostRepeatedCharDictionary(string str)
        {
            if (str == null || str == "")
                throw new ArgumentException(str);

            var dictionary = new Dictionary<char, int>();

            for (var i = 0; i < str.Length; i++)
            {
                if (dictionary.ContainsKey(str[i]))
                    dictionary[str[i]]++;
                else
                    dictionary.Add(str[i], 1);
            }

            return dictionary.First(v => v.Value == dictionary.Values.Max()).Key;
        }

        public static char MostRepeatedChar(string str)
        {
            if (str == null || str == "")
                throw new ArgumentException(str);

            const int ASCII_SIZE = 256;
            var frequencies = new int[ASCII_SIZE];

            foreach (var ch in str)
                frequencies[ch]++;

            var max = 0;
            var result = ' ';
            for (var i = 0; i < frequencies.Length; i++)
                if (frequencies[i] > max)
                {
                    max = frequencies[i];
                    result = (char)i;
                }

            return result;
        }

        public static string Capitalize(string sentence)
        {
            if (sentence == null || sentence.Trim() == "")
                return "";

            var words = Regex.Replace(sentence, @"\s+", " ").Trim().Split(' ');

            for (var i = words.Length - 1; i >= 0; i--)
                words[i] = words[i].Substring(0, 1).ToUpper()
                         + words[i].Substring(1).ToLower();
            return String.Join(' ', words);
        }

        public static bool AreAnagrams(string str1, string str2)
        {
            if (str1 == null || str2 == null ||
                str1.Length != str2.Length)
                return false;
            var array1 = str1.ToLower().ToArray();
            var array2 = str2.ToLower().ToArray();

            Array.Sort(array1);
            Array.Sort(array2);

            return new String(array1) == new String(array2);
        }

        public static bool AreAnagramsHistogramming(string str1, string str2)
        {
            if (str1 == null || str2 == null ||
               str1.Length != str2.Length)
                return false;

            const int ENGLISH_ALPHABET = 26;
            int[] frequencies = new int[ENGLISH_ALPHABET];

            str1 = str1.ToLower();
            for (var i = 0; i < str1.Length; i++)
                frequencies[str1[i] - 'a']++;

            for (var i = 0; i < str2.Length; i++)
            {
                var index = str2[i] - 'a';
                if (frequencies[index] == 0)
                    return false;

                frequencies[index]--;
            }

            return true;
        }

        public static bool IsPalindrome(string str)
        {
            if (str == null)
                throw new ArgumentNullException(str);
            //str.Reverse();

            str = str.ToLower();

            var left = 0;
            var right = str.Length - 1;
            while (left < right)
                if (str[left++] != str[right--])
                    return false;

            return true;
        }
    }
}
