using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Key : MonoBehaviour
{
    [System.NonSerialized]
    public int killCount;

    [System.NonSerialized]
    public bool isKeyPickedUp = false;

    private SpriteRenderer sr;

    private Image cardImage;

    private BoxCollider2D collider;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        cardImage = GameObject.Find("card").GetComponent<Image>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.Instance.playCardPick();
            collider.enabled = false;
            isKeyPickedUp = true;
            sr.enabled = false;
            cardImage.enabled = true;
        }
    }

    public void AddKillCount()
    {
        killCount++;
    }

    public int geKillCount()
    {
        return killCount;
    }

    public void setPickedUp(bool setBool)
    {
        isKeyPickedUp = setBool;
    }

    public bool getIsKeyPickedUp()
    {
        return isKeyPickedUp;
    }
}