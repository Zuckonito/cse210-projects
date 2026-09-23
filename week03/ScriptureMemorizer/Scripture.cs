using System;

public class Scripture
{
    private Reference _reference;
    private Word[] _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] splitWords = text.Split(' ');
        _words = new Word[splitWords.Length];

        for (int i = 0; i < splitWords.Length; i++)
        {
            _words[i] = new Word(splitWords[i]);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int visibleCount = 0;
        for (int i = 0; i < _words.Length; i++)
        {
            if (_words[i].IsHidden() == false)
            {
                visibleCount++;
            }
        }

        if (visibleCount == 0)
        {
            return;
        }

        Word[] visibleWords = new Word[visibleCount];
        int indexCounter = 0;
        for (int i = 0; i < _words.Length; i++)
        {
            if (_words[i].IsHidden() == false)
            {
                visibleWords[indexCounter] = _words[i];
                indexCounter++;
            }
        }

        Random random = new Random();
        int hiddenSoFar = 0;

        while (hiddenSoFar < numberToHide && visibleCount > 0)
        {
            int randomIndex = random.Next(0, visibleCount);
            
            visibleWords[randomIndex].Hide();

            for (int i = randomIndex; i < visibleCount - 1; i++)
            {
                visibleWords[i] = visibleWords[i + 1];
            }

            visibleCount--;
            hiddenSoFar++;
        }
    }

    public string GetDisplayText()
    {
        string textToDisplay = _reference.GetDisplayText() + " - ";

        for (int i = 0; i < _words.Length; i++)
        {
            textToDisplay += _words[i].GetDisplayText() + " ";
        }

        return textToDisplay.TrimEnd();
    }

    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            if (_words[i].IsHidden() == false)
            {
                return false;
            }
        }

        return true;
    }
}