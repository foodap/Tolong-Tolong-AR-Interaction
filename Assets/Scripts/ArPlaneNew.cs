using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]

public class ArPlaneNew : MonoBehaviour
{
    private ARPlaneManager planeManager;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    public void planeManagerDisable()
    {
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        planeManager.enabled = false;
    }
}
