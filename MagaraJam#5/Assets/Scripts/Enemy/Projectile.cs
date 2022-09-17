using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem ps;

    private float direction;

    private Rigidbody2D rb;

    private float lifeTimeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(bulletSpeed * Time.deltaTime * direction, 0);

        if (lifeTimeTimer >= 3f)
            DeActive();

        lifeTimeTimer += Time.deltaTime;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            Debug.Log("Playera vurdu");

            if (!Variables.IsPlayerDead)
            {
                anim.SetTrigger("Death");
                ps.Play();
            }

            Variables.IsPlayerDead = true;

            
                }
    }

    public void setDirection(float  _direction)
    {
        SoundManager.Instance.PlayEnemyShotEffect();
        gameObject.SetActive(true);
        lifeTimeTimer = 0;
        direction = _direction;
        
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

}

