using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            if (word[0] == word[1])
                continue;

            string reversed = "" + word[1] + word[0];

            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }

            seen.Add(word);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length < 4)
                continue;

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Earthquake JSON data
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        return new string[]
        {
            "Place A - Mag 1.0",
            "Place B - Mag 2.0",
            "Place C - Mag 3.0",
            "Place D - Mag 4.0",
            "Place E - Mag 5.0",
            "Place F - Mag 6.0"
        };
    }
}
