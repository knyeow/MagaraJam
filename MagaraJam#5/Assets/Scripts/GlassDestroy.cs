using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GlassDestroy : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            ps.Play();
            Destroy(this.gameObject,.25f);
        }
    }
}
