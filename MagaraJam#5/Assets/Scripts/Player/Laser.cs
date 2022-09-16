using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float laserPower;
    [SerializeField] private Transform laserPoint;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Animator anim;
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
        {
            rb.velocity = Vector2.zero;
            transform.position = laserPoint.position;
            EnemyDeathEvents(collision);
        }
            
    }

    private void EnemyDeathEvents(Collider2D collision)
    {

        Animator anim = collision.transform.parent.GetChild(2).GetComponent<Animator>();
        SpriteRenderer sr = collision.transform.parent.GetChild(2).GetComponent<SpriteRenderer>();
        Enemy enemy = collision.transform.parent.GetChild(1).GetComponent<Enemy>();
        collision.GetComponent<Animator>().SetTrigger("Death");
        collision.GetComponent<BoxCollider2D>().enabled = false;
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        sr.enabled = true;
        enemy.enabled = false;
        anim.SetTrigger("Splash");
        Destroy(collision.transform.parent.gameObject, 4);
    }
}
