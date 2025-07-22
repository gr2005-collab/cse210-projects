using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ')
            .Select(word => new Word(word))
            .ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);
        Console.WriteLine();

        foreach (var word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count)
    {
        var unhidden = _words.Where(w => !w.IsHidden).ToList();

        var rand = new Random();
        int wordsToHide = Math.Min(count, unhidden.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rand.Next(unhidden.Count);
            unhidden[index].Hide();
            unhidden.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}
