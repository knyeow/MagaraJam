using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip wordEffect;

    [SerializeField]
    private AudioClip fallEffect;

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

    public void playFallDownEffect()
    {
        audioSource.PlayOneShot(fallEffect);
    }
}


