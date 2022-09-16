using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float laserPower;
    [SerializeField] private Transform laserPoint;
    [SerializeField] private TrailRenderer tr;
    private Rigidbody2D rb;

    private float lifeTimeTimer=3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (lifeTimeTimer > 2.0)
        {
            tr.enabled = false;
            tr.Clear();
            transform.position = laserPoint.position;
        }


        lifeTimeTimer += Time.deltaTime;

    }
   
    public void setDirection(Vector2 direction)
    {
        if (lifeTimeTimer > 2.0)
        { 
            lifeTimeTimer = 0;
            tr.enabled = true;
            rb.velocity = direction * laserPower * Time.fixedDeltaTime;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            Debug.Log("Dusmana vuruldu");
    }
}
