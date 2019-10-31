using UnityEngine;
using TMPro;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    public TMP_Text wordVisual;

    public string MyWord { get; private set; }

    string _typedWord = "";
    Transform _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        MyWord = WordDatabase.FetchRandomWord();
        wordVisual.text = MyWord;
        _typedWord = MyWord;
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
        Debug.Log("here");
        _typedWord = _typedWord.Remove(0, 1);

        if (_typedWord.Length <= 0)
        {
            //AudioController.Instance.OnDestroySound();

            gameObject.SetActive(false);
        }
        else
        {
            wordVisual.text = string.Format("<color=red>{0}</color>{1}", _typedWord[0], _typedWord.Length > 1 ? _typedWord.Remove(0, 1) : "");
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
