using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class WordDatabase
{
    static public List<string> Words { get; private set; } = new List<string>();
    static public void LoadWords()
    {
        string fileLocation = string.Format("{0}/RandomWords.txt", UnityEngine.Application.dataPath);
        const Int32 BufferSize = 128;
        using (var fileStream = File.OpenRead(fileLocation))
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
        {
            String line;
            while ((line = streamReader.ReadLine()) != null)
            {
                Words.Add(line.Trim());
            }
        }
    }

    static public string FetchRandomWord()
    {
        return Words[UnityEngine.Random.Range(0, Words.Count - 1)];
    }
}
