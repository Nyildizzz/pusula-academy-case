using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public static class LongestVowelSubsequence
{
    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        if (words == null || words.Count == 0)
            return JsonSerializer.Serialize(new List<object>());

        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        var result = new List<object>();

        foreach (var word in words)
        {
            string longest = "";
            string current = "";

            foreach (var c in word)
            {
                if (vowels.Contains(c))
                {
                    current += c;
                    if (current.Length > longest.Length)
                        longest = current;
                }
                else
                {
                    current = "";
                }
            }

            result.Add(new
            {
                word,
                sequence = longest,
                length = longest.Length
            });
        }

        return JsonSerializer.Serialize(result);
    }
}
