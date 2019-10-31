using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] keySounds;
    public AudioClip destroyClip;

    AudioSource _source;

    static public AudioController Instance = null;
    private void Awake()
    {
        if (Instance = null)
        {
            Instance = this;
        }

        _source = GetComponent<AudioSource>();
    }

    public void PlayKeySound()
    {
        _source.PlayOneShot(keySounds[Random.Range(0, keySounds.Length - 1)]);
    }

    public void OnDestroySound()
    {
        _source.PlayOneShot(destroyClip);
    }
}
