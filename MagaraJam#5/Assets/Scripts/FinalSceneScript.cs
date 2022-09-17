using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalSceneScript : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float startTextTime;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private GameObject text2;

    [SerializeField]
    private Transform camDestination;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject white;

    private Animator anim;

    private bool cameraMove = true;
    private void Start()
    {
        anim = GameObject.Find("Anna").GetComponent<Animator>();
        cam = Camera.main;
        StartCoroutine(StartCutscene());
    }

    private void FixedUpdate()
    {
        if (cameraMove)
        { 
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(camDestination.position.x, cam.transform.position.y, cam.transform.position.z), 1.5f * Time.fixedDeltaTime);
        }
    }

    private IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(startTextTime);
        text.SetActive(true);
        yield return new WaitForSeconds(45);
        text2.SetActive(true);
        audioSource.Stop();
        yield return new WaitForSeconds(7);
        white.SetActive(true);
        SoundManager.Instance.PlayLaserShootEffect();
        yield return new WaitForSeconds(.3f);
        white.SetActive(false);
        anim.SetTrigger("dead");
    }

}
