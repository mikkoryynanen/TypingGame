using UnityEngine;
using TMPro;
using System.Collections;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    public TMP_Text wordVisual;

    public string myWord = "";
    Transform _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        //yield return new WaitForSeconds(1); // TODO Remove this  waiting
        myWord = WordDatabase.FetchRandomWord();
        wordVisual.text = myWord;
    }

    void Update()
    {
        if (_target)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, Time.deltaTime * 0.5f);
        }
    }

    public void WriteText(string pressedLetter)
    {
        myWord = myWord.Substring(1);
        wordVisual.text = myWord;

        if (myWord.Length <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag(collision.gameObject.tag ="Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
