using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    
    public bool start = false;

    private CinemachineVirtualCamera cam;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        cam = this.GetComponent<CinemachineVirtualCamera>();
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update()
    {
        if (start)
        {
            noise.m_FrequencyGain = .17f;
        }
    }

}
