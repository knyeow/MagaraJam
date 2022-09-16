using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform bulletPos;

    [SerializeField] private float playerDistance;
    [SerializeField] private LayerMask playerLayer;

    private float shootTimer;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        if(IsPlayerNear()&&shootTimer>=0.2f)
        Shooting();

        shootTimer += Time.deltaTime;
   
    }


    private bool IsPlayerNear()
    {
        if (Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), playerDistance, playerLayer))
            return true;
        else
            return false;

    }


    private void Shooting()
    {      
            shootTimer = 0;
        bullets[RightBullet()].transform.position = bulletPos.position;
        bullets[RightBullet()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
            
    }

    private int RightBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;


    }
}

