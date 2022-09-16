using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float laserPower;
    [SerializeField] private Transform laserPoint;
    private Rigidbody2D rb;

    private float lifeTimeTimer=3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (lifeTimeTimer > 3)
            transform.position = laserPoint.position;


        lifeTimeTimer += Time.deltaTime;

    }
   
    public void setDirection(Vector2 direction)
    {
        if(lifeTimeTimer >3)
        rb.velocity = direction * laserPower*Time.fixedDeltaTime;
        lifeTimeTimer = 0;
    }

}
