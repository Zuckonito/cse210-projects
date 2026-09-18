using System;

/*

I added a smart word selection feature to the 'HideRandomWords' method. It only selects from words that 
   are no already hidden using basic array loops. This avoids hiding the same word twice.
And I also added a scripture library feature in Program.cs using a simple fixed-size array 
of Scripture objects to randomly pick a scripture for the user.

*/

class Program
{
    static void Main(string[] args)
    {

        Scripture[] scriptureLibrary = new Scripture[3];
        scriptureLibrary[0] = new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        scriptureLibrary[1] = new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        scriptureLibrary[2] = new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me.");


        Random random = new Random();
        int randomIndex = random.Next(0, scriptureLibrary.Length);
        Scripture selectedScripture = scriptureLibrary[randomIndex];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            if (selectedScripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(3);
        }
    }
}

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return _book + " " + _chapter + ":" + _verse;
        }
        else
        {
            return _book + " " + _chapter + ":" + _verse + "-" + _endVerse;
        }
    }
}

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

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string underscores = "";
            for (int i = 0; i < _text.Length; i++)
            {
                underscores += "_";
            }
            return underscores;
        }
        else
        {
            return _text;
        }
    }
}