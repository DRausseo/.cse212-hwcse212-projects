using System;
using System.Collections.Generic;

public class TranslatorSolution
{
    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'
    /// For example, in a English to German dictionary:
    /// my_translator.AddWord("book", "buch")
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the from word into the word that this stores as the translation
    /// </summary>
    public string Translate(string fromWord)
    {
        return _words.TryGetValue(fromWord, out var result) ? result : "???";
    }

    public static void Run()
    {
        var englishToGerman = new TranslatorSolution();

        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));      // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));    // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Boat"));     // ???
    }
}
