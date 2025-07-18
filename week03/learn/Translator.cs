using System;
using System.Collections.Generic;

public class Translator
{
    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'fromWord' to 'toWord'.
    /// For example, in an English to German dictionary:
    /// myTranslator.AddWord("book", "buch")
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the fromWord into the stored translation.
    /// Returns "???" if no translation is available.
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???"</returns>
    public string Translate(string fromWord)
    {
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }
        else
        {
            return "???";
        }
    }

    /// <summary>
    /// Sample run method for testing.
    /// </summary>
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));    // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // ???
    }
}
