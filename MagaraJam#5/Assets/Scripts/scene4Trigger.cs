using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scene4Trigger : MonoBehaviour
{
    [SerializeField]
    private Transform camFollow;

    private CinemachineVirtualCamera cam;

    private void Start()
    {
        cam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Variables.moveable = false;
            cam.Follow = camFollow;
        }
    }
}
