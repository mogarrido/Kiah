using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamController : MonoBehaviour
{
    CinemachineVirtualCamera vcam;

    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public float OrtoSize { get => vcam.m_Lens.OrthographicSize; set => vcam.m_Lens.OrthographicSize = value;}

    public Transform Follow{get => vcam.Follow; set => vcam.Follow = value;}
}
