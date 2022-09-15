using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip wordEffect;

    public static SoundManager Instance;
     
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void playWordEffect()
    {
        audioSource.PlayOneShot(wordEffect);
    }
}


