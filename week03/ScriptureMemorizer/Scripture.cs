using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference scriptureReference, string text)
    {
        _reference = scriptureReference;

        string[] wordTexts = text.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        Random random = new Random();

        while (numberToHide > 0 && visibleIndexes.Count > 0)
        {
            int randomPosition = random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[randomPosition];

            _words[wordIndex].Hide();
            visibleIndexes.RemoveAt(randomPosition);
            numberToHide--;
        }
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (Word word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public string GetRandomHiddenWordClue()
{
    List<int> hiddenWordIndexes = new List<int>();

    for (int i = 0; i < _words.Count; i++)
    {
        if (_words[i].IsHidden())
        {
            hiddenWordIndexes.Add(i);
        }
    }

    if (hiddenWordIndexes.Count == 0)
    {
        return "There are no hidden words to give a clue for.";
    }

    Random random = new Random();
    int randomPosition = random.Next(hiddenWordIndexes.Count);
    int wordIndex = hiddenWordIndexes[randomPosition];

    return $"Clue: word #{wordIndex + 1} starts with " +
           $"'{_words[wordIndex].GetFirstLetter()}'.";
}
    public void ShowAllWords()
{
    foreach (Word word in _words)
    {
        word.Show();
    }
}
}