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

    [SerializeField]
    private AudioClip glassBreakEffect;

    [SerializeField]
    private AudioClip cardPickEffect;

    [SerializeField]
    private AudioClip doorOpenEffect;

    [SerializeField]
    private AudioClip laserShotEffect;

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

    public void playGlassBreak()
    {
        audioSource.PlayOneShot(glassBreakEffect);
    }

    public void playCardPick()
    {
        audioSource.PlayOneShot(cardPickEffect);
    }

    public void PlayDoorOpen()
    {
        audioSource.PlayOneShot(doorOpenEffect);
    }

    public void PlayLaserShootEffect()
    {
        audioSource.PlayOneShot(laserShotEffect);
    }
}


