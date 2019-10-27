using UnityEngine;
using TMPro;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public TMP_Text writtenText;

    public string myText = "";
    string written = "";

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1); // TODO Remove this  waiting
        myText = TypeManager.wordToType;        
    }

    public void WriteText(string typedWord)
    {
        // TODO don't set this ever time
        written = typedWord;

        if (written.Length >= myText.Length)
        {
            gameObject.SetActive(false);
        }
        else
        {
            writtenText.text = written;
        }
    }
}
