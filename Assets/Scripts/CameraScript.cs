using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera[] vCameras;
    [SerializeField] Transform target;

    [SerializeField] float offset;
    CinemachineVirtualCamera followCamera;

    private void Start() {
        // vCameras = FindObjectsOfType<CinemachineVirtualCamera>();
    }
    void Update()
    {
        CheckPosition();
    }
    private void CheckPosition()
    {
        if (vCameras[0].transform.position.x + offset > target.position.x)
        {
            vCameras[0].Priority = 10;
            vCameras[1].Priority = 5;
            vCameras[2].Priority = 5;
            
        }else if (target.position.x + offset> vCameras[2].transform.position.x )
        {
            vCameras[0].Priority = 5;
            vCameras[1].Priority = 5;
            vCameras[2].Priority = 10;
        }else{
            vCameras[0].Priority = 5;
            vCameras[1].Priority = 10;
            vCameras[2].Priority = 5;
        }
    }
}
