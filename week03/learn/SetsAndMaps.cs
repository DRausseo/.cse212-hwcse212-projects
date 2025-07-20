using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new HashSet<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (word != reversed && wordSet.Contains(reversed))
            {
                var pair = string.Compare(word, reversed) < 0
                    ? $"{word} & {reversed}"
                    : $"{reversed} & {word}";
                result.Add(pair);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 3)
            {
                var degree = fields[3].Trim(); // <- Cambiado de [4] a [3]
                if (!string.IsNullOrWhiteSpace(degree))
                {
                    if (!degrees.ContainsKey(degree))
                        degrees[degree] = 1;
                    else
                        degrees[degree]++;
                }
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        // ✅ Paso 1: Limpiar los strings (sin espacios y en minúsculas)
        string Clean(string s) =>
            new string(s.ToLower().Where(c => !char.IsWhiteSpace(c)).ToArray());

        word1 = Clean(word1);
        word2 = Clean(word2);

        // ✅ Paso 2: Si no tienen la misma longitud, no son anagramas
        if (word1.Length != word2.Length)
            return false;

        // ✅ Paso 3: Contar letras usando diccionario
        var freq = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!freq.ContainsKey(c))
                return false;

            freq[c]--;

            if (freq[c] < 0)
                return false;
        }

        // ✅ Paso 4: Confirmar que todos los valores son cero
        return freq.Values.All(v => v == 0);
    }


    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = data.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();

        return result;
    }
}

