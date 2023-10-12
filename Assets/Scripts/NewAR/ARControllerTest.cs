using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARControllerTest : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    public ArPlaneNew ARPlane;
    private GameObject FindSurface;
    private GameObject TapOnSurface;

    public dialogueManager4 dialogue;

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();

        FindSurface = GameObject.FindGameObjectWithTag("FindSurface");
        TapOnSurface = GameObject.FindGameObjectWithTag("TapOnSurface");

        FindSurface.SetActive(false);
        TapOnSurface.SetActive(false);
    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        if(spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
            dialogue.StartDialogue();
            ARPlane.planeManagerDisable();
            FindSurface.SetActive(false);
            TapOnSurface.SetActive(false);
        }

        UpdatePlacementPose();
        UpdateInstruction();
    }

    void UpdateInstruction()
    {
        if(spawnedObject == null && placementPoseIsValid)
        {
            TapOnSurface.SetActive(true);
            FindSurface.SetActive(false);
        }

        if(spawnedObject == null && placementPoseIsValid == false)
        {
            FindSurface.SetActive(true);
            TapOnSurface.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if(placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }
}

