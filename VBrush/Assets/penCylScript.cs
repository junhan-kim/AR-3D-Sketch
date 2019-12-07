using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class penCylScript : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private TrackableBehaviour.Status status;

    public bool isBrushLost;


    public void OnTrackableStateChanged(
                           TrackableBehaviour.Status previousStatus,
                           TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            isBrushLost = false;        
            status = TrackableBehaviour.Status.TRACKED;
        }
        else if (newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            isBrushLost = true;
            status = TrackableBehaviour.Status.EXTENDED_TRACKED;
        }
        else
        {
            isBrushLost = true;
            status = TrackableBehaviour.Status.NO_POSE;
        }
    }


    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        isBrushLost = true;
        status = TrackableBehaviour.Status.NO_POSE;
    }


    void Update()
    {
        if (status == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }
        }
    }
}