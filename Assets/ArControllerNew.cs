using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArControllerNew : MonoBehaviour
{
    public GameObject MyObject;
    public ARRaycastManager RaycastManager;

    public ArPlaneNew ARPlane;

    bool previouswastouching = false;

    private void Update()
    {
        if(Input.touchCount>0 && previouswastouching == false && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> touches = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            GameObject.Instantiate(MyObject, touches[0].pose.position, touches[0].pose.rotation);

            previouswastouching = true;
            ARPlane.planeManagerDisable();
        }
    }
}

